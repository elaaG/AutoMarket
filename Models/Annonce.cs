using System;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class Annonce
    {
        public int Id { get; set; }
        [Required] public string Titre { get; set; } = "";
        [Required] public string Type { get; set; } = "Vente"; // Vente / Location
        [Required] public string Statut { get; set; } = "En attente"; // Pending / Approved / Rejected
        [Required] public DateTime DatePublication { get; set; } = DateTime.Now;

        // Relations
        public int VehiculeId { get; set; }
        public Vehicule Vehicule { get; set; } = null!;

        public int SellerId { get; set; }
        public User Seller { get; set; } = null!;
    }
}
