using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang_120
{
    public partial class frmDVT : Form
    {
        public frmDVT()
        {
            InitializeComponent();
        }

        private bool isInsert = false;
        private string id;
        dbConnect db=new dbConnect();

        void lockControl()
        {
            txtTen.Enabled = false;

            btnMoi.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        void unlockControl()
        {
            txtTen.Enabled = true;

            btnMoi.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        void setnull()
        {
            txtTen.Text = string.Empty;
        }
        void display()
        {
            dgvDVT.DataSource = db.GetData("sp_DonViTinh_SelectAll", null);
        }

        private void btnMoi_Click(object sender, System.EventArgs e)
        {
            unlockControl();
            setnull();
            isInsert = true;
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            unlockControl();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show(@"Bạn có muốn xóa thông tin này không",@"Cảnh báo",MessageBoxButtons.YesNo))
            {
                try
                {
                    SqlParameter[] p =
                    {
                        new SqlParameter("@ID",id)
                    };
                    db.ExeSQL("sp_DonViTinh_Delete", p);
                    display();
                    lockControl();
                    setnull();
                }
                catch
                {

                }
            }

           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isInsert == true)
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@TenDVT",txtTen.Text) 
                };
                db.ExeSQL("sp_DonViTinh_Insert", p);
                lockControl();
                setnull();
                display();
            }
            else
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@ID",id), 
                    new SqlParameter("@TenDVT",txtTen.Text)
                };
                db.ExeSQL("sp_DonViTinh_Update", p);
                lockControl();
                setnull();
                display();
            }
        }

        private void frmDVT_Load(object sender, EventArgs e)
        {
            lockControl();
            setnull();
            display();
        }

        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<0)
                return;
            id = dgvDVT.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dgvDVT.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
