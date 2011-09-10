using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinQToXML1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private XDocument LoadXmlDocument(string url)
        {
            //Hàm load một file xml vào đối tượng XDocument
            try
            {
                return XDocument.Load(url);
            }
            catch
            {
                return null;
            }
        }

        private void LoadData()
        {
            //Hàm nạp dữ liệu từ file xml vào DataGridView
            //Load xml file to Xdocument
            XDocument doc = LoadXmlDocument("NhanVien.xml");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Mã Nhân Viên");
            dtb.Columns.Add("Họ Tên");
            dtb.Columns.Add("Ngày Sinh");
            dtb.Columns.Add("Giới Tính");
            dtb.Columns.Add("Địa Chỉ");
            dtb.Columns.Add("Số Điện Thoại");

            foreach (XElement p in doc.Descendants("NhanVien"))
            {
                DataRow row = dtb.NewRow();
                row[0] = p.Attribute("MaNhanVien").Value;
                row[1] = p.Element("HoTen").Value;
                row[2] = p.Element("NgaySinh").Value;
                row[3] = p.Element("GioiTinh").Value;
                row[4] = p.Element("DiaChi").Value;
                row[5] = p.Element("SoDT").Value;
                dtb.Rows.Add(row); // Thêm dòng mới vào dtb
            }

            datagridviewKQ.DataSource = dtb;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void datagridviewKQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lấy thông tin dòng hiện tại hiển thị ra các textbox, combobox...
            if (e.RowIndex >= 0 && e.RowIndex < datagridviewKQ.Rows.Count)
            {
                DataGridViewRow row = datagridviewKQ.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dtNgaySinh.Text = row.Cells[2].Value.ToString();
                cbbGioiTinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtSoDT.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
            //txtMaNV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length!=0)
            {
                //Load xml document
                XDocument doc = LoadXmlDocument("NhanVien.xml");
                if (doc.Descendants("NhanVien").Where(x => x.Attribute("MaNhanVien").Value.Equals(txtMaNV.Text)).Count() == 1)
                {
                    //Nếu đã tồn tại sản phẩm có ID này rồi thì thực hiện cập nhật
                    XElement ele = doc.Descendants("NhanVien").Where(x => x.Attribute("MaNhanVien").Value.Equals(txtMaNV.Text)).First();
                    ele.Element("HoTen").Value = txtHoTen.Text;
                    ele.Element("NgaySinh").Value = dtNgaySinh.Text;
                    ele.Element("GioiTinh").Value = cbbGioiTinh.Text;
                    ele.Element("DiaChi").Value =  txtDiaChi.Text;
                    ele.Element("SoDT").Value =  txtSoDT.Text;
                    doc.Save("NhanVien.xml");
                    MessageBox.Show("Cập Nhật Thông Tin Nhân Viên Thành Công!");
                }
                else
                {
                    //Nếu chưa tồn tại product với id trên thì thêm mới
                    doc.Descendants("NhanVien").Last().AddAfterSelf(new XElement("NhanVien",
                                                                    new XAttribute("MaNhanVien", txtMaNV.Text),
                                                                    new XElement("HoTen", txtHoTen.Text),
                                                                    new XElement("NgaySinh", dtNgaySinh.Text),
                                                                    new XElement("GioiTinh", cbbGioiTinh.Text),
                                                                    new XElement("DiaChi", txtDiaChi.Text),
                                                                    new XElement("SoDT", txtSoDT.Text)));
                    doc.Save("NhanVien.xml");                    
                    MessageBox.Show("Thêm Nhân Viên Thành Công!");
                }
                //txtMaNV.Enabled = false;
                LoadData();
            }
            
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            XDocument doc = LoadXmlDocument("NhanVien.xml");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("Mã Nhân Viên");
            dtb.Columns.Add("Họ Tên");
            dtb.Columns.Add("Ngày Sinh");
            dtb.Columns.Add("Giới Tính");
            dtb.Columns.Add("Địa Chỉ");
            dtb.Columns.Add("Số Điện Thoại");

            DataRow row = dtb.NewRow();
            foreach (XElement p in doc.Descendants("NhanVien"))
            {                
                row[0] = p.Attribute("MaNhanVien").Value;
            }
            string chuoi = row[0].ToString();
            
            if (chuoi.Equals(""))
                txtMaNV.Text = "NV001";
            else
            {                
                //int so = int.Parse(chuoi.Split('V')[1]);
                int so = int.Parse(chuoi.Substring(2));
                so++;
                if (so < 10)
                    txtMaNV.Text = "NV00" + so.ToString();
                else if (so < 100)
                    txtMaNV.Text = "NV0" + so.ToString();
                else
                    txtMaNV.Text = "NV" + so.ToString();
            }            
        }
       
    }
}
