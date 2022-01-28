using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Data.DataAccess;
using Blog.Data.Models;
using Blog.Data.Models.Repository;
using Blog.Data.Transfer;
using Blog.Data.Transfer.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IRepository<Author, int> _AuthorsRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger, IMapper mapper, ApplicationDbContext context, IRepository<Author, int> AuthorsRepository)
        {
            _logger = logger;
            _context = context;
            _AuthorsRepository = AuthorsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<AuthorDto>>> GetAllAsync()
        {
            try
            {
                
                var Authors = await _AuthorsRepository.GetAll();
                var dtos = _mapper.Map<ICollection>(Authors);
                _logger.Log(LogLevel.Information, "Returning Authors");
                return Ok(dtos);
            }
            catch (Exception e)
            {
                _logger.LogError("{}",e.Message);
                return StatusCode(500, "Something went wrong");
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<AuthorDto>> GetOneAsync(int id)
        {
            _logger.Log(LogLevel.Information, "Returning Author");
            try
            {
                var Author = await _AuthorsRepository.GetOne(id);
                var dto = _mapper.Map<AuthorDto>(Author);
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
            _logger.Log(LogLevel.Information, "Returning Author");
            try
            {
                await _AuthorsRepository.DeleteOne(Id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] AuthorCreateDto AuthorCreateDto)
        {
            try
            {
                var newAuthor = await _AuthorsRepository.Create(_mapper.Map<Author>(AuthorCreateDto));
                _logger.Log(LogLevel.Information, "Creating a Author");
                return Ok(_mapper.Map<AuthorDto>(newAuthor));
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
        public async Task<ActionResult<AuthorDto>> Update([FromBody] AuthorUpdateDto AuthorUpdateDto , int id)
        {
            try
            {
                var newAuthor = await _AuthorsRepository.UpdateOne(_mapper.Map<Author>(AuthorUpdateDto) , id);
                _logger.Log(LogLevel.Information, "updating a Author");
                return Ok(_mapper.Map<AuthorDto>(newAuthor));
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