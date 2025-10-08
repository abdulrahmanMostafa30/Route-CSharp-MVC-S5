using IKEA.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : ModelBase
    {
        public IEnumerable<TEntity> GetAll(bool withtracking = false);

        public TEntity GetByID(int id);

        public int Add(TEntity entity);

        public int Update(TEntity entity);

        public int Delete(int id);

    }
}
