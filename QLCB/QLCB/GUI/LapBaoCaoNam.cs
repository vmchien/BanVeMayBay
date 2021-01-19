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
    public partial class LapBaoCaoNam : Form
    {
        DoanhthunamBLL bll = new DoanhthunamBLL();
        string nam = "";
        string naml = "";
        public LapBaoCaoNam()
        {
            InitializeComponent();
            this.Load += LapBaoCaoNam_Load;
        }
        private void LapBaoCaoNam_Load(object sender, EventArgs e)
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
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tổng tiền năm "+ nam +": "+ bll.tongDT(naml), "THÀNH CÔNG",
             MessageBoxButtons.OK, MessageBoxIcon.Information) ;
        }

        private void cb_Nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            nam = cb_Nam.SelectedItem.ToString();
            naml = bll.SearchNam(nam).MADOANHTHUNAM;
        }
    }
}
