using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Data.DataAccess;
using Blog.Data.Models;
using Blog.Data.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {

        private readonly ILogger<PostsController> _logger;
        private readonly ApplicationDbContext _context;

        public PostsController(ILogger<PostsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetAll()
        {
            _logger.Log(LogLevel.Information,"Returning posts");
            return await _context.Posts.ToListAsync();
        }
        
        [HttpPost]
        public PostDto Create(PostCreateDto postCreateDto)
        {
            _logger.Log(LogLevel.Information,"Creating a post");
            //var newPost = _context.Posts.Add();
            return null;
        }
    }
}