using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Department;
using IKEA.DAL.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IKEA.DAL.Repositories.DepartmentRepo
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbcontext _context;
        public DepartmentRepository(ApplicationDbcontext context) : base(context)
        {
            _context = context;
        }

        //public List<Department> GetAll()
        //{
        //    return _context.Departments.ToList();
        //}

        //public Department? GetById(int id)
        //{
        //    return _context.Departments.Find(id);
        //}

        //public void Add(Department department)
        //{
        //    _context.Departments.Add(department);
        //}

        //public void Update(Department department)
        //{
        //    _context.Departments.Update(department);
        //}

        //public void Delete(Department department)
        //{
        //    _context.Departments.Remove(department);
        //}

        //public void SaveChanges()
        //{
        //    _context.SaveChanges();
        //}
    }
}
