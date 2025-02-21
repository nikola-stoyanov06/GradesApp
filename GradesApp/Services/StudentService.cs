namespace GradesApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        public StudentsService(IStudentsRepository studentsRepository, IGradeRepository gradeRepository, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task AddStudentGradeAsync(StudentGradeDTO studentGradeDTO)
        {
            var grade = _mapper.Map<Grade>(studentGradeDTO);
            await _gradeRepository.CreateAsync(grade);
        }

        public async Task CreateAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentsRepository.CreateAsync(student);
        }

        public async Task DeleteAsync(int studentId)
        {
            await _studentsRepository.DeleteByIdAsync(studentId);
        }

        public async Task<ICollection<StudentDTO>> GetAllAsync()
        {
            var students = await _studentsRepository.GetAllAsync();
            return _mapper.Map<ICollection<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _studentsRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public ICollection<StudentDTO> GetByName(string name)
        {
            var students = _studentsRepository.GetByFilter(student => student.Name == name);
            return _mapper.Map<ICollection<StudentDTO>>(students);
        }

        public async Task UpdateAsync(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentsRepository.UpdateAsync(student);
        }
    }
}
