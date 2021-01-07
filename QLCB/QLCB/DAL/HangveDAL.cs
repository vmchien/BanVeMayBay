using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class HangveDAL
    {
        DataHelper helper = new DataHelper();
        private Hangve GetHangveFromDataRow(DataRow row)
        {
            Hangve k = new Hangve();

            k.MAHANGVE = row["MAHANGVE"].ToString().Trim();
            k.TENHANGVE = row["TENHANGVE"].ToString().Trim();
            return k;
        }
        public Hangve[] GetList()
        {
            Hangve[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from HANGVE");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Hangve[n];
            for (int i = 0; i < n; i++)
            {
                Hangve s = GetHangveFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Hangve k)
        {
            string query = string.Format("INSERT INTO HANGVE values (N'{0}',N'{1}')", k.MAHANGVE,k.TENHANGVE);

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
            string query = string.Format("DELETE FROM HANGVE WHERE MAHANGVE = (N'{0}')", id);

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
        public bool Update(Hangve k)
        {
            string query = string.Format("UPDATE HANGVE SET TENHANGVE = (N'{0}') WHERE MAHANGVE = (N'{1}')", k.TENHANGVE,k.MAHANGVE);

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
        public Hangve Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM HANGVE WHERE MAHANGVE = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Hangve k = GetHangveFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
