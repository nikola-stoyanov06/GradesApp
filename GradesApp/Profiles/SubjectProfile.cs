using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;

namespace GradesApp.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDTO>()
                .ReverseMap();
        }
    }
}
