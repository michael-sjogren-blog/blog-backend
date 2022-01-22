using System.Collections.Generic;
using System.Linq;
using Blog.Data.Models;

namespace Blog.Data.Transfer.Read
{
    public class AuthorDto : UserDto
    {
        public ICollection<PostDto> Posts { get; set; }

        public AuthorDto()
        {
            
        }
    }
}