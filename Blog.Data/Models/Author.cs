using System.Collections.Generic;

namespace Blog.Data.Models
{
    
    public class Author : User
    {
        public List<Post> Posts { get; set; }
    }
}