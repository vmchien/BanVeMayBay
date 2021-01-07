using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class SanbayDAL
    {
        DataHelper helper = new DataHelper();
        private Sanbay GetSanbayFromDataRow(DataRow row)
        {
            Sanbay k = new Sanbay();

            k.MASANBAY = row["MASanbay"].ToString().Trim();
            k.TENSANBAY = row["TENSanbay"].ToString().Trim();
            return k;
        }
        public Sanbay[] GetList()
        {
            Sanbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from SANBAY");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Sanbay[n];
            for (int i = 0; i < n; i++)
            {
                Sanbay s = GetSanbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Sanbay k)
        {
            string query = string.Format("INSERT INTO SANBAY values (N'{0}',N'{1}')", k.MASANBAY, k.TENSANBAY);

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
            string query = string.Format("DELETE FROM SANBAY WHERE MASANBAY = (N'{0}')", id);

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
        public bool Update(Sanbay k)
        {
            string query = string.Format("UPDATE SANBAY SET TENSANBAY = (N'{0}')  WHERE MASANBAY = (N'{1}')", k.TENSANBAY, k.MASANBAY);

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
        public Sanbay Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM SANBAY WHERE MASANBAY = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Sanbay k = GetSanbayFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
