using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Post
    {
    public int Id { get; set; }
    [MaxLength(200)] public string Title { get; set; } = "";
    public string Body { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string AuthorId { get; set; } = "";
    public ApplicationUser Author { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}