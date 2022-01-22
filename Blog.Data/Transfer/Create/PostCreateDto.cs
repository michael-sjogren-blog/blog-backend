using System.ComponentModel.DataAnnotations;

#nullable enable
namespace Blog.Data.Transfer
{
    public class PostCreateDto
    {
        [MinLength(1 , ErrorMessage = "Title was empty")]
        public string? Title { get; set; }
        [MinLength(1 , ErrorMessage = "Content was empty")]
        public string? Content { get; set; }
        [Range(1,int.MaxValue)]
        public int AuthorId { get; set; }

        public PostCreateDto()
        {
            
        }
    }
}