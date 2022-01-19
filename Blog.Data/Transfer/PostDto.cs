using System.Runtime.InteropServices;
using Blog.Data.Models;

namespace Blog.Data.Transfer
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public PostDto()
        {
            
        }
    }
}