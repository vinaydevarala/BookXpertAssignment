using BookXpertAssignment.Dbcontexts;
using BookXpertAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookXpertAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeDbContext EmployeeDbContext { get; }

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            EmployeeDbContext = employeeDbContext;
        }

        public IActionResult Index(int? Id)
        {
            
            if (Id.HasValue)
            {
                var employee = EmployeeDbContext.Employees.FirstOrDefault(e => e.Id == Id.Value);
                if (employee != null)
                {
                    return View(employee);  
                }
            }

          
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            //if (employee.Id == 0)
            //{
            //    employee.Id = EmployeeDbContext.Employees.Max(e => e.Id) + 1;
            //    EmployeeDbContext.Employees.Add(employee);
            //}
            //else
            //{
                var existingEmployee = EmployeeDbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.Designation = employee.Designation;
                    existingEmployee.DateOfJoining = employee.DateOfJoining;
                    existingEmployee.Salary = employee.Salary;
                    existingEmployee.Gender = employee.Gender;
                    existingEmployee.State = employee.State;
                EmployeeDbContext.SaveChanges();
                }
                else
                {
                 EmployeeDbContext.Employees.Add(employee);
                EmployeeDbContext.SaveChanges();
                }
           // }

            return RedirectToAction("GridView");
        }

        public IActionResult Delete(int id)
        {
            var employee = EmployeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                EmployeeDbContext.Employees.Remove(employee);
                EmployeeDbContext.SaveChanges();
            }

            return RedirectToAction("GridView");
        }

        public IActionResult GridView()
        {
            var employees = EmployeeDbContext.Employees.ToList(); // Ensure employees are fetched
            if (employees == null || !employees.Any())
            {
                // Handle case when no employees are available
                return View(new List<Employee>()); // Return an empty list instead of null
            }

            return View(employees); // Pass the list to the view
        }

        public IActionResult TotalSalary()
        {
            var totalSalary = EmployeeDbContext.Employees.Sum(e => e.Salary);
            return Json(totalSalary);
        }
    }
}
