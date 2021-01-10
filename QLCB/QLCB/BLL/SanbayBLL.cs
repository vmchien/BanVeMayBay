﻿using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class SanbayBLL
    {
        SanbayDAL dal = new SanbayDAL();
        public Sanbay[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Sanbay k)
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
        public bool Update(Sanbay bs)
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
        public Sanbay Search(string id)
        {
            return dal.Search(id);
        }
        public Sanbay SearchTheoTen(string id)
        {
            return dal.SearchTheoTen(id);
        }
    }
}
