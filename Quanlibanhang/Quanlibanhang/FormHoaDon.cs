using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quanlibanhang
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        int valdonGia = 0, valsoLuong = 0;
        string  valmaKH = "", valmaSP = "";
        HoaDon hd = new HoaDon();
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            chonMaKH.DataSource = hd.LoadTable("select * from KhachHang");
            chonMaKH.DisplayMember = "Makh";
            chonMaKH.ValueMember = "Makh";
            chonMaSP.DataSource = hd.LoadTable("select * from SanPham");
            chonMaSP.DisplayMember = "Masp";
            chonMaSP.ValueMember = "Masp";
            hd.HienThi_ListView(tableHoaDon,"SELECT * FROM HoaDon");
            changeSelectSP(sender, e);
        
        }
        public void changeSelectSP(object sender, EventArgs e)
        {

            HoaDon hd = new HoaDon();
            hd.Change("SELECT Dongia from SanPham where Masp='"+chonMaSP.SelectedValue.ToString()+"'",txtDonGia);

        }

        private void tableHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            hd.HienThi_ListView(tableHoaDon, "SELECT * FROM HoaDon");

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int sl=0;
            SqlConnection conn = new SqlConnection(@"Data Source=TRUONGJAE\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand("select * from SanPham where Masp='"+chonMaSP.SelectedValue.ToString()+"'", conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows)
            {
                sl =Int32.Parse(row["Soluong"].ToString());
                break;
            }
            bool check = true;

            try
            {
                if (sl <= 0)
                {
                    check = false;
                    MessageBox.Show("Số lượng sản phẩm trong kho đã hết.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (Int32.Parse(txtSoLuong.Text) > sl)
                {
                    check = false;
                    MessageBox.Show("Số lượng sản phẩm trong kho không đủ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.FormatException) {
                check = false;
                MessageBox.Show("Số Lượng Không Được Để Trống Hoặc Chứa Kí Tự Đặc Biệt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(check){
                int donGia1 = Int32.Parse(txtDonGia.Text);
                int soLuong1 = Int32.Parse(txtSoLuong.Text);
                string maKH1 = chonMaKH.SelectedValue.ToString();
                string maSP1 = chonMaSP.SelectedValue.ToString();
                string sqlconn = "INSERT INTO HoaDon (Makh, Masp, Soluong,Dongia) VALUES ('" + maKH1 + "' ,'" + maSP1 + "', " + soLuong1 + " , " + donGia1 +
                    ");UPDATE SanPham set Soluong =" + (sl - Int32.Parse(txtSoLuong.Text)) + " where Masp='" + maSP1 + "'";
                hd.Excecute(sqlconn);
                hd.HienThi_ListView(tableHoaDon, "SELECT * FROM HoaDon");
            }
            }
        private void button2_Click(object sender, EventArgs e)
        {
            int slsp = 0;
            SqlConnection conn = new SqlConnection(@"Data Source=TRUONGJAE\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand("select * from SanPham where Masp='" + valmaSP + "'", conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows)
            {
                slsp = Int32.Parse(row["Soluong"].ToString());
                break;
            }
            bool check = true;

            try
            {
               if (Int32.Parse(txtSoLuong.Text) > slsp+valsoLuong)
                {
                    check = false;
                    MessageBox.Show("Số lượng sản phẩm trong kho không đủ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.FormatException)
            {
                check = false;
                MessageBox.Show("Số Lượng Không Được Để Trống Hoặc Chứa Kí Tự Đặc Biệt.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (check)
            {
                int donGia1 = Int32.Parse(txtDonGia.Text);
                int soLuong1 = Int32.Parse(txtSoLuong.Text);
                string maKH1 = chonMaKH.SelectedValue.ToString();
                string maSP1 = chonMaSP.SelectedValue.ToString();
                string sqlconn;
                sqlconn = "UPDATE HoaDon set Makh='" + maKH1 + "', Masp='" + maSP1 + "', Dongia='" + donGia1 + "', Soluong='" + soLuong1 + "' where Makh='" + valmaKH + "' and Masp='" + valmaSP + "' and Dongia=" + valdonGia + " and Soluong=" + valsoLuong;
                hd.Excecute(sqlconn);
                hd.HienThi_ListView(tableHoaDon, "SELECT * FROM HoaDon");
                sqlconn = "UPDATE SanPham set Soluong='" + (slsp + valsoLuong - Int32.Parse(txtSoLuong.Text)) + "' where Masp='" + valmaSP + "'";
                hd.Excecute(sqlconn);
            }
        }

        private void tableHoaDon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tableHoaDon.SelectedItems)
            {
                chonMaKH.DisplayMember = item.SubItems[1].Text;
                chonMaKH.Text = item.SubItems[1].Text;
                //chonMaKH.ValueMember = item.SubItems[1].Text;
                chonMaSP.DisplayMember = item.SubItems[2].Text;
                chonMaSP.Text = item.SubItems[2].Text;
                //chonMaSP.ValueMember = item.SubItems[1].Text;
                txtSoLuong.Text = item.SubItems[3].Text;
                txtDonGia.Text = item.SubItems[4].Text;
                valmaKH = item.SubItems[1].Text;
                valmaSP = item.SubItems[2].Text;
                valsoLuong = Int32.Parse(item.SubItems[3].Text);
                valdonGia = Int32.Parse(item.SubItems[4].Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sl = 0;
            SqlConnection conn = new SqlConnection(@"Data Source=TRUONGJAE\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand("select * from SanPham where Masp='" + chonMaSP.SelectedValue.ToString() + "'", conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows)
            {
                sl = Int32.Parse(row["Soluong"].ToString());
                break;
            }
            int donGia1 = Int32.Parse(txtDonGia.Text);
            int soLuong1 = Int32.Parse(txtSoLuong.Text);
            string maKH1 = chonMaKH.SelectedValue.ToString();
            string maSP1 = chonMaSP.SelectedValue.ToString();
            string sqlconn;
            sqlconn = "DELETE HoaDon where Makh='" + valmaKH + "' and Masp='" + valmaSP + "' and Dongia=" + valdonGia + " and Soluong=" + valsoLuong
                + ";" + "UPDATE SanPham set Masp='" + maSP1 + "', Soluong='" + (sl+soLuong1) + "' where Masp='" + valmaSP + "'";
            hd.Excecute(sqlconn);
            hd.HienThi_ListView(tableHoaDon, "SELECT * FROM HoaDon");
        }
    

    

    }
}
