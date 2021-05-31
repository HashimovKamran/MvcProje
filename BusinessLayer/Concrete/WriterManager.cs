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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(w => w.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
