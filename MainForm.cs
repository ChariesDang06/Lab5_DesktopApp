using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.Xml.Serialization;



namespace Lab5_2112727_DangThiQuynhNhu
{
    public partial class MainForm : Form
    {
        QuanLySinhVien qlSV = new QuanLySinhVien();
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Lấy thông tin từ controls thông tin SV
        private SinhVien GetSinhVien()
        {

            SinhVien sv = new SinhVien();
            List<string> mh = new List<string>();
            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoTenlot = this.txtHoTenLot.Text;
            sv.Ten = this.txtTen.Text;
            if (rdNu.Checked)
                sv.Phai = "Nữ";
            sv.Phai = "Nam";
            sv.NgaySinh = this.dtNgaySinh.Value;
            sv.Lop = this.cbLop.Text;
            sv.CMND = this.mtxtCMND.Text;
            sv.SDT = this.mtxtSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            for (int i = 0; i < this.ckMonHoc.Items.Count; i++)
                if (ckMonHoc.GetItemChecked(i))
                    mh.Add(ckMonHoc.Items[i].ToString());
            sv.MonDK = mh;
            return sv;
        }
        //Lấy thông tin sinh viên từ dòng item của ListView
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {

            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTenlot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.Phai = lvitem.SubItems[3].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.Lop = lvitem.SubItems[5].Text;
            sv.CMND = lvitem.SubItems[6].Text;
            sv.SDT = lvitem.SubItems[7].Text;
            sv.DiaChi = lvitem.SubItems[8].Text;
            List<string> mh = new List<string>();
            string[] s = lvitem.SubItems[9].Text.Split(',');
            foreach (string t in s)
                mh.Add(t);
            sv.MonDK = mh;
            return sv;
        }
        //Thiết lập các thông tin lên controls sinh viên
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoTenLot.Text = sv.HoTenlot;
            this.txtTen.Text = sv.Ten;
            if (sv.Phai == "Nam")
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            this.dtNgaySinh.Value = sv.NgaySinh;
            this.cbLop.Text = sv.Lop;
            this.mtxtCMND.Text = sv.CMND;
            this.mtxtSDT.Text = sv.SDT;
            this.txtDiaChi.Text = sv.DiaChi;
            for (int i = 0; i < this.ckMonHoc.Items.Count; i++)
            {
                this.ckMonHoc.SetItemChecked(i, false);
            }
            foreach (string s in sv.MonDK)
            {
                for (int i = 0; i < this.ckMonHoc.Items.Count; i++)
                {
                    if (s.CompareTo(this.ckMonHoc.Items[i]) == 0)
                        this.ckMonHoc.SetItemChecked(i, true);
                }

            }

        }
        //Thêm sinh viên vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lview = new ListViewItem(sv.MSSV);
            lview.SubItems.Add(sv.HoTenlot);
            lview.SubItems.Add(sv.Ten);
            lview.SubItems.Add(sv.Phai);
            lview.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lview.SubItems.Add(sv.Lop);
            lview.SubItems.Add(sv.CMND);
            lview.SubItems.Add(sv.SDT);
            lview.SubItems.Add(sv.DiaChi);
            string mh = "";
            foreach (string s in sv.MonDK)
                mh += s + ",";
            mh = mh.Substring(0, mh.Length - 1);
            lview.SubItems.Add(mh);
            this.lvDSSV.Items.Add(lview);
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlSV.Sua(sv, sv.MSSV, SoSanhTheoMa);
            if (kqsua)
            {
                this.LoadListView();
            }
        }
        private void lvDDSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvDSSV.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem =
                this.lvDSSV.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        public void LoadListView()
        {
            this.lvDSSV.Items.Clear();
            foreach (SinhVien sv in qlSV.DanhSach)
            {
                ThemSV(sv);
            }
        }



        /* Khi click chuột phải vào Listview, hiển thị context menu “Xóa”, cho phép xóa 
         một hoặc nhiều sinh viên đã chọn*/
        private void lvDSSV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var control = lvDSSV.FocusedItem;
                if (control != null && control.Bounds.Contains(e.Location))
                {
                    ContextMenu m = new ContextMenu();
                    MenuItem delMenu = new MenuItem("Xóa");
                    delMenu.Click += delegate (object sender2, EventArgs e2)
                    {
                        DelectAction(sender, e);
                    };
                    m.MenuItems.Add(delMenu);


                    MenuItem reloadMenu = new MenuItem("Tải lại");
                    reloadMenu.Click += delegate (object sender2, EventArgs e2)
                    {
                        ReloadAction(sender, e);
                    };
                    m.MenuItems.Add(reloadMenu);

                    m.Show(lvDSSV, new Point(e.X, e.Y));
                }

            }
        }
        private void DelectAction(object sender, MouseEventArgs e)
        {
            ListView ListViewControl = sender as ListView;
            foreach (ListViewItem eachItem in ListViewControl.CheckedItems)
            {
                ListViewControl.Items.Remove(eachItem);
            }
        }
        private void ReloadAction(object sender, MouseEventArgs e)
        {
            ListView ListViewControl = sender as ListView;
            ListViewControl.Refresh();
        }

        /*Khi người dùng đóng form, kiểm tra xem người dùng có chỉnh sửa danh sách 
        sinh viên được tải lên hay không*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var x = MessageBox.Show("Bạn có muốn lưu thay đổi không? ",
                             "saveChanged", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (x == DialogResult.No)
            {
                e.Cancel = false;
            }
            else
            {
                frmSaveChanges frmSave = new frmSaveChanges();
                frmSave.ShowDialog();
            }
            e.Cancel = false;
        }
        
        public void SaveChangesJSON()
        {
                SaveChangesTXT("DSSV_Temp.txt");
                qlSV.convertToJson("DSSV_Temp.txt");
        }

        public void SaveChangesXML()
        {

            string path = "DanhSachSV.xml";
            int count = this.lvDSSV.SelectedItems.Count;
            for(int i = 0; i < count; i++)
            {
                ListViewItem lvitem =
                this.lvDSSV.SelectedItems[i];
                var xmlDoc = new XmlDocument();
                var nodeList = xmlDoc.DocumentElement.SelectNodes("/listsinhvien/sinhvien");
                foreach (XmlNode node in nodeList)
                {

                    SinhVien sv = GetSinhVienLV(lvitem);
                    node.SelectSingleNode("MSSV").Value = sv.MSSV;
                    node.SelectSingleNode("HoTenlot").Value = sv.HoTenlot;
                    node.SelectSingleNode("Ten").Value = sv.Ten;
                    node.SelectSingleNode("Phai").Value = sv.Phai;
                    node.SelectSingleNode("NgaySinh").Value = sv.NgaySinh.ToString();
                    node.SelectSingleNode("Lop").Value = sv.Lop;
                    node.SelectSingleNode("CMND").Value = sv.CMND;
                    node.SelectSingleNode("SDT").Value = sv.SDT;
                    node.SelectSingleNode("DiaChi").Value = sv.DiaChi;
                    List<string> monhoc = new List<string>();
                    foreach (var item in sv.MonDK)
                        monhoc.Add(item);
                    String[] str = monhoc.ToArray();
                    node.SelectSingleNode("MonDK").Value = monhoc.ToString();
                    
                }
                xmlDoc.Save(path);
            }
            
        }
        public void SaveChangesTXT(string p)
        {
            //File.WriteAllText("DanhSachSV.txt", "");
            using (StreamWriter sw = new StreamWriter(p))
            {
                foreach (ListViewItem item in lvDSSV.Items)
                {
                    sw.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", item.SubItems[0].Text.Trim(), item.SubItems[1].Text.Trim(),
                        item.SubItems[2].Text.Trim(), item.SubItems[3].Text.Trim(), item.SubItems[4].Text.Trim(), item.SubItems[5].Text.Trim(),
                        item.SubItems[6].Text.Trim(), item.SubItems[7].Text.Trim(), item.SubItems[8].Text.Trim(), item.SubItems[9].Text.Trim());
                }
            }
           
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {


            string path = "DanhSachSV.json";
            qlSV = new QuanLySinhVien();
            int kq = qlSV.DocFile(path);
            if (kq == 1)
            {
                LoadListView();
                lvDSSV.MouseUp += new MouseEventHandler(lvDSSV_MouseClick);
            }
            else
                MessageBox.Show("Không thể đọc loại file này", "Lỗi đọc file");
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlSV.Tim(sv.MSSV,
            delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.qlSV.Them(sv);
                this.LoadListView();
            }
        }
        TuyChon kieu;
        string input = "";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
            input = frm.ChuoiTim;
            kieu = frm.chon;
            List<SinhVien> dsSV = new List<SinhVien>();
            dsSV = qlSV.TimKiemTheoYeuCau(kieu, input);
            if (input == String.Empty)
                MessageBox.Show("Hãy nhập thông tin cần tìm");
            else
            {
                if (dsSV.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có thông tin như yêu cầu");
                    LoadListView();
                }    
                    
                else
                {
                    lvDSSV.Items.Clear();
                    MessageBox.Show($"Có {dsSV.Count()} sinh viên có thông tin theo yêu cầu");
                    foreach (SinhVien sv in dsSV)
                        ThemSV(sv);
                }
            }
        }

        
        //=========================================================
        //JSON Genrating
       
        private void btnJSON_Click(object sender, EventArgs e)
        {
           // qlSV.convertToJson();
        }
        

    }
}
