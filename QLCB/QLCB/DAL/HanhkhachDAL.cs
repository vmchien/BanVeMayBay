using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class HanhkhachDAL
    {
        DataHelper helper = new DataHelper();
        private Hanhkhach GetHanhkhachFromDataRow(DataRow row)
        {
            Hanhkhach k = new Hanhkhach();

            k.MAHANHKHACH = row["MAHANHKHACH"].ToString().Trim();
            k.TENHANHKHACH = row["TENHANHKHACH"].ToString().Trim();
            k.CMND = row["CMND"].ToString().Trim();
            k.DIENTHOAI = row["DIENTHOAI"].ToString().Trim();


            return k;
        }
        public Hanhkhach[] GetList()
        {
            Hanhkhach[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from HANHKHACH");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Hanhkhach[n];
            for (int i = 0; i < n; i++)
            {
                Hanhkhach s = GetHanhkhachFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Hanhkhach k)
        {
            string query = string.Format("INSERT INTO HANHKHACH values (N'{0}',N'{1}',N'{2}',N'{3}')", k.MAHANHKHACH, k.TENHANHKHACH, k.CMND, k.DIENTHOAI);

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
            string query = string.Format("DELETE FROM HANHKHACH WHERE MAHANHKHACH = (N'{0}')", id);

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
        public bool Update(Hanhkhach k)
        {
            string query = string.Format("UPDATE HANHKHACH SET TENHANHKHACH = (N'{0}'),CMND = (N'{1}'),DIENTHOAI = (N'{2}') WHERE MAHANHKHACH = (N'{3}')", k.TENHANHKHACH, k.CMND, k.DIENTHOAI, k.MAHANHKHACH);

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
        public Hanhkhach Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM HANHKHACH WHERE MAHANHKHACH = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Hanhkhach k = GetHanhkhachFromDataRow(table.Rows[0]);

            return k;
        }
        public Hanhkhach getHanhKhachTail()
        {
            Hanhkhach[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("SELECT TOP 1 * FROM HANHKHACH ORDER BY MAHANHKHACH DESC ");  // get all students
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Hanhkhach bs = GetHanhkhachFromDataRow(table.Rows[0]);

            return bs;
        }
    }
}
