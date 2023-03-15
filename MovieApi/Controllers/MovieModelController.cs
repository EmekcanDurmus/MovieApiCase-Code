using AutoMapper;
using DAL.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieModelController : ControllerBase
    {
        private readonly IMovieModelService _movieModelService;
        private readonly IMapper _mapper;
        private readonly ILogger<MovieModelController> _logger;

        public MovieModelController(IMovieModelService movieModelService, IMapper mapper, ILogger<MovieModelController> logger)
        {
            _mapper = mapper;
            _movieModelService = movieModelService;
            this._logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(" LogInformation -> Get Method is called");
            _logger.LogTrace(" LogTrace -> Get Method is called");
            _logger.LogDebug(" LogDebug -> Get Method is called");
            _logger.LogWarning("LogWarning -> Get Method is called");
            _logger.LogError("LogError -> Get Method is called");
            var movieModels = await _movieModelService.GetAll();
            var movieModelsDto = _mapper.Map<IEnumerable<MovieModelDto>>(movieModels);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movieModelsDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var movieModel = await _movieModelService.Get(Id);
            var movieModelDto = _mapper.Map<MovieModelDto>(movieModel);
            return Ok(movieModelDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(MovieModelDto movieModelDto)
        {
            var movieModel = _mapper.Map<MovieModel>(movieModelDto);
            var newMovieModel = await _movieModelService.Insert(movieModel);
            return Created(String.Empty, null); // _mapper.Map<MovieModelDto>(newMovieModel));
        }
        [HttpPatch]
        public IActionResult Patch(int Id, MovieModelDto movieModelDto)
        {
            if (Id == 0)
            {
                return BadRequest();
            }

            var movieModel = _mapper.Map<MovieModel>(movieModelDto);
            _movieModelService.Edit(movieModel);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var entity = _movieModelService.Delete(Id);
            return NoContent();
        }
    }
}
