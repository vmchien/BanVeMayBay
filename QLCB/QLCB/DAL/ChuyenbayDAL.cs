using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class ChuyenbayDAL
    {
        DataHelper helper = new DataHelper();
        private Chuyenbay GetChuyenbayFromDataRow(DataRow row)
        {
            Chuyenbay k = new Chuyenbay();

            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.MATUYENBAY = row["MATUYENBAY"].ToString().Trim();
            k.NGAYGIO = row["NGAYGIO"].ToString().Trim();
            k.THOIGIANBAY = int.Parse(row["THOIGIANBAY"].ToString().Trim());
            k.SOLUONGGHEHANG1 = int.Parse(row["SOLUONGGHEHANG1"].ToString().Trim());
            k.SOLUONGGHEHANG2 = int.Parse(row["SOLUONGGHEHANG2"].ToString().Trim());


            return k;
        }
        public Chuyenbay[] GetList()
        {
            Chuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from CHUYENBAY");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Chuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Chuyenbay s = GetChuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Chuyenbay k)
        {
            string query = string.Format("INSERT INTO CHUYENBAY values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", k.MACHUYENBAY, k.MATUYENBAY, k.NGAYGIO, k.THOIGIANBAY, k.SOLUONGGHEHANG1, k.SOLUONGGHEHANG2);

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
            string query = string.Format("DELETE FROM CHUYENBAY WHERE MACHUYENBAY = (N'{0}')", id);

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
        public bool Update(Chuyenbay k)
        {
            string query = string.Format("UPDATE CHUYENBAY SET MATUYENBAY = (N'{0}'),NGAYGIO = (N'{1}'),THOIGIANBAY = (N'{2}'),SOLUONGGHEHANG1 = (N'{3}'),SOLUONGGHEHANG2 = (N'{4}') WHERE MACHUYENBAY = (N'{5}')", k.MATUYENBAY, k.NGAYGIO, k.THOIGIANBAY, k.SOLUONGGHEHANG1, k.SOLUONGGHEHANG2,k.MACHUYENBAY);

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
        public Chuyenbay Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM CHUYENBAY WHERE MACHUYENBAY = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Chuyenbay k = GetChuyenbayFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
