using System;
using System.ComponentModel.DataAnnotations;

#nullable enable
namespace Blog.Data.Transfer.Post
{
    public class PostCreateDto
    {
        [MinLength(1 , ErrorMessage = "Title was empty")]
        public string? Title { get; set; }
        [MinLength(1 , ErrorMessage = "Content was empty")]
        public string? Content { get; set; }
        [Range(1,int.MaxValue)]
        public int AuthorId { get; set; }

        public DateTime DatePosted {get;set;}
        
        [Range(0 , int.MaxValue , ErrorMessage = "LikeCount must be above -1")]
        public int LikeCount {get;init;} = 1;
        public PostCreateDto()
        {
            DatePosted = DateTime.Now;
        }
    }
}