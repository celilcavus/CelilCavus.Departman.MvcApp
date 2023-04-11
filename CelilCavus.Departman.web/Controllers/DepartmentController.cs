using CelilCavus.Departman.Context.Contexts;
using CelilCavus.Departman.Entity.Entity;
using CelilCavus.Departman.Model.UnitOfWork;
using CelilCavus.Departman.Validation.Validatior;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;


namespace CelilCavus.Departman.web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly UnitOfDWork _work;
        private readonly ApplicationContextDb _context;
        private DepartmentValidator validatior = new DepartmentValidator();

        public DepartmentController()
        {
            _context = new ApplicationContextDb();
            _work = new UnitOfDWork(_context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Department department)
        {
            if (department is null) { return new EmptyResult(); }

            var validationResult = validatior.Validate(department);
            if (validationResult.IsValid)
            {
                if (!string.IsNullOrEmpty(department.ToString()))
                {
                    _work.GetRepository<Department>().Add(department);
                    _work.SaveChanges();
                    return RedirectToAction("Index", "Department");
                }
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    //ModelState.AddModelError("error", item.ErrorMessage);
                    ViewBag.Valid = true;
                    ViewBag.Errormessage = item.ErrorMessage;
                }
                
            }
            return View();
        }

        public PartialViewResult PartialGetDepartmentList()
        {
            var GetListValues = _work.GetRepository<Department>().GetList();
            return PartialView("_PartialDepartmentGetList", GetListValues);
        }


        [HttpGet]
        public ActionResult PutDepartment(int? id)
        {
            int? NullId = id ?? 0;
            if (NullId is null) { return new EmptyResult(); }

            var ReturnValue = _work.GetRepository<Department>().GetById(id);
            if (ReturnValue is null) { Enumerable.Empty<Department>(); }

            return View(ReturnValue);
        }
        [HttpPost]
        public ActionResult PutDepartment(Department department)
        {
            if (department is null) { return new EmptyResult(); }
            var validatiorResult = validatior.Validate(department);
            if (validatiorResult.IsValid)
            {
                if (!string.IsNullOrEmpty(department.ToString()))
                {
                    var ReturnValue = _work.GetRepository<Department>().GetById(department.Id);
                    ReturnValue.DepartmanName = department.DepartmanName;
                    _work.SaveChanges();
                    return RedirectToAction("Index", "Department");
                }
            }
            else
            {
                foreach (var item in validatiorResult.Errors)
                {
                    ViewBag.Valid = true;
                    ViewBag.Errormessage = item.ErrorMessage;
                }
            }
          
            return View();
        }
        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            var ReturnValue = _work.GetRepository<Department>().GetById(id);
            _work.GetRepository<Department>().Remove(ReturnValue);
            _work.SaveChanges();
            return RedirectToAction("Index", "Department");
        }



    }
}