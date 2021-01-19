using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class ChitietchuyenbayBLL
    {
        ChitietchuyenbayDAL dal = new ChitietchuyenbayDAL();
        public Chitietchuyenbay[] GetList()
        {
            return dal.GetList();
        }
        public Chitietchuyenbay[] GetListTheoMaChuyenBay(string id)
        {
            return dal.GetListTheoMaChuyenBay(id);
        }
        
        public bool Add(Chitietchuyenbay k)
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
        public bool Update(Chitietchuyenbay bs)
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
        public Chitietchuyenbay Search(string id)
        {
            return dal.Search(id);
        }
        public bool quyDinhThoiGianDungToiThieu(string a)
        {
            try
            {
                return dal.quyDinhThoiGianDungToiThieu(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool quyDinhThoiGianDungToiDa(string a)
        {
            try
            {
                return dal.quyDinhThoiGianDungToiDa(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Chitietchuyenbay getCTChuyenBayTail()
        {
            return dal.getCTChuyenBayTail();
        }
    }
}
