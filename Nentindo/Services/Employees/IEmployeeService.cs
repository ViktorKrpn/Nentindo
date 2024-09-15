using Nentindo.Data;
using Nentindo.Data.Models;

namespace Nentindo.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<Employee> Get(int id);
    }
}
