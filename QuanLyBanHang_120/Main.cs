using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_120
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDVT();
            frm.MdiParent = this;
            frm.Show();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmLoaiHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void danhSáchHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DanhSachCacMatHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
