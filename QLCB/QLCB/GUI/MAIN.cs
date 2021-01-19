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
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
        }

        private void buttonNhanLichCB_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanLichChuyenBay fbs = new NhanLichChuyenBay();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonBanVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            BanVeChuyenBay fbs = new BanVeChuyenBay();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQLSB_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLySanBay fbs = new QuanLySanBay();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQLTB_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyTuyenBay fbs = new QuanLyTuyenBay();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQLCB_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyChuyenBay fbs = new QuanLyChuyenBay();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQDChuyenBay_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThayDoiQuyDinh1 fbs = new ThayDoiQuyDinh1();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQDHangVeDonGia_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThayDoiQuyDinh2 fbs = new ThayDoiQuyDinh2();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonQDHanDatVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThayDoiQuyDinh3 fbs = new ThayDoiQuyDinh3();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonLapBaoCaoThang_Click(object sender, EventArgs e)
        {
            this.Hide();
            LapBaoCaoThang fbs = new LapBaoCaoThang();
            fbs.ShowDialog();
            this.Show();
        }

        private void buttonLapBaoCaoNam_Click(object sender, EventArgs e)
        {
            this.Hide();
            LapBaoCaoNam fbs = new LapBaoCaoNam();
            fbs.ShowDialog();
            this.Show();
        }
    }
}
