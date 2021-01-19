using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class DongiaBLL
    {
        DongiaDAL dal = new DongiaDAL();
        public Dongia[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Dongia k)
        {
            try
            {
                return dal.Add(k);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(string id)
        {
            try
            {
                return dal.Remove(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Dongia bs)
        {
            try
            {
                return dal.Update(bs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dongia Search(string id,string mahv)
        {
            return dal.Search(id, mahv);
        }
        public Dongia getDonGiaTail()
        {
            return dal.getDonGiaTail();
        }
    }
}
