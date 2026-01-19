namespace AutoMarket.Models.ViewModels
{
    public class AnnonceSearchVM
    {
        public string? Marque { get; set; }
        public string? Modele { get; set; }
        public decimal? PrixMin { get; set; }
        public decimal? PrixMax { get; set; }
        public int? KilometrageMax { get; set; }
    }
}
