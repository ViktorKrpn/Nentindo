using Nentindo.Data;

namespace Nentindo.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<Employee> Get(int id);
    }
}
