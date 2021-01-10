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
    public partial class QuanLySanBay : Form
    {
        SanbayBLL bll = new SanbayBLL();
        public QuanLySanBay()
        {
            InitializeComponent();
            this.Load += QuanLySanBay_Load;
            this.buttonLoad.Click += buttonLoad_Click;
            this.buttonTim.Click += btnSearch_Click;
            this.buttonThem.Click += buttonThem_Click;
            this.buttonXoa.Click += bntRemove_Click;
            this.buttonSua.Click += bntUpdate_Click;
        }

        private void QuanLySanBay_Load(object sender, EventArgs e)
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
            dgvDSSanBay.DataSource = bll.GetList();
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
        Sanbay GetSanBayInfo()
        {

            Sanbay sb = new Sanbay();
            sb.MASANBAY = txtMaSanBay.Text.Trim();
            sb.TENSANBAY = txtTenSanBay.Text.Trim();
            return sb;
        }
        void buttonThem_Click(object sender, EventArgs e)
        {
            Sanbay k = GetSanBayInfo();
            try
            {
                if (bll.Add(k))
                {
                    LoadData();

                    txtMaSanBay.Clear();
                    txtTenSanBay.Clear();

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
            string maSanBay = txtMaSanBay.Text.Trim();
            try
            {
                if (bll.Remove(maSanBay))
                {
                    LoadData();
                    txtMaSanBay.Clear();
                    txtTenSanBay.Clear();

                    MessageBox.Show("Xóa thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    // show error if failed
            }
        }
        private void dgvDSSanBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSSanBay.Rows[e.RowIndex];

                txtMaSanBay.Text = row.Cells[0].Value.ToString();
                txtTenSanBay.Text = row.Cells[1].Value.ToString();

            }
        }
        void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtTim.Text.Trim();
            Sanbay sb = bll.Search(id);
            try
            {
                if (sb != null)
                {
                    txtTim.Clear();

                    txtMaSanBay.Text = sb.MASANBAY;
                    txtTenSanBay.Text = sb.TENSANBAY;

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
        void bntUpdate_Click(object sender, EventArgs e)
        {
            Sanbay sb = GetSanBayInfo();
            try
            {
                if (bll.Update(sb))
                {
                    LoadData();
                    txtMaSanBay.Clear();
                    txtTenSanBay.Clear();

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
