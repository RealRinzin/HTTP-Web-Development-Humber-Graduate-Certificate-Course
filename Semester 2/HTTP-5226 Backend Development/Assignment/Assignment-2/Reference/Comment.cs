using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniReddit.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required, MaxLength(1000)]
        public string Text { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Bonus feature chosen: Like comments
        public int Likes { get; set; } = 0;

        // --- Relationships ---

        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post? Post { get; set; }

        // FK to AspNetUsers.Id (string, because Identity uses string keys)
        public string AuthorId { get; set; } = string.Empty;
        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser? Author { get; set; }
    }
}
