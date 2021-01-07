using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class DongiaDAL
    {
        DataHelper helper = new DataHelper();
        private Dongia GetDongiaFromDataRow(DataRow row)
        {
            Dongia k = new Dongia();

            k.MADONGIA = row["MADONGIA"].ToString().Trim();
            k.MATUYENBAY = row["MATUYENBAY"].ToString().Trim();
            k.MAHANGVE = row["MAHANGVE"].ToString().Trim();
            k.DONGIA = float.Parse(row["DONGIA"].ToString().Trim());
            return k;
        }
        public Dongia[] GetList()
        {
            Dongia[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from DONGIA");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Dongia[n];
            for (int i = 0; i < n; i++)
            {
                Dongia s = GetDongiaFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Dongia k)
        {
            string query = string.Format("INSERT INTO DONGIA values (N'{0}',N'{1}',N'{2}',N'{3}')", k.MADONGIA,k.MATUYENBAY,k.MAHANGVE,k.DONGIA);

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
            string query = string.Format("DELETE FROM DONGIA WHERE MADONGIA = (N'{0}')", id);

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
        public bool Update(Dongia k)
        {
            string query = string.Format("UPDATE DONGIA SET MATUYENBAY = (N'{0}'), MAHANGVE = (N'{1}'), DONGIA = (N'{2}') WHERE MADONGIA = (N'{3}')", k.MATUYENBAY,k.MAHANGVE,k.DONGIA,k.MADONGIA);

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
        public Dongia Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM DONGIA WHERE MADONGIA = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Dongia k = GetDongiaFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
