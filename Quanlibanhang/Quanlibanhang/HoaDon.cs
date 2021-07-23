using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Quanlibanhang
{
    class HoaDon
    {
        public HoaDon() { }
        public SqlConnection conn = new SqlConnection(@"Data Source=TRUONGJAE\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
        public DataTable LoadTable(string sql)
        {
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(sql,conn);
            DA.Fill(DT);
            DT.AcceptChanges();
            return DT;
        }
        public void Excecute(string sql)
        {
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            try
            {
                DA.Fill(DT);
                DT.AcceptChanges();
            }
            catch (System.Data.SqlClient.SqlException) {
                MessageBox.Show("Thông Tin Khách Hàng Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void HienThi_ListView(ListView item, string sql)
        {
            item.Items.Clear();
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            int i = 0;
            foreach (DataRow row in DT.Rows)
            {
                string maKH = row["Makh"].ToString();
                string maSP = row["Masp"].ToString();
                string soLuong = row["Soluong"].ToString();
                string donGia = row["Dongia"].ToString();
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(maKH);
                item.Items[i].SubItems.Add(maSP);
                item.Items[i].SubItems.Add(soLuong);
                item.Items[i].SubItems.Add(donGia);
                i++;
            }
        }
        public void Change(string sql,TextBox box) { 
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows)
            {
                box.Text = (Int32.Parse(row["Dongia"].ToString())+1000).ToString();
                break;
            } 
        }
    }
}
