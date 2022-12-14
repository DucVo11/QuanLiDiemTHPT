using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlidiemTHPT
{
    public partial class fKhoi : Form

    {
        Connection connection;
       
        public fKhoi()
        {
            InitializeComponent();
            connection = new Connection();
        }
        public void ShowKhoi(string sql, DataGridView dg) {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dt.Fill(ds, "Khoi");
            dg.DataSource = ds;
            dg.DataMember = "Khoi";
        }

        private void fKhoi_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            ShowKhoi("SELECT * FROM Khoi", dataGridViewKhoi);
        }

        private void dataGridViewKhoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textKhoi_Ma.Text = dataGridViewKhoi.Rows[e.RowIndex].Cells[0].Value.ToString();
            textKhoi_Ten.Text = dataGridViewKhoi.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String makhoi = textKhoi_Ma.Text;
            String tenkhoi = textKhoi_Ten.Text;
            string capnhat_sql = "UPDATE Khoi SET Khoi_Ten = N'"+ tenkhoi + "' WHERE  Khoi_Ma = '" + makhoi + "'";
            SqlCommand cm = new SqlCommand(capnhat_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Cập nhật Khối thành công");
            ShowKhoi("SELECT * FROM Khoi", dataGridViewKhoi);
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String makhoi = textKhoi_Ma.Text;
            String tenkhoi = textKhoi_Ten.Text;
            string them_sql = "INSERT INTO Khoi VALUES (N'"+ makhoi +"', N'"+tenkhoi +"')";
            SqlCommand cm = new SqlCommand(them_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Thêm Khối thành công");
            ShowKhoi("SELECT * FROM Khoi", dataGridViewKhoi);

        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string makhoi = textKhoi_Ma.Text;
            if (makhoi == "")
            {
                MessageBox.Show("Vui lòng chọn Khối");
            }
            else
            {
                string sql_xoa = "DELETE FROM Khoi WHERE Khoi_Ma = '"+ makhoi +"'";
                SqlCommand cm = new SqlCommand(sql_xoa,conn);
                cm.ExecuteNonQuery();
                MessageBox.Show("Xóa Khối thành công ");
                ShowKhoi("SELECT * FROM Khoi", dataGridViewKhoi);
            }
        }

    }
}
