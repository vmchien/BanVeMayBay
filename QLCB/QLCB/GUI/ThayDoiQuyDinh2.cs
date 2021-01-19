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
    public partial class ThayDoiQuyDinh2 : Form
    {
        VechuyenbayBLL bll = new VechuyenbayBLL();
        public ThayDoiQuyDinh2()
        {
            InitializeComponent();
            this.Load += ThayDoiQuyDinh2_Load;
            this.buttonLoad.Click += ThayDoiQuyDinh2_Load;
            this.buttonTim.Click += btnSearch_Click;
            this.buttonThem.Click += buttonThem_Click;
            this.buttonXoa.Click += bntRemove_Click;
            this.buttonSua.Click += bntUpdate_Click;
            this.buttonThoat.Click += buttonThoat_Click;
        }
        private void ThayDoiQuyDinh2_Load(object sender, EventArgs e)
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
        void LoadData()
        {
            dgvThuoc

                .DataSource = bll.GetList();
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvThuoc.Rows[e.RowIndex];

                txtMaDonGia.Text = row.Cells[0].Value.ToString();
                txtMaTuyenBay.Text = row.Cells[1].Value.ToString();
                txtMaHangVe.Text = row.Cells[2].Value.ToString();
                txtTenHangVe.Text = row.Cells[3].Value.ToString();
                txtDonGia.Text = row.Cells[4].Value.ToString();

                txtMaDonGia.Enabled = false;

            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtTim.Text.Trim();
            Vechuyenbay sb = bll.Search(id);
            try
            {
                if (sb != null)
                {
                    txtTim.Clear();

                    txtMaDonGia.Text = sb.MAVE;
                    txtMaTuyenBay.Text = sb.MACHUYENBAY;
                    txtMaHangVe.Text = sb.MAHANGVE;
                    txtTenHangVe.Text = sb.MAHANHKHACH;
                    txtDonGia.Text = sb.GIATIEN.ToString();

                    txtMaDonGia.Enabled = false;
                    MessageBox.Show("Tìm thành công", "THÀNH CÔNG",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có sân bay cần tìm", "LỖI",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // show error if failed
            }
        }
        void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Vechuyenbay GetVeInfo()
        {

            Vechuyenbay sb = new Vechuyenbay();
            sb.MAVE = txtMaDonGia.Text;
            sb.MACHUYENBAY = txtMaTuyenBay.Text;
            sb.MAHANGVE = txtMaHangVe.Text;
            sb.MAHANHKHACH = txtTenHangVe.Text;
            sb.GIATIEN = int.Parse(txtDonGia.Text);
            return sb;
        }
        void buttonThem_Click(object sender, EventArgs e)
        {
            Vechuyenbay bs = GetVeInfo();

            Vechuyenbay bsTail = bll.getVeTail();
            string st = bsTail.MAVE;
            int id = Int32.Parse(st.Substring(4));
            id++;
            string prefix = "VCB0" + id;

            bs.MAVE = prefix;

            try
            {
                if (bll.Add(bs))
                {
                    LoadData();
                    txtMaDonGia.Clear();
                    txtMaTuyenBay.Clear();
                    txtMaHangVe.Clear();
                    txtTenHangVe.Clear();
                    txtDonGia.Clear();

                    MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void bntRemove_Click(object sender, EventArgs e)
        {
            string maSanBay = txtMaDonGia.Text.Trim();
            try
            {
                if (bll.Remove(maSanBay))
                {
                    LoadData();
                    txtMaDonGia.Clear();
                    txtMaTuyenBay.Clear();
                    txtMaHangVe.Clear();
                    txtTenHangVe.Clear();
                    txtDonGia.Clear();

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
            Vechuyenbay sb = GetVeInfo();
            try
            {
                if (bll.Update(sb))
                {
                    LoadData();
                    txtMaDonGia.Clear();
                    txtMaTuyenBay.Clear();
                    txtMaHangVe.Clear();
                    txtTenHangVe.Clear();
                    txtDonGia.Clear();

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
}
