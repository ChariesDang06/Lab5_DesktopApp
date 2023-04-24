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
    public partial class frmSaveChanges : Form
    {
        public frmSaveChanges()
        {
            InitializeComponent();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm frmMain = new MainForm();
            if (rdTXT.Checked)
            {
                frmMain.SaveChangesTXT(@"DanhSachSV.txt");
                this.Close();
            }
            else if (rdJSON.Checked)
            {
                frmMain.SaveChangesJSON();
                this.Close();
            }
            else if(rdXML.Checked)
            {
                frmMain.SaveChangesXML();
                this.Close();
            }    
        }
    }

}
