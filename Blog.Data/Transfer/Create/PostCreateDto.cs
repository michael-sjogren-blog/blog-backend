using System.ComponentModel.DataAnnotations;

#nullable enable
namespace Blog.Data.Transfer
{
    public class PostCreateDto
    {
        [Required]
        [MinLength(1 , ErrorMessage = "Title was empty")]
        [DataType(DataType.Text)]
        public string? Title { get; set; }
        [Required]
        [MinLength(1 , ErrorMessage = "Content was empty")]
        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int AuthorId { get; set; }

        public PostCreateDto()
        {
            
        }
    }
}