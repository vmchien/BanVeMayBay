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
    public partial class QuanLyChuyenBay : Form
    {
        ChuyenbayBLL bll = new ChuyenbayBLL();
        TuyenbayBLL blltb = new TuyenbayBLL();
        public QuanLyChuyenBay()
        {
            InitializeComponent();
            this.Load += QuanLyChuyenBay_Load;
            this.buttonLoad.Click += buttonLoad_Click;
            this.buttonTim.Click += btnSearch_Click;
            this.buttonXoa.Click += bntRemove_Click;
            this.buttonSua.Click += bntUpdate_Click;
            this.buttonThoat.Click += buttonThoat_Click;
        }
        private void QuanLyChuyenBay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                LoadCombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while loading data",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void LoadData()
        {
            dgvDSChuyenBay.DataSource = bll.GetList();
        }
        void LoadCombobox()
        {
            cbb.Items.Clear();
            cbb.Items.Add("Mã chuyến bay");
            cbb.Items.Add("Mã tuyến bay");

            cbbTuyenBay.Items.Clear();
            foreach (Tuyenbay sb in blltb.GetList())
            {
                cbbTuyenBay.Items.Add(sb.MATUYENBAY.ToString());
            }

        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while loading data",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDSChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSChuyenBay.Rows[e.RowIndex];

                txtMaChuyenBay.Text = row.Cells[0].Value.ToString();
                txtMaTuyenBay.Text = row.Cells[1].Value.ToString();
                txtNgayGioBay.Text = row.Cells[2].Value.ToString();
                txtThoiGianBay.Text = row.Cells[3].Value.ToString();
                txtSLGheHang1.Text = row.Cells[4].Value.ToString();
                txtSLGheHang2.Text = row.Cells[5].Value.ToString();

                txtMaChuyenBay.Enabled = false;
                txtMaTuyenBay.Enabled = false;
            }
        }
        Chuyenbay GetChuyenBayInfo()
        {

            Chuyenbay tb = new Chuyenbay();
            tb.MACHUYENBAY = txtMaChuyenBay.Text.Trim();
            tb.MATUYENBAY = txtMaTuyenBay.Text.Trim();
            tb.NGAYGIO = txtNgayGioBay.Text.Trim();
            tb.THOIGIANBAY = int.Parse(txtThoiGianBay.Text.Trim());
            tb.SOLUONGGHEHANG1 = int.Parse(txtSLGheHang1.Text.Trim());
            tb.SOLUONGGHEHANG2 = int.Parse(txtSLGheHang2.Text.Trim());
            return tb;
        }
        void bntRemove_Click(object sender, EventArgs e)
        {
            string maChuyenBay = txtMaChuyenBay.Text.Trim();
            try
            {
                if (bll.Remove(maChuyenBay))
                {
                    LoadData();

                    txtMaChuyenBay.Clear();
                    txtMaTuyenBay.Clear();
                    txtNgayGioBay.Clear();
                    txtThoiGianBay.Clear();
                    txtSLGheHang1.Clear();
                    txtSLGheHang2.Clear();

                    MessageBox.Show("Xóa thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // show error if failed
            }
        }
        void bntUpdate_Click(object sender, EventArgs e)
        {
            Chuyenbay tb = GetChuyenBayInfo();
            try
            {
                if (bll.Update(tb))
                {
                    LoadData();

                    txtMaChuyenBay.Clear();
                    txtMaTuyenBay.Clear();
                    txtNgayGioBay.Clear();
                    txtThoiGianBay.Clear();
                    txtSLGheHang1.Clear();
                    txtSLGheHang2.Clear();

                    MessageBox.Show("Sửa thành công", "THÀNH CÔNG",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // show error if failed
            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text.Trim();

            if (cbb.SelectedIndex == 0)
            {
                Chuyenbay tb = bll.Search(id);
                try
                {
                    if (tb != null)
                    {
                        txtSearch.Clear();

                        txtMaChuyenBay.Text = tb.MACHUYENBAY;
                        txtMaTuyenBay.Text = tb.MATUYENBAY;
                        txtNgayGioBay.Text = tb.NGAYGIO;
                        txtThoiGianBay.Text = tb.THOIGIANBAY.ToString();
                        txtSLGheHang1.Text = tb.SOLUONGGHEHANG1.ToString();
                        txtSLGheHang2.Text = tb.SOLUONGGHEHANG2.ToString();

                        txtMaChuyenBay.Enabled = false;
                        txtMaTuyenBay.Enabled = false;

                        MessageBox.Show("Tìm thành công", "THÀNH CÔNG",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có tuyến bay cần tìm", "LỖI",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);    // show error if failed
                }
            }
            else
            {
                dgvDSChuyenBay.DataSource = bll.SearchTuyenBay(id);
            }
        }

        private void cbbTuyenBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbbTuyenBay.SelectedItem.ToString();
            if (id != null)
            {
                txtMaTuyenBay.Text = id;
            }
        }
    }
}
