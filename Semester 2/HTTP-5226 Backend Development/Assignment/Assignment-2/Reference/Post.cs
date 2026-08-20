using System.ComponentModel.DataAnnotations;

namespace MiniReddit.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property: one post has many comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
