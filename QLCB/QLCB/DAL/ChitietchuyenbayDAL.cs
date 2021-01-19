using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class ChitietchuyenbayDAL
    {
        DataHelper helper = new DataHelper();
        private Chitietchuyenbay GetChitietchuyenbayFromDataRow(DataRow row)
        {
            Chitietchuyenbay k = new Chitietchuyenbay();

            k.MACHITIETCHUYENBAY = row["MACHITIETCHUYENBAY"].ToString().Trim();
            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.SANBAYTRUNGGIAN = row["SANBAYTRUNGGIAN"].ToString().Trim();
            k.TGDUNG = row["TGDUNG"].ToString().Trim();
            k.GHICHU = row["GHICHU"].ToString().Trim();


            return k;
        }
        public Chitietchuyenbay[] GetList()
        {
            Chitietchuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from CHITIETCHUYENBAY");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Chitietchuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Chitietchuyenbay s = GetChitietchuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public Chitietchuyenbay[] GetListTheoMaChuyenBay(string id)
        {
            Chitietchuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            string query = string.Format("select * from CHITIETCHUYENBAY where MACHUYENBAY = N'{0}'",id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Chitietchuyenbay[n];
            for (int i = 0; i < n; i++)
            {
                Chitietchuyenbay s = GetChitietchuyenbayFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        
        public bool Add(Chitietchuyenbay k)
        {
            string query = string.Format("INSERT INTO CHITIETCHUYENBAY values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", k.MACHITIETCHUYENBAY, k.MACHUYENBAY, k.SANBAYTRUNGGIAN, k.TGDUNG, k.GHICHU);

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
            string query = string.Format("DELETE FROM CHITIETCHUYENBAY WHERE MACHITIETCHUYENBAY = (N'{0}')", id);

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
        public bool Update(Chitietchuyenbay k)
        {
            string query = string.Format("UPDATE CHITIETCHUYENBAY SET MACHUYENBAY = (N'{0}'),SANBAYTRUNGGIAN = (N'{1}'),TGDUNG = (N'{2}'),GHICHU = (N'{3}') WHERE MACHITIETCHUYENBAY = (N'{4}')", k.MACHUYENBAY, k.SANBAYTRUNGGIAN, k.TGDUNG, k.GHICHU, k.MACHITIETCHUYENBAY);

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
        public bool quyDinhThoiGianDungToiThieu(string k)
        {

            StringBuilder query = new StringBuilder();
            query.Append("alter trigger utr_TGDUNG1 on CHITIETCHUYENBAY for insert, update as begin if update(TGDUNG) if exists(SELECT * FROM inserted WHERE DATEPART(minute, TGDUNG) < ");
            query.Append(k);
            query.Append(") begin  raiserror(N'Lỗi thêm, sửa không hợp lệ', 16, 1)  rollback  end  end");
            try
            {
                helper.ExecuteNonQuery(query.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool quyDinhThoiGianDungToiDa(string k)
        {
            StringBuilder query = new StringBuilder();
            query.Append("alter  trigger utr_TGDUNG on CHITIETCHUYENBAY for insert, update as begin if update(TGDUNG) if exists(SELECT * FROM inserted  WHERE DATEPART(minute, TGDUNG) > ");
            query.Append(k);
            query.Append(") begin raiserror(N'Lỗi thêm, sửa không hợp lệ', 16, 1)  rollback end end");
            try
            {
                helper.ExecuteNonQuery(query.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Chitietchuyenbay getCTChuyenBayTail()
        {
            Chitietchuyenbay[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("SELECT TOP 1 * FROM CHITIETCHUYENBAY ORDER BY MACHITIETCHUYENBAY DESC ");  // get all students
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Chitietchuyenbay bs = GetChitietchuyenbayFromDataRow(table.Rows[0]);

            return bs;
        }
        public Chitietchuyenbay Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM CHITIETCHUYENBAY WHERE MACHITIETCHUYENBAY = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Chitietchuyenbay k = GetChitietchuyenbayFromDataRow(table.Rows[0]);

            return k;
        }
    }
}
