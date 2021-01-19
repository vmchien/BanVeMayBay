using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCB.DAL
{
    class PhieudatchoDAL
    {
        DataHelper helper = new DataHelper();
        private Phieudatcho GetPhieudatchoFromDataRow(DataRow row)
        {
            Phieudatcho k = new Phieudatcho();

            k.MAPHIEUDAT = row["MAPHIEUDAT"].ToString().Trim();
            k.MACHUYENBAY = row["MACHUYENBAY"].ToString().Trim();
            k.MAHANHKHACH = row["MAHANHKHACH"].ToString().Trim();
            k.MAHANGVE = row["MAHANGVE"].ToString().Trim();
            k.GIATIEN = float.Parse(row["GIATIEN"].ToString().Trim());
            k.NGAYDAT = row["NGAYDAT"].ToString().Trim();

            return k;
        }
        public Phieudatcho[] GetList()
        {
            Phieudatcho[] list = null;
            DataTable table = null;
            int n = 0;

            table = helper.ExecuteQuery("select * from PHIEUDATCHO");
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }

            list = new Phieudatcho[n];
            for (int i = 0; i < n; i++)
            {
                Phieudatcho s = GetPhieudatchoFromDataRow(table.Rows[i]);
                list[i] = s;
            }

            return list;
        }
        public bool Add(Phieudatcho k)
        {
            string query = string.Format("INSERT INTO PHIEUDATCHO values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')",k.MAPHIEUDAT,k.MACHUYENBAY,k.MAHANHKHACH,k.MAHANGVE,k.GIATIEN,k.NGAYDAT);

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
            string query = string.Format("DELETE FROM PHIEUDATCHO WHERE MAPHIEUDATCHO = (N'{0}')", id);

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
        public bool Update(Phieudatcho k)
        {
            string query = string.Format("UPDATE PHIEUDATCHO SET MACHUYENBAY = (N'{0}'),MAHANHKHACH = (N'{1}'),MAHANGVE = (N'{2}'),GIATIEN = (N'{3}'),NGAYDAT = (N'{4}') WHERE MAPHIEUDAT = (N'{5}')", k.MACHUYENBAY,k.MAHANHKHACH,k.MAHANGVE,k.GIATIEN,k.NGAYDAT,k.MAPHIEUDAT);

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
        public Phieudatcho Search(string id)
        {
            DataTable table = null;
            int n = 0;

            string query = string.Format("SELECT * FROM PHIEUDATCHO WHERE MAPHIEUDAT = (N'{0}')", id);
            table = helper.ExecuteQuery(query);
            n = table.Rows.Count;

            if (n == 0)
            {
                return null;
            }
            Phieudatcho k = GetPhieudatchoFromDataRow(table.Rows[0]);

            return k;
        }
        public bool quyDinhThoiGianChamNhat(string k)
        {
            StringBuilder query = new StringBuilder();
            query.Append("alter trigger utr_DATVE on PHIEUDATCHO for insert,update as begin if update(NGAYDAT) if not exists ( SELECT * FROM inserted I JOIN CHUYENBAY CB ON CB.MACHUYENBAY = I.MACHUYENBAY  WHERE DATEDIFF(DAY, ");
            query.Append(k);
            query.Append(" , CB.NGAYGIO) < 1  ) begin raiserror(N'Lỗi thêm, sửa không hợp lệ', 16, 1) rollback end end ");

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
    }
}
