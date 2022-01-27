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
using Blog.Data.Transfer.Update;
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
        public async Task<ActionResult<PostDto>> GetOneAsync(int id)
        {
            _logger.Log(LogLevel.Information, "Returning post");
            try
            {

                var post = await _postsRepository.GetOne(id);
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
                await _postsRepository.DeleteOne(Id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> Create([FromBody] PostCreateDto postCreateDto)
        {
            try
            {
                var newPost = await _postsRepository.Create(_mapper.Map<Post>(postCreateDto));
                _logger.Log(LogLevel.Information, "Creating a post");
                return Ok(_mapper.Map<PostDto>(newPost));
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


        [HttpPut]
        public async Task<ActionResult<PostDto>> Update([FromBody] PostUpdateDto postUpdateDto , int id)
        {
            try
            {
                var newPost = await _postsRepository.UpdateOne(_mapper.Map<Post>(postUpdateDto) , id);
                _logger.Log(LogLevel.Information, "updating a post");
                return Ok(_mapper.Map<PostDto>(newPost));
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