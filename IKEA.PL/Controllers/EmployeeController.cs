using AutoMapper;
using IKEA.BLL.DTO.EmployeeDto_s;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Shared;
using IKEA.PL.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Services Injection && Error Handling

        private readonly IEmployeeServices _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _webHost;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeServices employeeService, ILogger<EmployeeController> logger, IWebHostEnvironment webHost, IMapper mapper)
        {
            _employeeService = employeeService;
            _logger = logger;
            _webHost = webHost;
            _mapper = mapper;
        }

        #endregion

        #region Show All Employees

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployee();
            return View(employees);
        }

        #endregion

        #region Show Employee Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            var viewModel = _mapper.Map<EmployeeDetailsDto>(employee);

            return View(viewModel);
        }


        #endregion

        #region Employee Creation

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var createDto = _mapper.Map<CreateEmployeeDto>(dto);

            _employeeService.AddEmployee(createDto);

            return RedirectToAction("Index");
        }
        #endregion

        #region Employee Update

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            var model = _mapper.Map<EmployeeDetailsDto>(employee);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, EmployeeDetailsDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var dto = _mapper.Map<UpdateEmployeeDto>(model);
                int result = _employeeService.UpdateEmployee(dto);

                if (result > 0)
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, "Employee could not be updated.");
                return View(model);
            }
            catch (Exception ex)
            {
                if (_webHost.IsDevelopment())
                {
                    _logger.LogError(ex.Message);
                    return View(model);
                }
                throw;
            }
        }
        #endregion

        #region Employee Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = _employeeService.DeleteEmployee(id);

                if (result > 0)
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, "Employee could not be deleted.");
                return View();
            }
            catch (Exception ex)
            {
                if (_webHost.IsDevelopment())
                    _logger.LogError(ex.Message);
                else
                    throw;

                return View();
            }
        }

        #endregion
    }
}
