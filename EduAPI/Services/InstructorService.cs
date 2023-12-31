using System.Collections.Generic;
using System.Threading.Tasks;
using EduAPI.Entities;
using EduAPI.Repositories;

namespace EduAPI.Services
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorService(InstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task AddInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.AddAsync(instructor);
        }

        public async Task UpdateInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.UpdateAsync(instructor);
        }

        public async Task DeleteInstructorAsync(int id)
        {
            await _instructorRepository.DeleteAsync(id);
        }
    }
}
