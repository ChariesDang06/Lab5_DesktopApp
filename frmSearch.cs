using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_2112727_DangThiQuynhNhu
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }
        public string ChuoiTim
        {
            get { return this.txtThongTin.Text; }
            set { this.txtThongTin.Text = value; }
        }
        internal TuyChon chon;
        private void TuyChonKieu()
        {
            if (rdMSSV.Checked)
                chon = TuyChon.TheoMa;
            else if (rdTen.Checked)
                chon = TuyChon.TheoTen;
            else if (rdLop.Checked)
                chon = TuyChon.TheoLop;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //DialogResult.OK
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TuyChonKieu();
            this.Close();
        }
    }
}
