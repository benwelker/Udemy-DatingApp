using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, options => {
                     options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, options => {
                    options.ResolveUsing(d => d.DateOfBirth.CalculateAge());;
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, options => {
                     options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, options => {
                    options.ResolveUsing(d => d.DateOfBirth.CalculateAge());;
                });
                
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}