using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();

        void Add(Heading heading);

        void Delete(Heading heading);

        void Update(Heading heading);

        Heading GetByID(int id);
    }
}
