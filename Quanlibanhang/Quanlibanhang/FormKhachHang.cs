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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text);
            if (kh.checkKey(txtMaKH.Text))
            {
                DialogResult result = MessageBox.Show("Mã Khách Hàng Đã Tồn Tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                kh.Insert(kh);
                FormKhachHang_Load(sender, e);
            }
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.HienThi_ListView(tableKH, "SELECT * FROM KhachHang");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text);
            kh.Update(kh);
            kh.HienThi_ListView(tableKH, "SELECT * FROM KhachHang");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            KhachHang kh = new KhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text);
            kh.Delete(kh);
            kh.HienThi_ListView(tableKH, "SELECT * FROM KhachHang");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.DeleteAll();
            kh.HienThi_ListView(tableKH, "SELECT * FROM KhachHang");
        }

        private void tableKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tableKH.SelectedItems)
            {
                txtTenKH.Text = item.SubItems[1].Text;
                txtMaKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
            }
        }
    }
}
