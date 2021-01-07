using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class ChitietdoanhthuthangDAL
    {
        DataHelper helper = new DataHelper();
        private Chitietdoanhthuthang GetChitietdoanhthuthangFromDataRow(DataRow row)
        {
            Chitietdoanhthuthang k = new Chitietdoanhthuthang();

            k.MACTDOANHTHUTHANG = row["MACTDOANHTHUTHANG"].ToString().Trim();
            k.MADOANHTHUTHANG = row["MADOANHTHUTHANG"].ToString().Trim();
            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.SOVE = int.Parse(row["SOVE"].ToString().Trim());
            k.TYLE = int.Parse(row["TYLE"].ToString().Trim());
            k.DOANHTHU = float.Parse(row["DOANHTHU"].ToString().Trim());


            return k;
        }
        public Chitietdoanhthuthang[] GetList()
        {
            Chitietdoanhthuthang[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from CT_DOANHTHUTHANG");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Chitietdoanhthuthang[n];
            for (int i = 0; i < n; i++)
            {
                Chitietdoanhthuthang s = GetChitietdoanhthuthangFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Chitietdoanhthuthang k)
        {
            string query = string.Format("INSERT INTO CT_DOANHTHUTHANG values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", k.MACTDOANHTHUTHANG, k.MADOANHTHUTHANG, k.MACHUYENBAY, k.SOVE, k.TYLE, k.DOANHTHU);

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
            string query = string.Format("DELETE FROM CT_DOANHTHUTHANG WHERE MACTDOANHTHUTHANG = (N'{0}')", id);

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
        public bool Update(Chitietdoanhthuthang k)
        {
            string query = string.Format("UPDATE CT_DOANHTHUTHANG SET MADOANHTHUTHANG = (N'{0}'),MACHUYENBAY = (N'{1}'),SOVE = (N'{2}'),TYLE = (N'{3}'),DOANHTHU = (N'{4}') WHERE MACTDOANHTHUTHANG = (N'{5}')", k.MADOANHTHUTHANG, k.MACHUYENBAY, k.SOVE, k.TYLE, k.DOANHTHU, k.MACTDOANHTHUTHANG);

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
        public Chitietdoanhthuthang Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM CT_DOANHTHUTHANG WHERE MACTDOANHTHUTHANG = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Chitietdoanhthuthang k = GetChitietdoanhthuthangFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
