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
    public partial class ThayDoiQuyDinh3 : Form
    {
        PhieudatchoBLL bll = new PhieudatchoBLL();
        public ThayDoiQuyDinh3()
        {
            InitializeComponent();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {

                string a = txtTGCN_DatVe.Text.Trim();
                string b = txtTGCN_HuyVe.Text.Trim();
                try
                {
                    if (a != "") bll.quyDinhThoiGianChamNhat(a);
                  // if (b != "") bllct.quyDinhThoiGianDungToiThieu(b);


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
