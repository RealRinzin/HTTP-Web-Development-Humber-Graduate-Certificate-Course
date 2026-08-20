using System.ComponentModel.DataAnnotations;
using MiniBlogRoleBase.Models;

namespace MiniBlogRoleBase;

public class Post
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = "";
    [Required]

    public string FeaturedImage { get; set; } = "";
    public string Description { get; set; } = "";
    public string Summary { get; set; } = "";

    public string UserId { get; set; } = "";
    public ApplicationUser User { get; set; } = null!;

    // Navigation property for Comments
    public List<Comment> Comments { get; set; } = new();
}