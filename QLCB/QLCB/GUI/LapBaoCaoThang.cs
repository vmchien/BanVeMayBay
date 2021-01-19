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
    public partial class LapBaoCaoThang : Form
    {
        DoanhthunamBLL bll = new DoanhthunamBLL();
        DoanhthuthangBLL blt = new DoanhthuthangBLL();
        string thang = "";
        string nam = "";
        string naml = "";
        public LapBaoCaoThang()
        {
            InitializeComponent();
            this.Load += LapBaoCaoThang_Load;
        }
        private void LapBaoCaoThang_Load(object sender, EventArgs e)
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
            Doanhthunam[] l = bll.GetList();
            for (int i = 0; i < l.Length; i++)
            {
                cb_Nam.Items.Add(l[i].NAM);
            }
            for (int i =1; i <= 12; i++)
            {
                cb_Thang.Items.Add(i);
            }
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
            double tt = blt.SearchNamThang(thang, nam).TONGDOANHTHUTHANG;
            MessageBox.Show("Tháng " + thang +" năm "+naml +" có tổng tiền là "+ tt, "THÀNH CÔNG",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_Thang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = cb_Thang.SelectedItem.ToString();
        }

        private void cb_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            naml = cb_Nam.SelectedItem.ToString();
           nam =  bll.SearchNam(naml).MADOANHTHUNAM;
        }
    }
}
