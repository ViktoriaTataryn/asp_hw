using Microsoft.AspNetCore.Identity;
using ht2.Models;

namespace ht2.Data
{
    public class EmployeeDatabase : IDatabase<Employee>
    {
        private readonly List<Employee> _employees;
        public EmployeeDatabase()
        {
            _employees = new List<Employee>();
        }
        public void Add(Employee item)
        {
            _employees.Add(item);
        }

        public IEnumerable<Employee> Get()
        {
            return _employees;
        }
    }
}
