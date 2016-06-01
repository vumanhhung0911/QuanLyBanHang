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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        dbConnect db = new dbConnect();

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
           // Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.GetData(@"SELECT * FROM dbo.NhanVien WHERE MaNV='" + txtMaNV.Text + "'And MatKhau='" + txtMatKhau.Text+"'");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công");
                Main frm = new Main();
                frm.Show();
                //frm.Hide();

            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác");
            }
            
        }
    }
}
