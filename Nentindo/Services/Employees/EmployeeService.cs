using Nentindo.Data;

namespace Nentindo.Services.Employees
{
    public class EmployeeService: IEmployeeService
    {
        readonly DatabaseContext _db;
        public EmployeeService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Employee> Get(int id)
        {
            return await _db.Employees.FindAsync(id);
        }
    }
}
