using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using AutoMarket.Models;

namespace AutoMarket.Models
{
    public enum Role
    {
        Buyer,
        Seller,
        Expert
    }

    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = "";
        public Role Role { get; set; } = Role.Buyer;

        public ICollection<Annonce> Annonces { get; set; } = new List<Annonce>();
    }
}
