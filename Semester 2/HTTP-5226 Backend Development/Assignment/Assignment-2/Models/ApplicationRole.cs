
using Microsoft.AspNetCore.Identity;

namespace Assignment_2.Models
{
    public class ApplicationRole : IdentityRole
    {
        // public string? Description { get; set; }
        public string? Role { get; set; }
    }
}