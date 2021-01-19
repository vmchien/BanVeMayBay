using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class VechuyenbayDAL
    {
        DataHelper helper = new DataHelper();
        private Vechuyenbay GetVechuyenbayFromDataRow(DataRow row)
        {
            Vechuyenbay k = new Vechuyenbay();

            k.MAVE = row["MAVE"].ToString().Trim();
            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.MAHANGVE = row["MAHANGVE"].ToString().Trim();
            k.MAHANHKHACH = row["MAHANHKHACH"].ToString().Trim();
            k.GIATIEN = float.Parse(row["GIATIEN"].ToString().Trim());


            return k;
        }
        public Vechuyenbay[] GetList()
        {
            Vechuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from VECHUYENBAY");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Vechuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Vechuyenbay s = GetVechuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Vechuyenbay k)
        {
            string query = string.Format("INSERT INTO VECHUYENBAY values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", k.MAVE, k.MACHUYENBAY, k.MAHANGVE, k.MAHANHKHACH, k.GIATIEN);

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
            string query = string.Format("DELETE FROM VECHUYENBAY WHERE MAVE = (N'{0}')", id);

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
        public bool Update(Vechuyenbay k)
        {
            string query = string.Format("UPDATE VECHUYENBAY SET MACHUYENBAY = (N'{0}'),MAHANGVE = (N'{1}'),MAHANHKHACH = (N'{2}'),GIATIEN = (N'{3}') WHERE MAVE = (N'{4}')", k.MACHUYENBAY, k.MAHANGVE, k.MAHANHKHACH, k.GIATIEN, k.MAVE);

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
        public Vechuyenbay Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM VECHUYENBAY WHERE MAVE = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Vechuyenbay k = GetVechuyenbayFromDataRow(table.Rows[0]);

            return k;
        }
        public Vechuyenbay getVeTail()
        {
            Vechuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("SELECT TOP 1 * FROM VECHUYENBAY ORDER BY MAVE DESC  ");  // get all students
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Vechuyenbay bs = GetVechuyenbayFromDataRow(table.Rows[0]);

            return bs;
        }
        
    }
}
