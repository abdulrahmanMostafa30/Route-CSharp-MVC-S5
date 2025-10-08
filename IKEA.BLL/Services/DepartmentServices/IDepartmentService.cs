using IKEA.BLL.DTO.DepartmentDTO;
using System.Collections.Generic;

namespace IKEA.BLL.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartment();

        public DepartmentDetailsDto GetDepartmentById(int id);

        public int AddDepartment(CreatedDepartmentDto dto);

        public int UpdateDepartment(UpdateDepartmentDto dto);

        public int DeleteDepartment(int id);
    }
}
