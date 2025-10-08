using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.EmployeeRepo
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public IEnumerable<Employee> GetAll(bool withtracking = false);

        public Employee GetByID(int id);


        public int Add(Employee Employee);



        public int Update(Employee Employee);



        public int Delete(int id);

    }
}
