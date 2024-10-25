using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        Repository<Admin> repoblog = new Repository<Admin>();

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public Admin GetByID(int id)
        {
            return _adminDal.GetByID(id);
        }
        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public void TAdd(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
