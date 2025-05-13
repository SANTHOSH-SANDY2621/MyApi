using MyApi.Models;

namespace MyApi.BussinessRepository.IBussinessRepository
{
    public interface IEmployerRepository
    {
        public Task<List<Employer>> GetEmployers();
    }
}
