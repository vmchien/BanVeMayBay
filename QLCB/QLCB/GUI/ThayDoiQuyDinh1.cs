using QLCB.BLL;
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
    public partial class ThayDoiQuyDinh1 : Form
    {
        ChuyenbayBLL bll = new ChuyenbayBLL();
        ChitietchuyenbayBLL bllct = new ChitietchuyenbayBLL();
        public ThayDoiQuyDinh1()
        {
            InitializeComponent();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {

            string a = txtTGBayToiThieu.Text.Trim();
            string b = txtTGDungToiThieu.Text.Trim();
            string c = txtTGDungToiDa.Text.Trim();
            try
            {
                if (a != "") bll.quyDinhThoiGianBayToiThieu(a);
                if (b != "") bllct.quyDinhThoiGianDungToiThieu(b);
                if (c != "") bllct.quyDinhThoiGianDungToiDa(c);


                MessageBox.Show("Sửa quy định thành công", "THÀNH CÔNG",
         MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}
