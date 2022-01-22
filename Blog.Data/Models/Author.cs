using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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