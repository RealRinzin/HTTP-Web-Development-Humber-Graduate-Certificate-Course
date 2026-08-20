using Microsoft.AspNetCore.Identity;

namespace MiniReddit.Models
{
    // Extends the built-in Identity user with the one extra field
    // our assignment needs: whether this user has been banned.
    // Roles ("User" / "Admin") are handled separately by Identity's
    // AspNetRoles / AspNetUserRoles tables - not stored here.
    public class ApplicationUser : IdentityUser
    {
        public bool IsBanned { get; set; } = false;
    }
}
