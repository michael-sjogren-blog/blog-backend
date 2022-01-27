using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Transfer.Update
{
    public class PostUpdateDto
    {
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        [MinLength(1 , ErrorMessage = "Title was empty")]
        public string Title { get; set; }
        [MinLength(1 , ErrorMessage = "Content was empty")]
        public string Content { get; set; }
        [Range(1,int.MaxValue)]
        public int AuthorId { get; set; }
        public DateTime DatePosted {get;set;} = DateTime.Now;
        public int LikeCount {get;set;}

    }
}