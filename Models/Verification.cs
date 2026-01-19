using System;

namespace AutoMarket.Models
{
    public class Verification
    {
        public int Id { get; set; }
        public int VehiculeId { get; set; }
        public Vehicule Vehicule { get; set; } = null!;

        public int ExpertId { get; set; }
        public User Expert { get; set; } = null!;

        public bool Approuve { get; set; } = false;
        public string Rapport { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
