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
        public NhanLichChuyenBay()
        {
            InitializeComponent();
            this.Load += NhanLichChuyenBay_Load;
            this.buttonQLTB.Click += buttonQLTBv_Click;
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

        private void cb_SanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sanBayDi = cb_SanBayDi.SelectedItem.ToString();
            if (sanBayDi != null)
            {
                Sanbay sb = bllsb.SearchTheoTen(sanBayDi);
                Tuyenbay[] list = blltb.SearchTheoMaSB(sb.MASANBAY);

                if (list.Length == null)
                {
                    foreach (Tuyenbay a in list)
                    {
                        Sanbay sbay = bllsb.Search(a.SANBAYDEN);
                        cb_SanBayDen.Items.Add(sbay.TENSANBAY);
                    }
                }
            }
        }
    }
}
