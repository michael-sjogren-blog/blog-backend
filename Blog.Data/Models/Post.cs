using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int LikeCount { get; set; } = 0;
        public DateTime DatePosted { get; set; }
        public Post()
        {
            
        }
        
    }
}