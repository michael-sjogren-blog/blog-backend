using System.Collections.Generic;
using Blog.Data.Transfer.Post;
using Blog.Data.Transfer.User;

namespace Blog.Data.Transfer.Author
{
    public class AuthorDto : UserDto
    {
        public ICollection<PostDto> Posts { get; set; }

        public AuthorDto()
        {
            
        }
    }
}