using AutoMapper;
using Model;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<MovieModel, MovieModelDto>().ReverseMap();
        }
    }
}
