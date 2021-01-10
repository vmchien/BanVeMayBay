using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class TuyenbayBLL
    {
        TuyenbayDAL dal = new TuyenbayDAL();
        public Tuyenbay[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Tuyenbay k)
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
        public bool Update(Tuyenbay bs)
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
        public Tuyenbay Search(string id)
        {
            return dal.Search(id);
        }
        public Tuyenbay getTuyenBayTail()
        {
            return dal.getTuyenBayTail();
        }
        public Tuyenbay[] SearchTheoMaSB(string id)
        {
            return dal.SearchTheoMaSB(id);
        }
        
    }
}
