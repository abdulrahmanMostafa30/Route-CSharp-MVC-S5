using IKEA.BLL.DTO.EmployeeDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployee();

        public EmployeeDetailsDto GetEmployeeById(int id);


        public int AddEmployee(CreateEmployeeDto dto);


        public int UpdateEmployee(UpdateEmployeeDto dto);


        public int DeleteEmployee(int id);
    }
}
