using System;

namespace AutoMarket.Models
{
    public class Verification
    {
        public int Id { get; set; }

        public int AnnonceId { get; set; }
        public Annonce Annonce { get; set; } = null!;

        public string ExpertId { get; set; } = "";
        public AppUser Expert { get; set; } = null!;

        public DateTime DateVerification { get; set; } = DateTime.Now;

        public bool Approved { get; set; } = false;
        public string Comment { get; set; } = "";
    }
}
