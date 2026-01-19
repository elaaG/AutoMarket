using System.Collections.Generic;

namespace AutoMarket.Models
{
    public enum Role
    {
        Buyer,
        Seller,
        Expert
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public Role Role { get; set; }

        // Navigation
        public List<Annonce>? Annonces { get; set; }
        public List<Verification>? Verifications { get; set; }
    }
}
