using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models.ViewModels
{
    public class AnnonceEditVM
    {
        public int? Id { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Type { get; set; } // Vente / Location

        [Required]
        public string Marque { get; set; }

        [Required]
        public string Modele { get; set; }

        public int Annee { get; set; }

        public int Kilometrage { get; set; }

        public decimal Prix { get; set; }

        public IFormFile? Photo { get; set; }

        public string? ExistingPhotoPath { get; set; }
    }
}
