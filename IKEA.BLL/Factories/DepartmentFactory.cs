using IKEA.BLL.DTO.DepartmentDTO;
using IKEA.DAL.Models.Department;

namespace IKEA.BLL.Factories
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(Department department)
        {
            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy
            };
        }

        public static Department ToEntity(CreatedDepartmentDto dto)
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            return new Department
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedBy = 1,
                CreatedOn = DateTime.Today,
                LastModifiedBy = 1
            };
        }

        public static void UpdateEntity(IUpdateDepartmentDto dto, Department department)
        {
            department.Name = dto.Name;
            department.Code = dto.Code;
            department.Description = dto.Description;
            department.LastModifiedBy = 1;
        }
    }
}
