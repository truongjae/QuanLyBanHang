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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.HienThi_ListView(tableSP,"SELECT * FROM SanPham");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham(txtMaSP.Text,txtTenSP.Text,Int32.Parse(txtSoluong.Text),Int32.Parse(txtDongia.Text));
            if (sp.checkKey(txtMaSP.Text))
            {
                DialogResult result = MessageBox.Show("Mã Sản Phẩm Đã Tồn Tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else{
                sp.Insert(sp);
                FormSanPham_Load(sender,e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.DeleteAll();
            sp.HienThi_ListView(tableSP, "SELECT * FROM SanPham");
        }

        private void tableSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tableSP.SelectedItems)
            {
                txtMaSP.Text = item.SubItems[1].Text;
                txtTenSP.Text = item.SubItems[2].Text;
                txtDongia.Text = item.SubItems[3].Text;
                txtSoluong.Text = item.SubItems[4].Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text, Int32.Parse(txtSoluong.Text), Int32.Parse(txtDongia.Text));
            sp.Delete(sp);
            sp.HienThi_ListView(tableSP, "SELECT * FROM SanPham");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text, Int32.Parse(txtSoluong.Text), Int32.Parse(txtDongia.Text));
            sp.Update(sp);
            sp.HienThi_ListView(tableSP, "SELECT * FROM SanPham");
        }
    }
}
