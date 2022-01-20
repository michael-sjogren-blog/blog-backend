using System.Collections.Generic;
using AutoMapper;
using Blog.Data.Models;
using Blog.Data.Transfer;

namespace Blog.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostCreateDto, Post>().ReverseMap();
            CreateMap<ICollection<Post>, List<PostDto>>().ReverseMap();
        }
    }
}