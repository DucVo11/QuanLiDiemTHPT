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
    public partial class fMonHoc : Form
    {
        Connection connection;

        public fMonHoc()
        {
            InitializeComponent();
            connection = new Connection();
        }
        public void ShowMonHoc(string sql, DataGridView dg)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dt.Fill(ds, "MonHoc");
            dg.DataSource = ds;
            dg.DataMember = "MonHoc";
        }

        private void fMonHoc_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            ShowMonHoc("SELECT * FROM MonHoc", dataGridViewMonHoc);
        }

        private void dataGridViewMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textMH_Ma.Text = dataGridViewMonHoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            textMH_Ten.Text = dataGridViewMonHoc.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String mamonhoc = textMH_Ma.Text;
            String tenmonhoc = textMH_Ten.Text;
            string them_sql = "INSERT INTO MonHoc VALUES (N'"+ mamonhoc +"', N'"+ tenmonhoc +"')";
            SqlCommand cm = new SqlCommand(them_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Thêm Môn học thành công");
            ShowMonHoc("SELECT * FROM MonHoc", dataGridViewMonHoc);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String mamonhoc = textMH_Ma.Text;
            String tenmonhoc = textMH_Ten.Text;
            string capnhat_sql = "UPDATE MonHoc SET MH_Ten = N'"+ tenmonhoc +"' WHERE MH_Ma = '"+ mamonhoc +"'";
            SqlCommand cm = new SqlCommand(capnhat_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Cập nhật Môn học thành công");
            ShowMonHoc("SELECT * FROM MonHoc", dataGridViewMonHoc);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string mamonhoc = textMH_Ma.Text;
            if (mamonhoc == "")
            {
                MessageBox.Show("Vui lòng chọn Môn Học");
            }
            else
            {
                string sql_xoa = "DELETE FROM MonHoc WHERE MH_Ma = '" + mamonhoc + "'";
                SqlCommand cm = new SqlCommand(sql_xoa, conn);
                cm.ExecuteNonQuery();
                MessageBox.Show("Xóa Môn học thành công ");
                ShowMonHoc("SELECT * FROM MonHoc", dataGridViewMonHoc);
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
