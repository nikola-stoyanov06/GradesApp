using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;

namespace GradesApp.Profiles
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeDTO>()
                .ReverseMap();
        }
    }
}
