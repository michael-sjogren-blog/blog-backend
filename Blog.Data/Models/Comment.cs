using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }

        public Comment()
        {
            
        }
    }
}