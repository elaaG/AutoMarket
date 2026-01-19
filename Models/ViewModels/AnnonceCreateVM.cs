using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models.ViewModels
{
    public class AnnonceCreateVM
    {
        [Required] public string Titre { get; set; } = "";
        [Required] public string Type { get; set; } = "Vente";

        // Vehicle
        [Required] public string Marque { get; set; } = "";
        [Required] public string Modele { get; set; } = "";
        [Required] public int Annee { get; set; }
        [Required] public int Kilometrage { get; set; }
        [Required] public decimal Prix { get; set; }
        public IFormFile? Photo { get; set; }

        // Seller
        public int SellerId { get; set; }
    }
}
