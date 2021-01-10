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
    public partial class ThemHanhKhach : Form
    {
        HanhkhachBLL bll = new HanhkhachBLL();
        
        public string _khachHang { get; set; }
        public ThemHanhKhach()
        {
            InitializeComponent();
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            Hanhkhach hk = new Hanhkhach();
            hk.CMND = txtCMND.Text.Trim();
            hk.DIENTHOAI = txtDienThoai.Text.Trim();
            hk.TENHANHKHACH = txtTenHanhKhach.Text.Trim();

            Hanhkhach hktail = bll.getHanhKhachTail();
            string st = hktail.MAHANHKHACH;
            int id = Int32.Parse(st.Substring(3));
            id++;
            string prefix = "HK0" + id;

            hk.MAHANHKHACH = prefix;
            try
            {
                if (bll.Add(hk))
                {
                    _khachHang = hk.MAHANHKHACH;
                    MessageBox.Show("Thêm thành công", "THÀNH CÔNG",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
