using QLCB.BLL;
using QLCB.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCB
{
    public partial class NhanLichChuyenBay : Form
    {
        SanbayBLL bllsb = new SanbayBLL();
        TuyenbayBLL blltb = new TuyenbayBLL();
        ChuyenbayBLL bbllcb = new ChuyenbayBLL();
        ChitietchuyenbayBLL bllct = new ChitietchuyenbayBLL();
        Chitietchuyenbay temp = new Chitietchuyenbay();
        public NhanLichChuyenBay()
        {
            InitializeComponent();
            this.Load += NhanLichChuyenBay_Load;
            this.buttonQLTB.Click += buttonQLTBv_Click;
            this.buttonNhan.Click += buttonNhan_Click;
            this.buttonLamMoi.Click += buttonLamMoi_Click;
            this.buttonThoat.Click += buttonThoat_Click;
            this.buttonThem.Click += buttonThem_Click;
            this.buttonQLSB.Click += buttonQLSB_Click;
            this.buttonLoad.Click += buttonLoad_Click;
            this.buttonSua.Click += buttonSua_Click;
            this.buttonXoa.Click += buttonXoa_Click;
        }
        private void NhanLichChuyenBay_Load(object sender, EventArgs e)
        {
            foreach (Sanbay a in bllsb.GetList())
            {
                cb_SanBayDi.Items.Add(a.TENSANBAY);
            }
        }
        private void buttonQLTBv_Click(object sender, EventArgs e)
        {
            QuanLyTuyenBay fbs = new QuanLyTuyenBay();
            fbs.ShowDialog();
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            loadDataSanBayTG();
        }
        private void buttonQLSB_Click(object sender, EventArgs e)
        {
            QuanLyChuyenBay fbs = new QuanLyChuyenBay();
            fbs.ShowDialog();
        }

        private void cb_SanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_SanBayDen.Items.Clear();
            cb_SanBayDen.Text = "";

            string sanBayDi = cb_SanBayDi.SelectedItem.ToString();
            if (sanBayDi != null)
            {
                Sanbay sb = bllsb.SearchTheoTen(sanBayDi);
                Tuyenbay[] list = blltb.SearchTheoMaSB(sb.MASANBAY);

                if (list != null)
                {
                    foreach (Tuyenbay a in list)
                    {
                        Sanbay sbay = bllsb.Search(a.SANBAYDEN);
                        cb_SanBayDen.Items.Add(sbay.TENSANBAY);
                    }
                }
            }
        }
        Chuyenbay GetChuyenBayInfo()
        {
            string sanBayDi = bllsb.SearchTheoTen(cb_SanBayDi.SelectedItem.ToString()).MASANBAY;
            string sanBayDen = bllsb.SearchTheoTen(cb_SanBayDen.SelectedItem.ToString()).MASANBAY;

            Chuyenbay cb = new Chuyenbay();
            cb.THOIGIANBAY = int.Parse(txtThoiGianBay.Text.Trim());
            cb.SOLUONGGHEHANG1 = int.Parse(txtSLGheHang1.Text.Trim());
            cb.SOLUONGGHEHANG2 = int.Parse(txtSLGheHang2.Text.Trim());
            cb.NGAYGIO = dateTime_ngay.Value.ToString();
            cb.MATUYENBAY = blltb.SearchTheoYC(sanBayDi, sanBayDen).MATUYENBAY;
            return cb;
        }
        void cleanChuyenBay()
        {
            cb_SanBayDen.Text = "";
            cb_SanBayDi.Text = "";
            txtThoiGianBay.Clear();
            txtSLGheHang1.Clear();
            txtSLGheHang2.Clear();
        }
        void cleanSanBay()
        {
            txtTim.Clear();
            txtSBTrungGian.Clear();
            txtThoiGianDung.Clear();
            txtGhiChu.Clear();
        }
        string maChuyenBay()
        {
            Chuyenbay tbTail = bbllcb.getChuyenBayTail();
            string st = tbTail.MACHUYENBAY;
            int id = Int32.Parse(st.Substring(3));
            id++;
            string prefix = "CB0" + id;
            return prefix;
        }
        string maChiTietChuyenBay()
        {
            Chitietchuyenbay tbTail = bllct.getCTChuyenBayTail();
            string st = tbTail.MACHITIETCHUYENBAY;
            int id = Int32.Parse(st.Substring(5));
            id++;
            string prefix = "CTCB_0" + id;
            return prefix;
        }
        void loadDataSanBayTG()
        {
            Chitietchuyenbay tbTail = bllct.getCTChuyenBayTail();
            dgvSBTrungGian.DataSource = bllct.GetListTheoMaChuyenBay(tbTail.MACHUYENBAY);
        }
        void buttonThem_Click(object sender, EventArgs e)
        {
            Chitietchuyenbay ct = new Chitietchuyenbay();
            ct.MACHITIETCHUYENBAY = maChiTietChuyenBay();
            ct.MACHUYENBAY = bbllcb.getChuyenBayTail().MACHUYENBAY;
            ct.SANBAYTRUNGGIAN = txtSBTrungGian.Text.Trim();
            ct.TGDUNG = txtThoiGianDung.Text.Trim();
            ct.GHICHU = txtGhiChu.Text.Trim();
            try
            {
                if (bllct.Add(ct))
                {
                    cleanSanBay();
                    loadDataSanBayTG();

                    MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void buttonNhan_Click(object sender, EventArgs e)
        {
            Chuyenbay tb = GetChuyenBayInfo();
            tb.MACHUYENBAY = maChuyenBay();
            try
            {
                if (bbllcb.Add(tb))
                {
                    cleanChuyenBay();

                    MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonLamMoi_Click(object sender, EventArgs e)
        {
            cleanChuyenBay();
            cleanSanBay();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSBTrungGian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSBTrungGian.Rows[e.RowIndex];

                txtSBTrungGian.Text = row.Cells[2].Value.ToString();
                txtThoiGianDung.Text = row.Cells[3].Value.ToString();
                txtGhiChu.Text = row.Cells[4].Value.ToString();

                temp.MACHITIETCHUYENBAY = row.Cells[0].Value.ToString();
                temp.MACHUYENBAY = row.Cells[1].Value.ToString();
            }
        }
        private void buttonSua_Click(object sender, EventArgs e)
        {
            temp.SANBAYTRUNGGIAN = txtSBTrungGian.Text.ToString();
            temp.TGDUNG = txtThoiGianDung.Text.ToString();
            temp.GHICHU = txtGhiChu.Text.ToString();
            try
            {
                if (bllct.Update(temp))
                {
                    cleanSanBay();
                    loadDataSanBayTG();

                    MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllct.Remove(temp.MACHITIETCHUYENBAY))
                {
                    cleanSanBay();
                    loadDataSanBayTG();

                    MessageBox.Show("Xóa thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
