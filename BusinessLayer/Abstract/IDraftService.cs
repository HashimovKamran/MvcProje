using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetList();

        void Add(Draft draft);

        void Delete(Draft draft);

        void Update(Draft draft);

        Draft GetByID(int id);
    }
}
