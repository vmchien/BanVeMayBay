﻿using QLCB.DAL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.BLL
{
    class VechuyenbayBLL
    {
        VechuyenbayDAL dal = new VechuyenbayDAL();
        public Vechuyenbay[] GetList()
        {
            return dal.GetList();
        }
        public bool Add(Vechuyenbay k)
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
        public bool Update(Vechuyenbay bs)
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
        public Vechuyenbay Search(string id)
        {
            return dal.Search(id);
        }
        public Vechuyenbay getVeTail()
        {
            return dal.getVeTail();
        }
    }
}
