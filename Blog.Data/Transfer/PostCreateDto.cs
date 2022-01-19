#nullable enable
namespace Blog.Data.Transfer
{
    public class PostCreateDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? AuthorId { get; set; }

        public PostCreateDto()
        {
            
        }
    }
}