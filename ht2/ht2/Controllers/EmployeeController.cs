using ht2.Data;
using ht2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ht2.Controllers
{
    public class EmployeeController:Controller
    {
        private static readonly IDatabase<Employee> _empdatabase = new EmployeeDatabase();
        private static readonly IDatabase<Manager> _managdatabase = new ManagerDatabase();
        static EmployeeController()
        {
            
            _empdatabase.Add(new Employee() { Name="Ann", Surname="Smith",Salary=2123,Email="annsm12@gmail.com" });
            _empdatabase.Add(new Employee() { Name = "John", Surname = "Grey", Salary = 5462, Email = "grey42@gmail.com" });
            _empdatabase.Add(new Employee() { Name = "Mary", Surname = "Miller", Salary = 8623, Email = "millerm@gmail.com" });

            _managdatabase.Add(new Manager() { Name = "Jack", Surname = "Black", Salary = 5342, Email = "black5@gmail.com", EmployeeCount = 9 });
            _managdatabase.Add(new Manager() { Name = "Emma", Surname = "Tomson", Salary = 8323, Email = "emm63@gmail.com", EmployeeCount = 14 });
        }
        [HttpGet] 
        public IActionResult GetEmp()
        {
            var emp = _empdatabase.Get();
            return View(emp);
        }
        public IActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Employee employee)
        {
            _empdatabase.Add(employee);
            return RedirectToAction(nameof(GetEmp));
        }
        [HttpGet]
        public IActionResult GetManager()
        {
            var manager = _managdatabase.Get();
            return View(manager);
        }
        public IActionResult AddManager( )
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddManager(Manager manager)
        {
            _managdatabase.Add(manager);
            return RedirectToAction(nameof(GetManager));
        }
    }
}
