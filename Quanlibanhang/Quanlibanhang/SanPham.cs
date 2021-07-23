using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Quanlibanhang
{
    class SanPham
    {
        string maSP, tenSP;
        int soLuong;
        int donGia;
        public SanPham() { }
        public SanPham(string maSP, string tenSP, int soLuong, int donGia)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=TRUONGJAE\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
        public void HienThi_ListView(ListView item, string sql){
            item.Items.Clear();
            DataTable DT =  new DataTable();
            SqlCommand CMD = new SqlCommand(sql,conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            int i =0;
            foreach(DataRow row in DT.Rows){
                string maSP = row["Masp"].ToString();
                string tenSP = row["Tensp"].ToString();
                string soLuong = row["Soluong"].ToString();
                string donGia = row["Dongia"].ToString();
                item.Items.Add((i+1).ToString());
                item.Items[i].SubItems.Add(maSP);
                item.Items[i].SubItems.Add(tenSP);
                item.Items[i].SubItems.Add(donGia);
                item.Items[i].SubItems.Add(soLuong);
                i++;
            }
        }
        public void Insert(SanPham sp)
        {
            string sql = "INSERT INTO SanPham VALUES('" + sp.maSP + "','" + sp.tenSP + "','" + sp.soLuong + "'," + sp.donGia + ")";
            SqlDataAdapter DA = new SqlDataAdapter(sql, conn);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            DA.Update(DT);
            DT.AcceptChanges();
        }

        public void DeleteAll()
        {
            string sql = "DELETE FROM SanPham";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
        }
        public void Delete(SanPham sp)
        {
            string sql = "DELETE FROM SanPham where Masp='" + sp.maSP + "'";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
        }
        public void Update(SanPham sp)
        {
            string sql = "UPDATE SanPham set Tensp='"+sp.tenSP+"',Soluong='"+sp.soLuong+"',Dongia='"+sp.donGia+"' where Masp='" + sp.maSP + "'";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
        }
        public bool checkKey(string key)
        {
            bool check = false;
            string sql = "SELECT Masp FROM SanPham";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows) {
                string maSP = row["Masp"].ToString();
                if (String.Compare(maSP.Trim(), key.Trim(), true) == 0)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
    }
}
