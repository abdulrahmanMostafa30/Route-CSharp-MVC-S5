using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.EmployeeRepo
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbcontext _context;
        public EmployeeRepository(ApplicationDbcontext context) : base(context)
        {
            _context = context;
        }
    }
}
