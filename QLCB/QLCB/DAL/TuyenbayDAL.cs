using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class TuyenbayDAL
    {
        DataHelper helper = new DataHelper();
        private Tuyenbay GetTuyenbayFromDataRow(DataRow row)
        {
            Tuyenbay k = new Tuyenbay();

            k.MATUYENBAY = row["MATUYENBAY"].ToString().Trim();
            k.SANBAYDI = row["SANBAYDI"].ToString().Trim();
            k.SANBAYDEN = row["SANBAYDEN"].ToString().Trim();

            return k;
        }
        public Tuyenbay[] GetList()
        {
            Tuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from TUYENBAY");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Tuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Tuyenbay s = GetTuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Tuyenbay k)
        {
            string query = string.Format("INSERT INTO TUYENBAY values (N'{0}',N'{1}',N'{2}')", k.MATUYENBAY, k.SANBAYDI, k.SANBAYDEN);

            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(string id)
        {
            string query = string.Format("DELETE FROM TUYENBAY WHERE MATUYENBAY = (N'{0}')", id);

            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(Tuyenbay k)
        {
            string query = string.Format("UPDATE TUYENBAY SET SANBAYDI = (N'{0}'), SANBAYDEN = (N'{1}')  WHERE MATUYENBAY = (N'{2}')", k.SANBAYDI, k.SANBAYDEN, k.MATUYENBAY);

            try
            {
                helper.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tuyenbay Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM TUYENBAY WHERE MATUYENBAY = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Tuyenbay k = GetTuyenbayFromDataRow(table.Rows[0]);

            return k;
        }
        public Tuyenbay SearchTheoYC(string sanBayDi, string sanBayDen)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM TUYENBAY WHERE SANBAYDI = (N'{0}') and SANBAYDEN = (N'{1}')", sanBayDi, sanBayDen);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Tuyenbay k = GetTuyenbayFromDataRow(table.Rows[0]);

            return k;
        }
        public Tuyenbay[] SearchTheoMaSB(string id)
        {
            Tuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM TUYENBAY WHERE SANBAYDI = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Tuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Tuyenbay s = GetTuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }

        public Tuyenbay getTuyenBayTail()
        {
            Tuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("SELECT TOP 1 * FROM TUYENBAY ORDER BY MATUYENBAY DESC ");  // get all students
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Tuyenbay bs = GetTuyenbayFromDataRow(table.Rows[0]);

            return bs;
        }
    }
}
