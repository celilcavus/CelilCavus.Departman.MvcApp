using CelilCavus.Departman.Entity.Entity;
using CelilCavus.Departman.Validation.Validatior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CelilCavus.Departman.Model.UnitOfWork;
using CelilCavus.Departman.Context.Contexts;
using System.Xml;

namespace CelilCavus.Departman.web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeValidatior Employeevalid = new EmployeeValidatior();
        private readonly UnitOfDWork _work;
        private readonly ApplicationContextDb _context;

        public EmployeeController()
        {
            _context = new ApplicationContextDb();
            _work = new UnitOfDWork(_context);
        }
        private void GetDepartman()
        {
            List<SelectListItem> departmen = (from x in _work.GetRepository<Department>().GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanName,
                                                  Value = x.Id.ToString()
                                              }).ToList();

            ViewBag.departmanList = departmen;
        }
        private void GetProject()
        {
            List<SelectListItem> project = (from x in _work.GetRepository<Project>().GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProjectName,
                                                Value = x.Id.ToString()
                                            }).ToList();
            ViewBag.projectList = project;
        }

        [HttpGet]
        public ActionResult Index()
        {
            GetDepartman();
            GetProject();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            if (employee is null) { return new EmptyResult(); }
            var employeeValidate = Employeevalid.Validate(employee);
            if (employeeValidate.IsValid)
            {
                employee.DepartmanId = int.Parse(employee.DepartmanId.ToString());
                employee.ProjectId = int.Parse(employee.ProjectId.ToString());
                _work.GetRepository<Employee>().Add(employee);
                _work.SaveChanges();

            }
            else
            {
                foreach (var item in employeeValidate.Errors)
                {
                    ViewBag.Valid = true;
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public PartialViewResult EmployeeGetPartialList()
        {
            var values = _work.GetRepository<Employee>().GetList();
            var val = values is null ?
            PartialView("_EmployeeGetPartialList", Enumerable.Empty<Employee>()) :
            PartialView("_EmployeeGetPartialList", values);
            return val;
        }
        [HttpGet]
        public ActionResult PutEmployee(int? id)
        {
            GetDepartman();
            GetProject();
            var NullOrEmpty = id ?? 0;
            if (NullOrEmpty >= 1)
            {
                var returnValue = _work.GetRepository<Employee>().GetById(NullOrEmpty);
                if (returnValue is null)
                {
                    return HttpNotFound("Geçersiz");
                }
                else
                {
                    return View(returnValue);
                }

            }
            return HttpNotFound("Geçersiz Idi Parametresi");
        }
        [HttpPost]
        public ActionResult PutEmployee(Employee employee)
        {
            GetDepartman();
            GetProject();
            if (employee is null) { return new EmptyResult(); }

            var validatiorResult = Employeevalid.Validate(employee);
            if (validatiorResult.IsValid)
            {
                var returnUpdateValue = _work.GetRepository<Employee>().GetById(employee.Id);
                returnUpdateValue.Name = employee.Name;
                returnUpdateValue.LastName = employee.LastName;
                returnUpdateValue.PhoneNo = employee.PhoneNo;
                returnUpdateValue.Salary = employee.Salary;
                returnUpdateValue.JobTitle = employee.JobTitle;
                returnUpdateValue.DepartmanId = employee.DepartmanId;
                returnUpdateValue.ProjectId = employee.ProjectId;
                _work.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                foreach (var item in validatiorResult.Errors)
                {
                    ViewBag.Valid = true;
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
           
            return View();
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int? id)
        {
            var NullOrEmpty = id ?? 0;
            if (NullOrEmpty >= 1)
            {
                var returnValue = _work.GetRepository<Employee>().GetById(NullOrEmpty);
                if (returnValue is null)
                {
                    return HttpNotFound("Geçersiz");
                }
                else
                {
                    _work.GetRepository<Employee>().Remove(returnValue);
                    _work.SaveChanges();
                    return RedirectToAction("Index", "Employee");
                }

            }
            else
                return HttpNotFound("Geçersiz Idi Parametresi");
        }
    }
}