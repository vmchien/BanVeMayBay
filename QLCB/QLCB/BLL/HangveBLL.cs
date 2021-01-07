using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class HangveBLL
    {
        HangveDAL dal = new HangveDAL();
        public Hangve[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Hangve k)
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
        public bool Update(Hangve bs)
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
        public Hangve Search(string id)
        {
            return dal.Search(id);
        }
    }
}
