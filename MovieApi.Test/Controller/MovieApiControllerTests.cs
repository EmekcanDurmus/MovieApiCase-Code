using AutoMapper;
using DAL.Services.IService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Dto;
using MovieApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MovieApi.Test.Controller
{
    public class MovieApiControllerTests
    {
        private readonly IMovieModelService _movieModelService;
        private readonly IMapper _mapper;
        private ILogger<MovieModelController> _logger;

        public MovieApiControllerTests()
        {
            _movieModelService = A.Fake<IMovieModelService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]

        public void MovieApiController_GetMovies_ReturnOk()
        {
            // Arrange

            var movieModelsDto = A.Fake<ICollection<MovieModelDto>>();
            var movieList = A.Fake<IEnumerable<MovieModelDto>>();
            A.CallTo(() => _mapper.Map<IEnumerable<MovieModelDto>>(movieModelsDto)).Returns(movieList);
            var controller = new MovieModelController(_movieModelService,_mapper,_logger);


            // Act
            var result = controller.GetAll();

            // Asset
            result.Should().NotBeNull();
            //result.Should().BeOfType(typeof(OkObjectResult));
        }

    }
}
