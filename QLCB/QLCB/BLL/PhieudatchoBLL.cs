using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class PhieudatchoBLL
    {

        PhieudatchoDAL dal = new PhieudatchoDAL();
        public Phieudatcho[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Phieudatcho k)
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
        public bool Update(Phieudatcho bs)
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
        public Phieudatcho Search(string id)
        {
            return dal.Search(id);
        }
    }
}
