using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();

        void Add(Admin admin);

        void Delete(Admin admin);

        void Update(Admin admin);

        //Admin GetByUserName(string userName);

        Admin GetByID(int id);
    }
}
