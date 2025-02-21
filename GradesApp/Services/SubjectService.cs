using GradesApp.Services.Abstractions;

namespace GradesApp.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _subjectRepository;
        private IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SubjectDTO subjectDto)
        {
            Subject subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.CreateAsync(subject);
        }

        public async Task DeleteAsync(int subjectId)
        {
            await _subjectRepository.DeleteByIdAsync(subjectId);
        }

        public async Task<ICollection<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            return _mapper.Map<ICollection<SubjectDTO>>(subjects);
        }

        public async Task<SubjectDTO> GetByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            return _mapper.Map<SubjectDTO>(subject);
        }

        public ICollection<SubjectDTO> GetByName(string name)
        {
            var subjects = _subjectRepository
                .GetByFilter(subject => subject.FirstName == name
                    || subject.LastName == name);
            return _mapper.Map<ICollection<SubjectDTO>>(subjects);
        }

        public async Task UpdateAsync(SubjectDTO subjectDto)
        {
            Subject subject = _mapper.Map<Subject>(subjectDto);
            await _subjectRepository.UpdateAsync(subject);
        }
    }
}
