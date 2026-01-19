using AutoMarket.Models;

namespace AutoMarket.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Check if users exist
            if (!context.Users.Any())
            {
                var defaultUser = new User
                {
                    Name = "Default User",
                    Email = "user@automarket.com"
                };
                context.Users.Add(defaultUser);
                context.SaveChanges();

                // Create some vehicles
                var v1 = new Vehicule
                {
                    Marque = "BMW",
                    Modele = "Serie 3",
                    Annee = 2018,
                    Kilometrage = 50000,
                    Prix = 25000,
                    PhotoPath = "/images/bmw1.jpg",
                    Verifie = true
                };

                var v2 = new Vehicule
                {
                    Marque = "Audi",
                    Modele = "A4",
                    Annee = 2019,
                    Kilometrage = 30000,
                    Prix = 30000,
                    PhotoPath = "/images/audi1.jpg",
                    Verifie = false
                };

                context.Vehicules.AddRange(v1, v2);
                context.SaveChanges();

                // Create annonces
                var a1 = new Annonce
                {
                    Titre = "BMW Serie 3 à vendre",
                    Type = "Vente",
                    Statut = "Validée",
                    DatePublication = DateTime.Now,
                    VehiculeId = v1.Id,
                    SellerId = defaultUser.Id
                };

                var a2 = new Annonce
                {
                    Titre = "Audi A4 à louer",
                    Type = "Location",
                    Statut = "En attente",
                    DatePublication = DateTime.Now,
                    VehiculeId = v2.Id,
                    SellerId = defaultUser.Id
                };

                context.Annonces.AddRange(a1, a2);
                context.SaveChanges();
            }
        }
    }
}
