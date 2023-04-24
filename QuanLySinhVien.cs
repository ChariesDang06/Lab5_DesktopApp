using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    enum TuyChon
    {
        TheoMa,
        TheoTen,
        TheoLop
    }


    public delegate int SoSanh(object sv1, object sv2);


    class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;
        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }
        // Thêm một sinh viên vào danh sách
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }
        //Tìm một sinh viên trong danh sách thỏa điều kiện so sánh
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSach)
                if (ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }
            return svresult;
        }

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DanhSach.Count - 1;
            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }

        // Hàm đọc danh sách sinh viên từ tập tin txt
        private void LoadTXT(string filename)
        {
            string line;
            
            
            using (StreamReader sr = new StreamReader(
            new FileStream(filename,
            FileMode.Open)))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split('\t');
                    SinhVien sv = new SinhVien(); 
                    sv.MSSV = s[0];
                    sv.HoTenlot = s[1];
                    sv.Ten = s[2];
                    sv.Phai = s[3];
                    sv.NgaySinh = DateTime.Parse(s[4]);
                    sv.Lop = s[5];
                    sv.CMND = s[6];
                    sv.SDT = s[7];
                    sv.DiaChi = s[8];
                    string[] mh = s[9].Split(',');
                    foreach (string x in mh)
                        sv.MonDK.Add(x);
                    this.Them(sv);

                }
            }

        }
        public List<SinhVien> TimKiemTheoYeuCau(TuyChon kieu, string input)
        {
            List<SinhVien> result = new List<SinhVien>();
            switch (kieu)
            {
                case TuyChon.TheoMa:
                    result = DanhSach.FindAll(x => x.MSSV == input.Trim());
                    break;
                case TuyChon.TheoTen:
                    result = DanhSach.FindAll(x => x.Ten == input.Trim());
                    break;
                case TuyChon.TheoLop:
                    result = DanhSach.FindAll(x => x.Lop == input.Trim());
                    break;
            }

            return result;
        }
        public void convertToJson(string filename)
        {
            string line;
            List<SinhVien> infoSV = new List<SinhVien>();
            using (StreamReader sr = new StreamReader(
            new FileStream(filename,
            FileMode.Open)))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] s = line.Split('\t');
                    infoSV.Add(new SinhVien()
                    {
                        MSSV = s[0],
                        HoTenlot = s[1],
                        Ten = s[2],
                        Phai = (s[3]),
                        NgaySinh = DateTime.Parse(s[4]),
                        Lop = s[5],
                        CMND = s[6],
                        SDT = s[7],
                        DiaChi = s[8],
                        MonDK = s[9].Split(',').ToList(),
                    });
                    string json = JsonConvert.SerializeObject(infoSV.ToArray());
                    File.WriteAllText("DanhSachSV.json", "{\"sinhvien\":" + json + "}");
                }
            }
            
        }
       
        
        
        private void LoadJSON(string Path)
        {
            // Đối tượng đọc tập tin 
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd(); // Đọc hết 
            var array = (JObject)JsonConvert.DeserializeObject(json);
            // Lấy đối tượng sinhvien
            var students = array["sinhvien"].Children();
            foreach (var item in students) // Duyệt mảng
            {
                SinhVien sv = new SinhVien();
                // Lấy các thành phần 
                sv.MSSV = item["MSSV"].Value<string>();
                sv.HoTenlot = item["HoTenlot"].Value<string>();
                sv.Ten = item["Ten"].Value<string>();
                sv.Phai = item["Phai"].Value<string>();
                sv.NgaySinh = DateTime.Parse(item["NgaySinh"].Value<string>());
                sv.Lop = item["Lop"].Value<string>();
                sv.CMND = item["CMND"].Value<string>();
                sv.SDT = item["SDT"].Value<string>();
                sv.DiaChi = item["DiaChi"].Value<string>();
                foreach (var x in item["MonDK"])
                    sv.MonDK.Add(x.Value<string>());
                DanhSach.Add(sv);
              
            }
        }
        public int DocFile(string path)
        {
            string fileType = path.Substring(path.LastIndexOf('.') + 1);
            int ktra;
            if (fileType == "json")
            {
                
                LoadJSON(path);
                ktra = 1;
            }
            else if (fileType == "xml")
            {
                LoadXML(path);
                ktra = 1;
            }
            else if (fileType == "txt")
            {
                LoadTXT(path);
                ktra = 1;
            }
            else
                ktra = 0;
            return ktra;
        }


        private void LoadXML(string path)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var nodeList = xmlDoc.DocumentElement.SelectNodes("/listsinhvien/sinhvien");
            foreach (XmlNode node in nodeList)
            {
                SinhVien sv = new SinhVien();
                sv.MSSV = node.SelectSingleNode("MSSV").InnerText.Trim();
                sv.HoTenlot = node.SelectSingleNode("HoTenlot").InnerText.Trim();
                sv.Ten = node.SelectSingleNode("Ten").InnerText.Trim();
                sv.Phai = node.SelectSingleNode("Phai").InnerText.Trim();
                sv.NgaySinh = DateTime.Parse(node.SelectSingleNode("NgaySinh").InnerText.Trim());
                sv.Lop = node.SelectSingleNode("Lop").InnerText.Trim();
                sv.CMND = node.SelectSingleNode("CMND").InnerText.Trim();
                sv.SDT = node.SelectSingleNode("SDT").InnerText.Trim();
                sv.DiaChi = node.SelectSingleNode("DiaChi").InnerText.Trim();
                string[] monhoc = node.SelectSingleNode("MonDK").InnerText.Split(',');
                foreach (var item in monhoc)
                    sv.MonDK.Add(item.Trim());
                DanhSach.Add(sv);
            }
        }


    }
}
