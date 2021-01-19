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

namespace QLCB.GUI
{
    public partial class ThemDonGiaVe : Form
    {
        DongiaBLL bll = new DongiaBLL();
        private string maTb;
        public ThemDonGiaVe(string id)
        {
            InitializeComponent();
            maTb = id;
        }

        private void bnt_add_Click(object sender, EventArgs e)
        {
            Dongia dongiaTail = bll.getDonGiaTail();
            string st = dongiaTail.MADONGIA;
            int id = Int32.Parse(st.Substring(3));
            id++;
            string prefix = "DG0" + id;

            Dongia dongia1 = new Dongia();
            dongia1.DONGIA = int.Parse(txt_HV1.Text.Trim());
            dongia1.MADONGIA = prefix;
            dongia1.MAHANGVE = "HV1";
            dongia1.MATUYENBAY = maTb;

            id++;
            prefix = "DG0" + id;
            Dongia dongia2 = new Dongia();
            dongia2.DONGIA = int.Parse(txt_HV2.Text.Trim());
            dongia2.MADONGIA = prefix;
            dongia2.MAHANGVE = "HV2";
            dongia2.MATUYENBAY = maTb;
            try
            {
                if (bll.Add(dongia1) && bll.Add(dongia2))
                {
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
    }
}
