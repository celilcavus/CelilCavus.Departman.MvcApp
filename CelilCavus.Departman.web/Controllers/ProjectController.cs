using CelilCavus.Departman.Context.Contexts;
using CelilCavus.Departman.Entity.Entity;
using CelilCavus.Departman.Model.UnitOfWork;
using CelilCavus.Departman.Validation.Validatior;
using System.Linq;
using System.Web.Mvc;

namespace CelilCavus.Departman.web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UnitOfDWork _work;
        private readonly ApplicationContextDb _context;
        private ProjectValidatior ValidationRules = new ProjectValidatior();
        public ProjectController()
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
        public ActionResult Index(Project project)
        {
            if (project is null) { return new EmptyResult(); }

            var values = ValidationRules.Validate(project);
            if (values.IsValid)
            {
                _work.GetRepository<Project>().Add(project);
                _work.SaveChanges();
            }
            else
            {
                foreach (var item in values.Errors)
                {
                    ViewBag.Valid = true;
                    ViewBag.ErrorMessage = item.ErrorMessage;
                }
            }
            return View();
        }
        public PartialViewResult PartialGetProjectList()
        {
            var values = _work.GetRepository<Project>().GetList();
            var val =
            values is null ?
            PartialView("_PartialGetProjectList", Enumerable.Empty<Project>()) :
            PartialView("_PartialGetProjectList", values);

            return val;

        }
        [HttpGet]
        public ActionResult PutProject(int? id)
        {
            var NullOrEmpty = id ?? 0;
            if (NullOrEmpty >= 1)
            {
                var returnValue = _work.GetRepository<Project>().GetById(NullOrEmpty);
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
        public ActionResult PutProject(Project project)
        {
            if (project is null) { return new EmptyResult(); }

            var validatiorResult = ValidationRules.Validate(project);
            if (validatiorResult.IsValid)
            {
                var returnUpdateValue = _work.GetRepository<Project>().GetById(project.Id);
                returnUpdateValue.ProjectName = project.ProjectName;
                returnUpdateValue.ProjectStartDate = project.ProjectStartDate;
                returnUpdateValue.ProjectEndDate = project.ProjectEndDate;
                _work.SaveChanges();
                return RedirectToAction("Index", "Project");
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
        public ActionResult DeleteProject(int? id)
        {
            var NullOrEmpty = id ?? 0;
            if (NullOrEmpty >= 1)
            {
                var returnValue = _work.GetRepository<Project>().GetById(NullOrEmpty);
                if (returnValue is null)
                {
                    return HttpNotFound("Geçersiz");
                }
                else
                {
                    _work.GetRepository<Project>().Remove(returnValue);
                    _work.SaveChanges();
                    return RedirectToAction("Index", "Project");
                }

            }
            else
                return HttpNotFound("Geçersiz Idi Parametresi");
        }
    }
}