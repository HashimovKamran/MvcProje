using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    class CategoryRepository : ICategoryDal
    {

        Context context = new Context();
        DbSet<Category> _object;

        public void Delete(Category entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public void Insert(Category entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            context.SaveChanges();
        }
    }
}
