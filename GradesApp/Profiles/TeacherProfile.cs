using AutoMapper;
using GradesApp.Data.Entities;
using GradesApp.DTOs;

namespace GradesApp.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>()
                .ReverseMap();

            CreateMap<TeacherCreateDTO, Teacher>()
                .ReverseMap();

            CreateMap<TeacherEditDTO, Teacher>()
    .ReverseMap();
        }
    }
}
