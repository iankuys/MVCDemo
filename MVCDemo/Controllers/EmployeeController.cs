namespace MVCDemo.Controllers
{
    using MVCDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using bs = BusinessLayer;

    public class EmployeeController : Controller
    {
        public ActionResult Index(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employee = employeeContext.Employees.Where(emp => emp.DepartmentId == id).ToList();
            return View(employee);
        }

        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = new Employee();
            employee = employeeContext.Employees.FirstOrDefault(emp => emp.EmployeeId == id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {

            bs.Employee employee = new bs.Employee();
            //Retrieve form data using form collection
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth =
                Convert.ToDateTime(formCollection["DateOfBirth"]);

            bs.EmployeeBusinessLayer employeeBusinessLayer =
                new bs.EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index", "Home");
        }
    }
}