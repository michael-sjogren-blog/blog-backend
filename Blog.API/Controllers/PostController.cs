using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.DataAccess;
using Blog.Data.Models;
using Blog.Data.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly IMapper _mapper;

        public PostsController(ILogger<PostsController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PostDto>>> GetAllAsync()
        {
            try
            {

                var posts = await _context.Posts.ToListAsync();
                var dtos = _mapper.Map<ICollection<PostDto>>(posts);
                _logger.Log(LogLevel.Information, "Returning posts");
                return Ok(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError("{}",e.Message);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<PostDto>> GetOneAsync(int Id)
        {
            _logger.Log(LogLevel.Information, "Returning post");
            try
            {

                var post = await _context.Posts.FindAsync(Id);
                return Ok(_mapper.Map<PostDto>(post));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteOneAsync(int Id)
        {
            _logger.Log(LogLevel.Information, "Returning post");
            try
            {
                var post = await _context.FindAsync<Post>(Id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> Create(PostCreateDto postCreateDto)
        {
            _logger.Log(LogLevel.Information, "Creating a post");
            try
            {
                var newPost = await _context.Posts.AddAsync(_mapper.Map<Post>(postCreateDto));
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<PostDto>(newPost.Entity));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            //var newPost = _context.Posts.Add(post);
            return BadRequest("Invalid post");
        }
    }
}