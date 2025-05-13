using MyApi.Models;

namespace MyApi.BussinessLogic.IBussinessLogic
{
    public interface IEmployerBussinessLogic
    {
        public Task<List<Employer>> GetEmployers();
    }
}
