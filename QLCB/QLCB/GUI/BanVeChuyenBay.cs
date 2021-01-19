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
    public partial class BanVeChuyenBay : Form
    {
        HanhkhachBLL bllhk = new HanhkhachBLL();
        ChuyenbayBLL bllcb = new ChuyenbayBLL();
        TuyenbayBLL blltb = new TuyenbayBLL();
        DongiaBLL blldg = new DongiaBLL();
        HangveBLL bllhv = new HangveBLL();

        Tuyenbay tuyenbay = new Tuyenbay();
        public BanVeChuyenBay()
        {
            InitializeComponent();
            this.Load += QuanLySanBay_Load;
            this.bntHanhKhach.Click += bntHanhKhach_Click;
            this.buttonLamMoi.Click += buttonLamMoi_Click;
            this.buttonThoat.Click += buttonThoat_Click;
            
        }
        void QuanLySanBay_Load(object sender, EventArgs e)
        {      
            cbb_machuyenbay.Items.Clear();
            foreach (Chuyenbay a in bllcb.GetList())
            {
                cbb_machuyenbay.Items.Add(a.MACHUYENBAY);
            }

            cb_HangVe.Items.Clear();

            foreach (Hangve a in bllhv.GetList())
            {
                cb_HangVe.Items.Add(a.MAHANGVE);
            }
        }
        void bntHanhKhach_Click(object sender, EventArgs e)
        {
            ThemHanhKhach fbs = new ThemHanhKhach();
            fbs.ShowDialog();
            string makh = fbs._khachHang;

            detailHanhKhach(makh);

        }
        void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        void buttonLamMoi_Click(object sender, EventArgs e)
        {
            cbb_machuyenbay.Text="";
            cb_HangVe.Text = "";
            checkBox.Checked = false;
            txtCMND.Clear();
            txtDienThoai.Clear();
            txtGiaTien.Clear();
            txtMaKhachHang.Clear();
            txtNgayGio.Clear();
            txtSanBayDen.Clear();
            txtSanBayDi.Clear();
            txtTenHangVe.Clear();
            txtTenHanhKhach.Clear();
            txtTinhTrangVe.Clear();

        }
        void detailHanhKhach(string makh)
        {
            Hanhkhach a = bllhk.Search(makh);

            txtMaKhachHang.Text = a.MAHANHKHACH;
            txtTenHanhKhach.Text = a.TENHANHKHACH;
            txtCMND.Text = a.CMND;
            txtDienThoai.Text = a.DIENTHOAI;

        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                string makh = txtMaKhachHang.Text.Trim();
                if (makh != "")
                {
                    detailHanhKhach(makh);
                }
            }
        }

        private void cbb_machuyenbay_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTinhTrangVe.Text = "Còn vé";
            string macb = cbb_machuyenbay.SelectedItem.ToString();

            if (macb != null)
            {
                Chuyenbay chuyenbay = bllcb.Search(macb);
                tuyenbay = blltb.Search(chuyenbay.MATUYENBAY);

                txtNgayGio.Text = chuyenbay.NGAYGIO;
                txtSanBayDi.Text = tuyenbay.SANBAYDI;
                txtSanBayDen.Text = tuyenbay.SANBAYDEN;
            }
        }

        private void cb_HangVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahv = cb_HangVe.SelectedItem.ToString();
            txtTenHangVe.Text = bllhv.Search(mahv).TENHANGVE;

            Dongia a = blldg.Search(tuyenbay.MATUYENBAY,mahv);
            txtGiaTien.Text = a.DONGIA.ToString();
        }
    }
}
