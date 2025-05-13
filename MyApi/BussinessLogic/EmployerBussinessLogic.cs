using MyApi.BussinessLogic.IBussinessLogic;
using MyApi.BussinessRepository.IBussinessRepository;
using MyApi.Models;

namespace MyApi.BussinessLogic
{
    public class EmployerBussinessLogic : IEmployerBussinessLogic
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerBussinessLogic(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        public async Task<List<Employer>> GetEmployers()
        {
            return  await _employerRepository.GetEmployers();
        }
    }
}
