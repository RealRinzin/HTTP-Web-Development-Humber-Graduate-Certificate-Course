using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(1000)] public string Text { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int Likes { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public string UserId { get; set; } = "";
        public ApplicationUser User { get; set; } = null!;
    }
}