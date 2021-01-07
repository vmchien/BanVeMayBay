using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class DoanhthunamDAL
    {
        DataHelper helper = new DataHelper();
        private Doanhthunam GetDoanhthunamFromDataRow(DataRow row)
        {
            Doanhthunam k = new Doanhthunam();

            k.MADOANHTHUNAM = row["MADOANHTHUNAM"].ToString().Trim();
            k.NAM = int.Parse(row["NAM"].ToString().Trim());
            k.TONGDOANHTHUNAM = float.Parse(row["TONGDOANHTHUNAM"].ToString().Trim());



            return k;
        }
        public Doanhthunam[] GetList()
        {
            Doanhthunam[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from DOANHTHUNAM");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Doanhthunam[n];
            for (int i = 0; i < n; i++)
            {
                Doanhthunam s = GetDoanhthunamFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Doanhthunam k)
        {
            string query = string.Format("INSERT INTO DOANHTHUNAM values (N'{0}',N'{1}',N'{2}')", k.MADOANHTHUNAM, k.NAM, k.TONGDOANHTHUNAM);

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
            string query = string.Format("DELETE FROM DOANHTHUNAM WHERE MADOANHTHUNAM = (N'{0}')", id);

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
        public bool Update(Doanhthunam k)
        {
            string query = string.Format("UPDATE DOANHTHUNAM SET NAM = (N'{0}'),TONGDOANHTHUNAM = (N'{1}') WHERE MADOANHTHUNAM = (N'{2}')", k.NAM, k.TONGDOANHTHUNAM, k.MADOANHTHUNAM);

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
        public Doanhthunam Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM DOANHTHUNAM WHERE MADOANHTHUNAM = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Doanhthunam k = GetDoanhthunamFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
