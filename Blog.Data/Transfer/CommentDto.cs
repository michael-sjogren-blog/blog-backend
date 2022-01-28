using Blog.Data.Transfer.User;

namespace Blog.Data.Transfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        
        public UserDto User { get; set; }
        public int UserId { get; set; }

        public CommentDto()
        {
            
        }
    }
}