using Microsoft.AspNetCore.Identity;

namespace MiniBlogRoleBase.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? Name { get; set; }

        // public ICollection<Post> Posts { get; set; } = new List<Post>();
        // public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}