using MyApi.BussinessRepository.IBussinessRepository;
using MyApi.Models;

namespace MyApi.BussinessRepository
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly LearningNetContext _context;

        public EmployerRepository(LearningNetContext context)
        {
            _context = context;
        }
        public async Task<List<Employer>> GetEmployers()
        {
            return _context.Employers.ToList();
        }
    }
}
