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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(a => a.AdminID == id);
        }

        //public Admin GetByUserName(string userName)
        //{
        //    return _adminDal.Get(a => a.AdminUserName == userName);
        //}

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
