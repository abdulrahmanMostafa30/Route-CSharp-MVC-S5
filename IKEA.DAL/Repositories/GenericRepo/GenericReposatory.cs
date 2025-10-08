using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ModelBase
    {
        private readonly ApplicationDbcontext _context;

        public GenericRepository(ApplicationDbcontext context)
        {

            this._context = context;
        }

        public IEnumerable<TEntity> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _context.Set<TEntity>().ToList();
            }
            else { return _context.Set<TEntity>().AsNoTracking().ToList(); }

        }

        public TEntity GetByID(int id)
        {
            var result = _context.Set<TEntity>().Find(id);
            return result;
        }


        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var resultDEL = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(resultDEL);
            return _context.SaveChanges();
        }

    }
}
