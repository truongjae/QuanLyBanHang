using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlibanhang
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void bảngSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormSanPham();
            form.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bảngKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormKhachHang();
            form.Show();
        }

        private void bảngHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormHoaDon();
            form.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ReportHoaDon();
            form.Show();
        }

        private void hàngTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ReportHangTon();
            form.Show();
        }
    }
}
