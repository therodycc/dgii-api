using dgii_api.data;
using dgii_api.models;

namespace dgii_api
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            dataContext = context;
        }

        public void SeedDataContext()
        {
            SeedContribuyentes();
            dataContext.SaveChanges();

            SeedComprobantes();
            dataContext.SaveChanges();
        }

        private void SeedContribuyentes()
        {
            if (!dataContext.Contribuyentes.Any())
            {
                var contribuyentes = new List<Contribuyente>
                {
                    new Contribuyente
                    {
                        RncCedula = "98754321012",
                        Nombre = "JUAN PEREZ",
                        Tipo = "PERSONA FISICA",
                        Estatus = "activo"
                    },
                    new Contribuyente
                    {
                        RncCedula = "123456789",
                        Nombre = "FARMACIA TU SALUD",
                        Tipo = "PERSONA JURIDICA",
                        Estatus = "inactivo"
                    }
                };

                dataContext.Contribuyentes.AddRange(contribuyentes);
            }
        }

        private void SeedComprobantes()
        {
            if (!dataContext.ComprobantesFiscales.Any())
            {
                var juan = dataContext.Contribuyentes
                    .FirstOrDefault(c => c.RncCedula == "98754321012");

                if (juan == null) return;

                var comprobantes = new List<ComprobanteFiscal>
                {
                    new ComprobanteFiscal
                    {
                        ContribuyenteId = juan.Id,
                        RncCedula = juan.RncCedula,
                        NCF = "E310000000001",
                        Monto = 200.00m,
                        Itbis18 = 36.00m
                    },
                    new ComprobanteFiscal
                    {
                        ContribuyenteId = juan.Id,
                        RncCedula = juan.RncCedula,
                        NCF = "E310000000002",
                        Monto = 1000.00m,
                        Itbis18 = 180.00m
                    }
                };

                dataContext.ComprobantesFiscales.AddRange(comprobantes);
            }
        }



    }
}