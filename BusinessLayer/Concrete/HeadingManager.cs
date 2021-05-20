using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void Delete(Heading heading)
        {
            throw new NotImplementedException();
        }

        public Heading GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public void Update(Heading heading)
        {
            throw new NotImplementedException();
        }
    }
}
