﻿namespace GradesApp.Services.Abstractions
{
    public interface IStudentService
    {
        Task<StudentDTO> GetByIdAsync(int id);
        Task<ICollection<StudentDTO>> GetAllAsync();
        Task CreateAsync(StudentDTO StudentDto);
        Task UpdateAsync(StudentDTO StudentDto);
        Task DeleteAsync(int StudentId);
        ICollection<StudentDTO> GetByName(string name);
        Task AddStudentVisitAsync(StudentVisitDTO StudentVisitDTO);
    }
}
