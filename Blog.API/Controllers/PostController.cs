using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.DataAccess;
using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly ApplicationDbContext _context;

        public PostController(ILogger<PostController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _context.Posts.ToArray();
        }
    }
}