using System;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class Annonce
    {
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = "Vente"; 

        [Required]
        public string Statut { get; set; } = "En attente"; 

        [Required]
        public DateTime DatePublication { get; set; } = DateTime.Now;

        public int VehiculeId { get; set; }
        public Vehicule Vehicule { get; set; } = null!;

        public string SellerId { get; set; } = "";
        public AppUser Seller { get; set; } = null!;

    }
}
