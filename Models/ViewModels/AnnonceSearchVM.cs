namespace AutoMarket.Models.ViewModels
{
   public class AnnonceSearchVM
{
    public string? Marque { get; set; }
    public string? Modele { get; set; }
    public string? Type { get; set; }
    public decimal? PrixMin { get; set; }
    public decimal? PrixMax { get; set; }
    public int? KilometrageMin { get; set; }
    public int? KilometrageMax { get; set; }
    public string? Status { get; set; } 
    public string? SortBy { get; set; } 
}
}
