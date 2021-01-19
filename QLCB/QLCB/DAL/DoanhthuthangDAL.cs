using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class DoanhthuthangDAL
    {
        DataHelper helper = new DataHelper();
        private Doanhthuthang GetDoanhthuthangFromDataRow(DataRow row)
        {
            Doanhthuthang k = new Doanhthuthang();

            k.MADOANHTHUTHANG = row["MADOANHTHUTHANG"].ToString().Trim();
            k.MADOANHTHUNAM = row["MADOANHTHUNAM"].ToString().Trim();
            k.THANG = int.Parse(row["THANG"].ToString().Trim());
            k.SOCHUYENBAY = int.Parse(row["SOCHUYENBAY"].ToString().Trim());
            k.TYLE = int.Parse(row["TYLE"].ToString().Trim());
            k.TONGDOANHTHUTHANG = float.Parse(row["TONGDOANHTHUTHANG"].ToString().Trim());

            return k;
        }
        public Doanhthuthang[] GetList()
        {
            Doanhthuthang[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from DOANHTHUTHANG");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Doanhthuthang[n];
            for (int i = 0; i < n; i++)
            {
                Doanhthuthang s = GetDoanhthuthangFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Doanhthuthang k)
        {
            string query = string.Format("INSERT INTO DOANHTHUTHANG values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", k.MADOANHTHUTHANG, k.THANG, k.MADOANHTHUNAM, k.SOCHUYENBAY, k.TYLE, k.TONGDOANHTHUTHANG);

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
            string query = string.Format("DELETE FROM DOANHTHUTHANG WHERE MADOANHTHUTHANG = (N'{0}')", id);

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
        public bool Update(Doanhthuthang k)
        {
            string query = string.Format("UPDATE DOANHTHUTHANG SET THANG = (N'{0}'),MADOANHTHUNAM = (N'{1}'),SOCHUYENBAY = (N'{2}'),TYLE = (N'{3}'),TONGDOANHTHUTHANG = (N'{4}') WHERE MADOANHTHUTHANG = (N'{5}')", k.THANG, k.MADOANHTHUNAM, k.SOCHUYENBAY, k.TYLE,k.TONGDOANHTHUTHANG,k.MADOANHTHUTHANG);

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
        public Doanhthuthang Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM DOANHTHUTHANG WHERE MADOANHTHUTHANG = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Doanhthuthang k = GetDoanhthuthangFromDataRow(table.Rows[0]);

            return k;
        }
        public Doanhthuthang SearchNamThang(string thang, string nam)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("select * from DOANHTHUTHANG where MADOANHTHUNAM = (N'{0}') and THAng = (N'{1}')", nam, thang);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Doanhthuthang k = GetDoanhthuthangFromDataRow(table.Rows[0]);

            return k;
        }
        
    }
}
