using AutoMapper;
using IKEA.BLL.DTO.EmployeeDto_s;
using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _Repository;
        private readonly IMapper mapper;

        public EmployeeServices(IEmployeeRepository Repository, IMapper mapper)

        {

            this._Repository = Repository;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployee()
        {
            try
            {
                return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_Repository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping error: {ex.InnerException?.Message}", ex);
            }
        }
        public EmployeeDetailsDto GetEmployeeById(int id)

            => mapper.Map<Employee, EmployeeDetailsDto>(_Repository.GetByID(id));

        public int AddEmployee(CreateEmployeeDto dto)
        {
            var emp = mapper.Map<CreateEmployeeDto, Employee>(dto);
            emp.CreatedBy = 1;
            emp.CreatedOn = DateTime.Now;
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;
            return _Repository.Add(emp);

        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            var emp = mapper.Map<UpdateEmployeeDto, Employee>(dto);
            emp.LastModifiedBy = 1;
            emp.LastModifiedOn = DateTime.Now;
            return _Repository.Update(emp);

        }
        public int DeleteEmployee(int id)
        {
            if (id != null)
            {
                return _Repository.Delete(id);
            }
            else
            { return 0; }
        }
    }
}
