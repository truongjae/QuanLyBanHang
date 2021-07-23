using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Quanlibanhang
{
    class KhachHang
    {
         string maKH, tenKH, diaChi;
        public KhachHang() { }
        public KhachHang(string maKH, string tenKH, string diaChi)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.diaChi = diaChi;
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
                string maKH = row["Makh"].ToString();
                string tenKH = row["Tenkh"].ToString();
                string diaChi = row["Diachi"].ToString();
                item.Items.Add((i+1).ToString());
                item.Items[i].SubItems.Add(maKH);
                item.Items[i].SubItems.Add(tenKH);
                item.Items[i].SubItems.Add(diaChi);
                i++;
            }
        }
        public void Insert(KhachHang kh)
        {
            string sql = "INSERT INTO KhachHang VALUES('" + kh.maKH+ "','" + kh.tenKH + "','" + kh.diaChi +"')";
            SqlDataAdapter DA = new SqlDataAdapter(sql, conn);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            DA.Update(DT);
            DT.AcceptChanges();
        }

        public void DeleteAll()
        {
            string sql = "DELETE FROM KhachHang";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
        }
        public void Delete(KhachHang kh)
        {
            string sql = "DELETE FROM KhachHang where Makh='" + kh.maKH + "'";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
        }
        public void Update(KhachHang kh)
        {
            string sql = "UPDATE KhachHang set Tenkh='"+kh.tenKH+"',Diachi='"+kh.diaChi+"' where Makh='" + kh.maKH + "'";
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
            string sql = "SELECT Makh FROM KhachHang";
            DataTable DT = new DataTable();
            SqlCommand CMD = new SqlCommand(sql, conn);
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = CMD;
            DA.Fill(DT);
            DT.AcceptChanges();
            foreach (DataRow row in DT.Rows) {
                string maKH = row["Makh"].ToString();
                if (String.Compare(maKH.Trim(), key.Trim(), true) == 0)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
    }

}
