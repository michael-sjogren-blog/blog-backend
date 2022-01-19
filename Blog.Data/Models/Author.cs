using System.Collections.Generic;

namespace Blog.Data.Models
{
    
    public class Author : User
    {
        public ICollection<Post> Posts { get; set; }
        
        public Author()
        {
            
        }
    }
}