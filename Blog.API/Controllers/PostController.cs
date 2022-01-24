using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.DataAccess;
using Blog.Data.Models;
using Blog.Data.Models.Repository;
using Blog.Data.Transfer;
using Blog.Data.Transfer.Read;
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
        private readonly IRepository<Post, int> _postsRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostsController(ILogger<PostsController> logger, IMapper mapper, ApplicationDbContext context, IRepository<Post, int> postsRepository)
        {
            _logger = logger;
            _context = context;
            _postsRepository = postsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PostDto>>> GetAllAsync()
        {
            try
            {
                
                var posts = await _postsRepository.GetAll();
                var dtos = _mapper.Map<ICollection>(posts);
                _logger.Log(LogLevel.Information, "Returning posts");
                return Ok(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError("{}",e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<PostDto>> GetOneAsync(int Id)
        {
            _logger.Log(LogLevel.Information, "Returning post");
            try
            {

                var post = await _context.Posts
                    .Include(p => p.Author)
                    .FirstAsync(p => p.Id == Id);
                post.Author.Posts = new List<Post>();
                var dto = _mapper.Map<PostDto>(post);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
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
        public async Task<ActionResult<PostDto>> Create([FromBody] PostCreateDto postCreateDto)
        {
            _logger.Log(LogLevel.Information, "Creating a post");
            try
            {
                var newPost = await _context.Posts.AddAsync(_mapper.Map<Post>(postCreateDto));
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<PostDto>(newPost.Entity));
            }
            catch (DbUpdateException e)
            {
                _logger.LogError("{}",e.Message);
                return StatusCode(500, "Something went wrong saving to the database");
            }
            catch (Exception e)
            {
                _logger.LogCritical("{}",e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}