using QLCB.BLL;
using QLCB.DTO;
using QLCB.GUI;
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
    public partial class QuanLyTuyenBay : Form
    {

        TuyenbayBLL bll = new TuyenbayBLL();
        SanbayBLL bllsb = new SanbayBLL();
        DongiaBLL blldg = new DongiaBLL();
        public QuanLyTuyenBay()
        {
            InitializeComponent();
            this.Load += QuanLyTuyenBay_Load;
            this.buttonLoad.Click += buttonLoad_Click;
            this.buttonTim.Click += btnSearch_Click;
            this.buttonThem.Click += buttonThem_Click;
            this.buttonXoa.Click += bntRemove_Click;
            this.buttonSua.Click += bntUpdate_Click;
            this.buttonThoat.Click += buttonThoat_Click;

        }
        private void QuanLyTuyenBay_Load(object sender, EventArgs e)
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
            dgvDSTuyenBay.DataSource = bll.GetList();
        }
        void LoadCombobox()
        {
            cbbDi.Items.Clear();
            cbbDen.Items.Clear();
            foreach (Sanbay sb in bllsb.GetList())
            {
                cbbDi.Items.Add(sb.MASANBAY.ToString());
                cbbDen.Items.Add(sb.MASANBAY.ToString());
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
        Tuyenbay GetTuyenBayInfo()
        {

            Tuyenbay tb = new Tuyenbay();
            tb.MATUYENBAY = txtMaTuyenBay.Text.Trim();
            tb.SANBAYDEN = txtSanBayDen.Text.Trim();
            tb.SANBAYDI = txtSanBayDi.Text.Trim();
            return tb;
        }
        void buttonThem_Click(object sender, EventArgs e)
        {
            Tuyenbay tb = GetTuyenBayInfo();

            Tuyenbay tbTail = bll.getTuyenBayTail();
            string st = tbTail.MATUYENBAY;
            int id = Int32.Parse(st.Substring(3));
            id++;
            string prefix = "TB0" + id;

            tb.MATUYENBAY = prefix;
            if (tb.SANBAYDEN.Equals(tb.SANBAYDI))
            {

                MessageBox.Show("Sân bay đến và sân bay đi trùng nhau", "LỖI",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (bll.Add(tb))
                    {
                        LoadData();
                        txtMaTuyenBay.Clear();
                        txtSanBayDen.Clear();
                        txtSanBayDi.Clear();

                        MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ThemDonGiaVe fbs = new ThemDonGiaVe(tb.MATUYENBAY);
                fbs.ShowDialog();
            }
        }
        void bntRemove_Click(object sender, EventArgs e)
        {
            string maSanBay = txtMaTuyenBay.Text.Trim();
            try
            {
                blldg.Remove(maSanBay);
                blldg.Remove(maSanBay);
                if (bll.Remove(maSanBay))
                {

                    LoadData();
                    txtMaTuyenBay.Clear();
                    txtSanBayDen.Clear();
                    txtSanBayDi.Clear();

                    MessageBox.Show("Xóa thành công", "THÀNH CÔNG",
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
            string id = txtTim.Text.Trim();
            Tuyenbay tb = bll.Search(id);
            try
            {
                if (tb != null)
                {
                    txtTim.Clear();

                    txtMaTuyenBay.Text = tb.MATUYENBAY;
                    txtSanBayDi.Text = tb.SANBAYDI;
                    txtSanBayDen.Text = tb.SANBAYDEN;

                    txtMaTuyenBay.Enabled = false;
                    txtSanBayDi.Enabled = false;
                    txtSanBayDen.Enabled = false;

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
        void bntUpdate_Click(object sender, EventArgs e)
        {
            Tuyenbay tb = GetTuyenBayInfo();
            if (tb.SANBAYDEN.Equals(tb.SANBAYDI))
            {

                MessageBox.Show("Sân bay đến và sân bay đi trùng nhau", "LỖI",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (bll.Update(tb))
                    {
                        LoadData();
                        txtMaTuyenBay.Clear();
                        txtSanBayDen.Clear();
                        txtSanBayDi.Clear();

                        MessageBox.Show("Sửa thành công", "THÀNH CÔNG",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);    // show error if failed
                }
            }
        }
        private void dgvDSTuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSTuyenBay.Rows[e.RowIndex];

                txtMaTuyenBay.Text = row.Cells[0].Value.ToString();
                txtSanBayDi.Text = row.Cells[1].Value.ToString();
                txtSanBayDen.Text = row.Cells[2].Value.ToString();

                txtMaTuyenBay.Enabled = false;
                txtSanBayDi.Enabled = false;
                txtSanBayDen.Enabled = false;
            }
        }
        private void cbbDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbbDi.SelectedItem.ToString();
            if (id != null)
            {
                txtSanBayDi.Text = id;
            }
        }

        private void cbbDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbbDen.SelectedItem.ToString();
            if (id != null)
            {
                txtSanBayDen.Text = id;
            }
        }
    }
}
