using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
           
            EmployeeDB emp = new EmployeeDB();
            List<Employee> empList = emp.GetEmployees();
            return View(empList);
        }


        public IActionResult create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDB emp = new EmployeeDB();
                    bool state = emp.AddEmployee(employee);

                    if (state == true)
                    {
                        TempData["insert"] = "Data Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View();
        }

        public IActionResult edit(int id)
        {
            EmployeeDB emp = new EmployeeDB();
            var employees =emp.GetEmployees().Find(x => x.Id == id);
            return View(employees);
        }

        [HttpPost]
        public IActionResult edit(int id,Employee employee)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDB emp = new EmployeeDB();
                    bool state = emp.updateEmployee(employee);

                    if (state == true)
                    {
                        TempData["update"] = "Data Update Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           

            return View();
        }

        public IActionResult delete(int id)
        {
            EmployeeDB emp = new EmployeeDB();
            var employee=emp.GetEmployees().Find(x => x.Id == id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult delete(int id,Employee employee)
        {

            try
            {
                    EmployeeDB emp = new EmployeeDB();
                    bool state = emp.deleteEmployee(employee);
                    if (state == true)
                    {
                        TempData["delete"] = "Data Deleted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return View();
        }
    }
}

