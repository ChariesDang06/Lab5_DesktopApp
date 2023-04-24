using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2112727_DangThiQuynhNhu
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTenlot { get; set; }
        public string Ten { get; set; }
        public string Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public List<string> MonDK { get; set; }
        public SinhVien()
        {
            MonDK = new List<string>();
        }

        public SinhVien(string ms, string ht, string ten, string phai, DateTime ns, string lop,
            string sdt, string cmnd, string dc,   List<string> mh)
        {
            this.MSSV = ms;
            this.HoTenlot = ht;
            this.Ten = ten;
            this.Phai = phai;
            this.NgaySinh = ns;
            this.Lop = lop;
            this.CMND = cmnd;
            this.SDT = sdt;
            this.DiaChi = dc;
            this.MonDK = mh;
        }
        
    }
}
