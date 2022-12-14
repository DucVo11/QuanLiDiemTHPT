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
    public partial class fLop : Form
    {
        Connection connection;
        public fLop()

        {
            InitializeComponent();
            connection = new Connection();
        }
        public void ShowLop(string sql, DataGridView dg)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlDataAdapter dt = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            dt.Fill(ds, "Lop");
            dg.DataSource = ds;
            dg.DataMember = "Lop";

        }
        private void fLop_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            ShowLop("Select Lop_Ma, Lop_Ten, Khoi_Ten, NH_Ten from Lop, Khoi, NamHoc " +
                "where Khoi.Khoi_Ma = Lop.Khoi_Ma " +
                "and NamHoc.NH_Ma = Lop.NH_Ma", dataGridViewLop);
            HienThiComBoBoxKhoi("Select * from Khoi", comboboxKhoi, "Khoi_Ten", "Khoi_Ma");
            HienThiComBoBoxNamHoc("Select * from NamHoc", comboBoxNamhoc, "NH_Ten", "NH_Ma");
        }

        public void HienThiComBoBoxKhoi(String sql, ComboBox cb, string makhoi, string tenkhoi)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlCommand cm = new SqlCommand(sql, conn);
            SqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            cb.DataSource = table;
            cb.DisplayMember = makhoi;
            cb.ValueMember = tenkhoi;
        }
        public void HienThiComBoBoxNamHoc(String sql, ComboBox cb, string maNH, string tenNH)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlCommand cm = new SqlCommand(sql, conn);
            SqlDataReader reader = cm.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            cb.DataSource = table;
            cb.DisplayMember = maNH;
            cb.ValueMember = tenNH;
        }

        private void dataGridViewLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textLop_Ma.Text = dataGridViewLop.Rows[e.RowIndex].Cells[0].Value.ToString();
            textLop_Ten.Text = dataGridViewLop.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboboxKhoi.Text = dataGridViewLop.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxNamhoc.Text = dataGridViewLop.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String malop = textLop_Ma.Text;
            String tenlop = textLop_Ten.Text;
            string makhoi = comboboxKhoi.SelectedValue.ToString();
            string tenkhoi = comboboxKhoi.Text;
            string manamhoc = comboBoxNamhoc.SelectedValue.ToString();
            string tennamhoc = comboBoxNamhoc.Text;
            string them_sql = "INSERT INTO LOP VALUES " +
                "(N'"+ malop + "', N'" + tenlop + "', " +
                "N'" + makhoi + "', " +
                "N'" + manamhoc + "')";
            SqlCommand cm = new SqlCommand(them_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Thêm Lớp thành công");
            ShowLop("Select Lop_Ma, Lop_Ten, Khoi_Ten, NH_Ten from Lop, Khoi, NamHoc " +
                "where Khoi.Khoi_Ma = Lop.Khoi_Ma " +
                "and NamHoc.NH_Ma = Lop.NH_Ma", dataGridViewLop);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            String malop = textLop_Ma.Text;
            String tenlop = textLop_Ten.Text;
            String makhoi = comboboxKhoi.SelectedValue.ToString();
            String tenkhoi = comboboxKhoi.Text;
            String manamhoc = comboBoxNamhoc.SelectedValue.ToString();
            String tennamhoc = comboBoxNamhoc.Text;
            string capnhat_sql = "UPDATE Lop SET Lop_Ten = N'"+ tenlop +"', Khoi_Ma = '"+ makhoi +"', NH_Ma = '"+ manamhoc+"' WHERE Lop_Ma = '"+ malop +"' ";
            SqlCommand cm = new SqlCommand(capnhat_sql, conn);
            cm.ExecuteNonQuery();
            MessageBox.Show("Cập nhật Lớp thành công");
            ShowLop("Select Lop_Ma, Lop_Ten, Khoi_Ten, NH_Ten from Lop, Khoi, NamHoc " +
                "where Khoi.Khoi_Ma = Lop.Khoi_Ma " +
                "and NamHoc.NH_Ma = Lop.NH_Ma", dataGridViewLop);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string malop = textLop_Ma.Text;
            if (malop == "")
            {
                MessageBox.Show("Vui lòng chọn Lớp");
            }
            else
            {
                string sql_xoa = "DELETE FROM Lop WHERE Lop_Ma = '" + malop + "'";
                SqlCommand cm = new SqlCommand(sql_xoa, conn);
                cm.ExecuteNonQuery();
                MessageBox.Show("Xóa Lớp học thành công ");
                ShowLop("Select Lop_Ma, Lop_Ten, Khoi_Ten, NH_Ten from Lop, Khoi, NamHoc " +
                "where Khoi.Khoi_Ma = Lop.Khoi_Ma " +
                "and NamHoc.NH_Ma = Lop.NH_Ma", dataGridViewLop);
            }
        }
    }
    
}

