using System.ComponentModel.DataAnnotations;
using MiniBlogRoleBase.Models;

namespace MiniBlogRoleBase;

public class Comment
{
        public int Id { get; set; }
        [MaxLength(1000)] public string Comments { get; set; } = "";
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; } = 5; // Default to 5 stars
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public string UserId { get; set; } = "";
        public ApplicationUser User { get; set; } = null!;
}