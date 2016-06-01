using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanHang_120
{
    public class dbConnect
    {
        SqlConnection sqlcon=new SqlConnection(@"Server=HUNG-VU\SQLEXPRESS;Database=QlBanHang;User Id=sa;Password = 123456789;");

        public int ExeSQL(string strSQL)
        {
            sqlcon.Open();
            var sqlcmd = new SqlCommand(strSQL,sqlcon);//insert,update,delete
            var rownum = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            return rownum;
        }

        public int ExeSQL(string procName, SqlParameter[] para)
        {
            var sqlcmd=new SqlCommand();
            sqlcmd.CommandType=CommandType.StoredProcedure;
            sqlcmd.CommandText = procName;
            sqlcmd.Connection = sqlcon;
            if(para!=null)
                sqlcmd.Parameters.AddRange(para);
            sqlcon.Open();
            int numrow = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            return numrow;
        }

        public DataTable GetData(string strSQL)
        {
            var dt=new DataTable();
            var sqlda=new SqlDataAdapter(strSQL,sqlcon);//select
            sqlcon.Open();
            sqlda.Fill(dt);
            sqlcon.Close();
            return dt;
        }

        public DataTable GetData(string procName, SqlParameter[] para)
        {
            var dt=new DataTable();
            var sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = procName;
            sqlcmd.Connection = sqlcon;
            if (para != null)
                sqlcmd.Parameters.AddRange(para);
            sqlcon.Open();
            var da=new SqlDataAdapter();
            da.SelectCommand = sqlcmd;
            da.Fill(dt);
            sqlcon.Close();
            return dt;
        }
    }
}
