using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanHang_120
{
    public partial class frmLoaiHang : Form
    {
        public frmLoaiHang()
        {
            InitializeComponent();
        }
        dbConnect db = new dbConnect();
        private bool isInsert = false;
        void setnull()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        void lockcontrol()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtGhiChu.Enabled = false;

            btnMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        void unlockcontrol()
        {
            txtMa.Enabled = true;
            txtTen.Enabled = true;
            txtGhiChu.Enabled = true;

            btnMoi.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        void loadGridview()
        {
            dgvLoaiHang.DataSource = db.GetData("Select * from LoaiHang");
        }
        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            lockcontrol();
           loadGridview();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            isInsert = true;
            unlockcontrol();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isInsert = false;
            unlockcontrol();
            txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Delete from LoaiHang where MaLoai = '" + txtMa.Text + "' ";
                db.ExeSQL(str);
                lockcontrol();
                setnull();
                loadGridview();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            dt = db.GetData("SELECT COUNT(maloai) as numcount FROM dbo.LoaiHang WHERE MaLoai='" + txtMa.Text + "'");
            if (isInsert == true)
            {
                if ((int)dt.Rows[0]["numcount"] > 0)
                    MessageBox.Show("Mã này đã tồn tại. Xin chọn lại");
                else
                {
                    string sql = "Insert into LoaiHang values('" + txtMa.Text + "',N'" + txtTen.Text + "',N'" +
                                 txtGhiChu.Text + "')";
                    int numrow = db.ExeSQL(sql);
                    if (numrow > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        lockcontrol();
                        setnull();
                        loadGridview();
                    }
                    else
                        MessageBox.Show("Lỗi");
                }
            }
            else
            {
                string sql = "Update LoaiHang Set TenLoai= N'" + txtTen.Text + "',MoTa=N'" +txtGhiChu.Text + "' where MaLoai= '" + txtMa.Text + "'";
                int numrow = db.ExeSQL(sql);
                if (numrow > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    lockcontrol();
                    setnull();
                    loadGridview();
                }
                else
                    MessageBox.Show("Lỗi");
            }
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
                return;
            txtMa.Text = dgvLoaiHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dgvLoaiHang.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGhiChu.Text = dgvLoaiHang.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
