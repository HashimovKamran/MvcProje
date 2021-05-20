using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface ICategoryService
    {
        List<Category> GetList();

        void Add(Category category);

        void Delete(Category category);

        void Update(Category category);

        Category GetByID(int id);
    }
}
