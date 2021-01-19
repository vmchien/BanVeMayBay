using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class ChuyenbayBLL
    {
        ChuyenbayDAL dal = new ChuyenbayDAL();
        public Chuyenbay[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Chuyenbay k)
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
        public bool Update(Chuyenbay bs)
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
        public Chuyenbay Search(string id)
        {
            return dal.Search(id);
        }
        public Chuyenbay getChuyenBayTail()
        {
            return dal.getChuyenBayTail();
        }
        public Chuyenbay[] SearchTuyenBay(string id)
        {
            return dal.SearchTuyenBay(id);
        }
        public bool quyDinhThoiGianBayToiThieu(string a)
        {
            try
            {
                return dal.quyDinhThoiGianBayToiThieu(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
