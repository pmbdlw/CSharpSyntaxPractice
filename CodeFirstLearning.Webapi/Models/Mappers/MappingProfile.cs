using AutoMapper;
using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Webapi.Models.CreatePost;

namespace CodeFirstLearning.Webapi.Models.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post, ResponsePost>()
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name))
            .ForMember(dest=>dest.CategoryName,opt=>opt.MapFrom(src=>src.Category.Name));
    }
}