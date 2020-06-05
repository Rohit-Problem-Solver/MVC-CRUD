using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Threading.Tasks;

namespace CRIDinMVC.Controllers
{
    public class ModelOperationController : Controller
    {
        // GET: ModelOperation
        public async Task<ActionResult> Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                UpdateModel<Employee>(employee);
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
                ebl.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            else 

            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
            Employee employee = ebl.Employees.Single(emp => emp.ID == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
                ebl.SaveEmmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}