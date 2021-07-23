using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Quanlibanhang
{
    public partial class ReportHoaDon : Form
    {
        public ReportHoaDon()
        {
            InitializeComponent();
        }
        HoaDon hd = new HoaDon();
        private void ReportHoaDon_Load(object sender, EventArgs e)
        {
            chonMaKH.DataSource = hd.LoadTable("select * from HoaDon");
            chonMaKH.DisplayMember = "Makh";
            chonMaKH.ValueMember = "Makh";
            this.report.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = chonMaKH.Text;
            string sql1;
            sql1 = "select Makh, Masp,Soluong,Dongia, Soluong*Dongia as Thanhtien from HoaDon where Makh='" + chonMaKH.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = hd.LoadTable(sql1); // Sql chuyển Database thành DataSet
            //Khai báo mode làm việc của reportview
            report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            report.LocalReport.ReportPath = @"E:\hoc Csharp\Quanlibanhang\Quanlibanhang\Quanlibanhang\Report1.rdlc";
            //Truyền giá trị từ form vào biến cho report
            //đặt nguồn cho report và report viewer
            if (dt.Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1"; rds.Value = dt;
                report.LocalReport.DataSources.Clear();
                //Add dữ liệu vào
                report.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                report.RefreshReport();
            }
            else
                MessageBox.Show("Không có dữ liệu");
        }
    }
}
