using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;

namespace GradesApp.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ReverseMap();
        }
    }
}
