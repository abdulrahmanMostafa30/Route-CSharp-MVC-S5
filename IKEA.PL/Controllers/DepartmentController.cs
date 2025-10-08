using IKEA.BLL.Services.DepartmentServices;
using IKEA.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartment() ?? new List<DepartmentDto>();
            return View(departments);
        }


        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return View(department);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(DepartmentEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _departmentService.AddDepartment(new CreatedDepartmentDto
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description
            });

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null) return NotFound();

            var model = new DepartmentEditViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _departmentService.UpdateDepartment(new UpdateDepartmentDto
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description
            });

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }

    public static class DateOnlyExtensions
    {
        public static DateOnly ToDateOnly(this DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }
    }
}
