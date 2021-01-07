using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class ThamsoDAL
    {
        DataHelper helper = new DataHelper();
        private Thamso GetThamsoFromDataRow(DataRow row)
        {
            Thamso k = new Thamso();
            k.TGBAYTOITHIEU = int.Parse(row["TGBAYTOITHIEU"].ToString().Trim());
            k.SOSANBAYTRUNGGIANTOIDA = int.Parse(row["SOSANBAYTRUNGGIANTOIDA"].ToString().Trim());
            k.TGDUNGTOITHIEU = int.Parse(row["TGDUNGTOITHIEU"].ToString().Trim());
            k.TGDUNGTOIDA = int.Parse(row["TGDUNGTOIDA"].ToString().Trim());
            k.TGCHAMNHATHUYDATVE = int.Parse(row["TGCHAMNHATHUYDATVE"].ToString().Trim());


            return k;
        }
        public Thamso[] GetList()
        {
            Thamso[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from THAMSO");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Thamso[n];
            for (int i = 0; i < n; i++)
            {
                Thamso s = GetThamsoFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Thamso k)
        {
            string query = string.Format("INSERT INTO THAMSO values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", k.TGBAYTOITHIEU, k.SOSANBAYTRUNGGIANTOIDA, k.TGDUNGTOITHIEU,k.TGDUNGTOIDA,k.TGCHAMNHATDATVE,k.TGCHAMNHATHUYDATVE);

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
        //public bool Remove(string id)
        //{
        //    string query = string.Format("DELETE FROM THAMSO WHERE TGBAYTOITHIEU = (N'{0}')", id);

        //    try
        //    {
        //        helper.ExecuteNonQuery(query);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public bool Update(Thamso k)
        //{
        //    string query = string.Format("UPDATE TGBAYTOITHIEU SET NAM = (N'{0}'),TONGThamso = (N'{1}') WHERE MAThamso = (N'{2}')", k.NAM, k.TONGThamso, k.MAThamso);

        //    try
        //    {
        //        helper.ExecuteNonQuery(query);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public Thamso Search(string id)
        //{
        //    DataTable table = null;
        //    int n = 0;

        //    string query = string.Format("SELECT * FROM Thamso WHERE MAThamso = (N'{0}')", id);
        //    table = helper.ExecuteQuery(query);
        //    n = table.Rows.Count;

        //    if (n == 0)
        //    {
        //        return null;
        //    }
        //    Thamso k = GetThamsoFromDataRow(table.Rows[0]);

        //    return k;
        //}
    }
}
