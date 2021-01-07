using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class TinhtrangveDAL
    {
        DataHelper helper = new DataHelper();
        private Tinhtrangve GetTinhtrangveFromDataRow(DataRow row)
        {
            Tinhtrangve k = new Tinhtrangve();

            k.MATINHTRANGVE = row["MATINHTRANGVE"].ToString().Trim();
            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.MAHANGVE = row["MAHANGVE"].ToString().Trim();
            k.SOGHETRONG = int.Parse(row["SOGHETRONG"].ToString().Trim());
            k.SOGHEDAT = int.Parse(row["SOGHEDAT"].ToString().Trim());

            return k;
        }
        public Tinhtrangve[] GetList()
        {
            Tinhtrangve[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from TINHTRANGVE");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Tinhtrangve[n];
            for (int i = 0; i < n; i++)
            {
                Tinhtrangve s = GetTinhtrangveFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Tinhtrangve k)
        {
            string query = string.Format("INSERT INTO TINHTRANGVE values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", k.MATINHTRANGVE, k.MACHUYENBAY, k.MAHANGVE, k.SOGHETRONG, k.SOGHEDAT);

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
            string query = string.Format("DELETE FROM TINHTRANGVE WHERE MATINHTRANGVE = (N'{0}')", id);

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
        public bool Update(Tinhtrangve k)
        {
            string query = string.Format("UPDATE TINHTRANGVE SET MACHUYENBAY = (N'{0}'),MAHANGVE = (N'{1}'),SOGHETRONG = (N'{2}'),SOGHEDAT = (N'{3}') WHERE MATINHTRANGVE = (N'{4}')", k.MACHUYENBAY, k.MAHANGVE, k.SOGHETRONG, k.SOGHEDAT, k.MATINHTRANGVE);

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
        public Tinhtrangve Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM TINHTRANGVE WHERE MATINHTRANGVE = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Tinhtrangve k = GetTinhtrangveFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
