using System.Collections.Generic;
using AutoMapper;
using Blog.Data.Models;
using Blog.Data.Transfer.Post;
using Blog.Data.Transfer.Author;
using Blog.Data.Transfer.User;

namespace Blog.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostCreateDto, Post>().ReverseMap();
            CreateMap<PostUpdateDto, Post>().ReverseMap();
            CreateMap<ICollection<Post>, List<PostDto>>().ReverseMap();

            CreateMap<UserDto, UserDto>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
        }
    }
}