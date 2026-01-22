using AutoMarket.Models;
using System;
using System.Linq;

namespace AutoMarket.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Annonces.Count() >= 5)
                return;


            // Create default user
            var defaultUser = new AppUser
            {
                UserName = "defaultuser",
                Email = "user@automarket.com",
                EmailConfirmed = true
            };

            context.Users.Add(defaultUser);
            context.SaveChanges();

            // Add 5 vehicles and annonces
            var v1 = new Vehicule { Marque = "BMW", Modele = "Serie 3", Annee = 2018, Kilometrage = 50000, Prix = 25000, PhotoPath = "/images/bmw1.jpg", Verifie = true };
            var v2 = new Vehicule { Marque = "Audi", Modele = "A4", Annee = 2019, Kilometrage = 30000, Prix = 30000, PhotoPath = "/images/audi1.jpg", Verifie = true };
            var v3 = new Vehicule { Marque = "Toyota", Modele = "Corolla", Annee = 2020, Kilometrage = 20000, Prix = 18000, PhotoPath = "/images/toyota1.jpg", Verifie = true };
            var v4 = new Vehicule { Marque = "Mercedes", Modele = "C-Class", Annee = 2021, Kilometrage = 15000, Prix = 35000, PhotoPath = "/images/mercedes1.jpg", Verifie = false };
            var v5 = new Vehicule { Marque = "Renault", Modele = "Clio", Annee = 2017, Kilometrage = 70000, Prix = 9000, PhotoPath = "/images/clio1.jpg", Verifie = true };

            context.Vehicules.AddRange(v1, v2, v3, v4, v5);
            context.SaveChanges();

            var a1 = new Annonce { Titre = "BMW Serie 3 à vendre", Type = "Vente", Statut = "Validée", DatePublication = DateTime.Now, VehiculeId = v1.Id, SellerId = defaultUser.Id };
            var a2 = new Annonce { Titre = "Audi A4 à louer", Type = "Location", Statut = "Validée", DatePublication = DateTime.Now, VehiculeId = v2.Id, SellerId = defaultUser.Id };
            var a3 = new Annonce { Titre = "Toyota Corolla à vendre", Type = "Vente", Statut = "Validée", DatePublication = DateTime.Now, VehiculeId = v3.Id, SellerId = defaultUser.Id };
            var a4 = new Annonce { Titre = "Mercedes C-Class à louer", Type = "Location", Statut = "En attente", DatePublication = DateTime.Now, VehiculeId = v4.Id, SellerId = defaultUser.Id };
            var a5 = new Annonce { Titre = "Renault Clio à vendre", Type = "Vente", Statut = "Validée", DatePublication = DateTime.Now, VehiculeId = v5.Id, SellerId = defaultUser.Id };

            context.Annonces.AddRange(a1, a2, a3, a4, a5);
            context.SaveChanges();
        }
    }
}
