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
    public partial class DanhSachCacMatHang : Form
    {
        public DanhSachCacMatHang()
        {
            InitializeComponent();
        }
        dbConnect db = new dbConnect();
        void LoadTreeView()
        {
            var dt = new DataTable();
            dt = db.GetData("Select * from LoaiHang");
            // lay tat ca cac record trong bang loai hang
            foreach (DataRow row in dt.Rows)
            {
                // tao mot not cho tree view
                var node = new TreeNode();
                node.Text = row["TenLoai"].ToString();
                node.Tag = row["MaLoai"].ToString();
                //gan hinh anh cho node
                node.ImageIndex = 0;
                //add node vao trong tree view
                twLoaiHang.Nodes.Add(node);
            }
        }

        private void DanhSachCacMatHang_Load(object sender, EventArgs e)
        {
            LoadTreeView();
        }
    }
}
