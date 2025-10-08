using IKEA.BLL.DTO.DepartmentDTO;
using IKEA.BLL.Factories;
using IKEA.DAL.Models.Department;
using IKEA.DAL.Repositories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IKEA.BLL.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var departments = _departmentRepository.GetAll()
                                .Where(d => !d.IsDeleted)
                                .ToList();

            return departments.Select(DepartmentFactory.ToDepartmentDto).ToList();
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetByID(id);
            if (department == null || department.IsDeleted)
                return null!;

            return DepartmentFactory.ToDepartmentDetailsDto(department);
        }

        public int AddDepartment(CreatedDepartmentDto dto)
        {
            var department = DepartmentFactory.ToEntity(dto);
            department.CreatedBy = 1;
            department.CreatedOn = DateTime.Now;
            department.LastModifiedBy = 1;
            department.LastModifiedOn = DateTime.Now;

            var result = _departmentRepository.Add(department);
            return result;
        }

        public int UpdateDepartment(UpdateDepartmentDto dto)
        {
            var department = _departmentRepository.GetByID(dto.Id);
            if (department == null || department.IsDeleted)
                return 0;

            DepartmentFactory.UpdateEntity(dto, department);
            department.LastModifiedBy = 1;
            department.LastModifiedOn = DateTime.Now;

            var result = _departmentRepository.Update(department);

            return result;
        }

        public int DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetByID(id);
            if (department == null || department.IsDeleted)
                return 0;

            department.IsDeleted = true;
            department.LastModifiedBy = 1;
            department.LastModifiedOn = DateTime.Now;

            var result = _departmentRepository.Update(department);

            return result;
        }
    }
}
