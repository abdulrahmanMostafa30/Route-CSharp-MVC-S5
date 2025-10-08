using IKEA.DAL.Models.Department;
using IKEA.DAL.Repositories.GenericRepo;
using System.Collections.Generic;

namespace IKEA.DAL.Repositories.DepartmentRepo
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public IEnumerable<Department> GetAll(bool withtracking = false);
        public Department GetByID(int id);
        public int Add(Department department);
        public int Update(Department department);
        public int Delete(int id);

    }
}
