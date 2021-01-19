using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class DoanhthuthangBLL
    {
        DoanhthuthangDAL dal = new DoanhthuthangDAL();
        public Doanhthuthang[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Doanhthuthang k)
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
        public bool Update(Doanhthuthang bs)
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
        public Doanhthuthang Search(string id)
        {
            return dal.Search(id);
        }
        public Doanhthuthang SearchNamThang(string thang, string nam)
        {
            return dal.SearchNamThang(thang, nam);
        }
    }
}
