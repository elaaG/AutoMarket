using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        [Required] public string Marque { get; set; } = "";
        [Required] public string Modele { get; set; } = "";
        [Required] public int Annee { get; set; }
        [Required] public int Kilometrage { get; set; }
        [Required] public decimal Prix { get; set; }

        // Path to uploaded photo
        public string PhotoPath { get; set; } = "";

        // Verification status
        public bool Verifie { get; set; } = false;

        // Navigation
        public Annonce? Annonce { get; set; }
        public List<Verification>? Verifications { get; set; }
    }
}
