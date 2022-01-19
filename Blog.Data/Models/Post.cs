
using System.ComponentModel.DataAnnotations;
using Blog.Data.Transfer;

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

        public Post()
        {
            
        }
        
    }
}