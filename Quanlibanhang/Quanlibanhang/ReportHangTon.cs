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
    public partial class ReportHangTon : Form
    {
        public ReportHangTon()
        {
            InitializeComponent();
        }

        private void ReportHangTon_Load(object sender, EventArgs e)
        {

            this.report.RefreshReport();
        }
        HoaDon hd = new HoaDon();
        private void button1_Click(object sender, EventArgs e)
        {
            string sql1;
            sql1 = "select Masp, Tensp,Soluong,Dongia from SanPham where Soluong > 0";
            DataTable dt = new DataTable();
            dt = hd.LoadTable(sql1); // Sql chuyển Database thành DataSet
            //Khai báo mode làm việc của reportview
            report.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            report.LocalReport.ReportPath = @"E:\hoc Csharp\Quanlibanhang\Quanlibanhang\Quanlibanhang\Report2.rdlc";
            //Truyền giá trị từ form vào biến cho report
            //đặt nguồn cho report và report viewer
            if (dt.Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet2"; rds.Value = dt;
                report.LocalReport.DataSources.Clear();
                //Add dữ liệu vào
                report.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                report.RefreshReport();
            }
            else
                MessageBox.Show("Không có hàng tồn");
        }
    }
}
