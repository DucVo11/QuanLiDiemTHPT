using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanlidiemTHPT
{
    public partial class fHocSinh : Form
    {
        Connection connection;
        public fHocSinh()
        {
            connection = new Connection();
            InitializeComponent();
        }

        public void ShowData(string truyvanDB, DataGridView dg)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlDataAdapter dta = new SqlDataAdapter(truyvanDB, conn);
            DataSet ds = new DataSet();
            dta.Fill(ds, "HocSinh");
            dg.DataSource = ds;
            dg.DataMember = "HocSinh";

        }

        private void fHocSinh_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            
            HienThiCombobox("Select * from Khoi", Tkkhoihs, "khoi_ma","Khoi_Ten");
            HienThiCombobox("Select * from Lop where khoi_ma= 'K01'", Tklophs,"lop_ma", "Lop_Ten");
            HienThiCombobox("Select * from Lop", Lophs, "lop_ma","Lop_Ten");

        }

        private void luoidatahs(object sender, DataGridViewCellEventArgs e)
        {
            Mahs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[0].Value.ToString();
            Tenhs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[1].Value.ToString();
            Dchihs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[2].Value.ToString();
            Gtinhhs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[3].Value.ToString();
            Emailhs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[4].Value.ToString();
            Nsinhhs.Text = luoidulieuhs.Rows[e.RowIndex].Cells[5].Value.ToString();
            Sdths.Text = luoidulieuhs.Rows[e.RowIndex].Cells[6].Value.ToString();
        }


    
        public void HienThiCombobox(string query, ComboBox comb, string ma, string ten)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlCommand sql = new SqlCommand(query, conn);
            SqlDataReader read = sql.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(read);
            comb.DataSource = dt;
            comb.DisplayMember = ten;
            comb.ValueMember = ma;
            conn.Close();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string newQuery = "select SUBSTRING(MAX(HS_MA),3,2)+1 " +
                      "from HocSinh";
            SqlDataAdapter dt = new SqlDataAdapter(newQuery, conn);
            DataSet dase = new DataSet();
            dt.Fill(dase);
            int a = (int)dase.Tables[0].Rows[0][0];
            string newMaHS = "HS0" + a.ToString();

            btnLuu.Enabled = true;

            Mahs.Text = newMaHS;
            Mahs.Enabled = false;
            Tenhs.Text = "";
            Dchihs.Text = "";
            Gtinhhs.Text = "";
            Emailhs.Text = "";
            Nsinhhs.Text = "";
            Sdths.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String MaHS = Mahs.Text;
            String HoTen = Tenhs.Text;
            String Dchi = Dchihs.Text;
            String Gtinh = Gtinhhs.Text;
            String Email = Emailhs.Text;
            String Ngsinh = Nsinhhs.Text;
            String Sdt = Sdths.Text;
            String lopma = Lophs.SelectedValue.ToString();
            String tenlop = Lophs.Text;

            string luu_sql = "insert into HocSinh values ( N'" + MaHS + "', N'" + HoTen + "', N'" + Dchi + "', N'" + Gtinh + "', N'" + Email + "', N'" + Ngsinh + "',  N'" + Sdt + "', N'" + lopma + "')";
            SqlCommand luu = new SqlCommand(luu_sql, conn);
            luu.ExecuteNonQuery();
            MessageBox.Show("Lưu thành công");
            ShowData("select HS_Ma, HS_HoTen, HS_DiaChi, HS_GioiTinh, HS_Gmail, HS_NgaySinh, HS_SDT from HocSinh h, lop l where h.lop_ma = l.lop_ma and lop_ten = N'" + tenlop + "'", luoidulieuhs);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String MaHS = Mahs.Text;
            String HoTen = Tenhs.Text;
            String Dchi = Dchihs.Text;
            String Gtinh = Gtinhhs.Text;
            String Email = Emailhs.Text;
            String Ngsinh = Nsinhhs.Text;
            String Sdt = Sdths.Text;
            string lopma = Lophs.SelectedValue.ToString();
            string tenlop =  Lophs.Text;

            string sua_sql = "update HocSinh set HS_HoTen = N'" + HoTen + "', HS_DiaChi = N'" + Dchi + "', HS_GioiTinh = N'" + Gtinh + "', HS_Gmail = N'" + Email + "', HS_NgaySinh = N'" + Ngsinh + "', HS_SDT = N'" + Sdt + "', Lop_Ma = N'" + lopma + "' where HS_Ma = '" + MaHS + "'";
            SqlCommand sua = new SqlCommand(sua_sql, conn);
            sua.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công");
            ShowData("select HS_Ma, HS_HoTen, HS_DiaChi, HS_GioiTinh, HS_Gmail, HS_NgaySinh, HS_SDT from HocSinh h, lop l where h.lop_ma = l.lop_ma and lop_ten = N'" + tenlop + "'", luoidulieuhs);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string tenlop = Lophs.Text;
            string MaHS = Mahs.Text;
            if (MaHS == "")
            {
                MessageBox.Show("Chưa chọn học sinh");
            }
            else
            {
                SqlCommand xoa_sql = new SqlCommand("Delete from HocSinh where HS_Ma = '" + MaHS + "'", conn);

                xoa_sql.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
         
                ShowData("select HS_Ma, HS_HoTen, HS_DiaChi, HS_GioiTinh, HS_Gmail, HS_NgaySinh, HS_SDT from HocSinh h, lop l where h.lop_ma = l.lop_ma and lop_ten = N'" + tenlop + "'", luoidulieuhs);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tkkhoihs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoi = Tkkhoihs.SelectedValue.ToString();
            HienThiCombobox("select *from lop where khoi_ma = '"+ makhoi +"'", Tklophs,"khoi_ma", "khoi_ten");
        }

        private void Tklophs_TextChanged(object sender, EventArgs e)
        {
            string tenlop = Tklophs.Text;
            ShowData("select HS_Ma, HS_HoTen, HS_DiaChi, HS_GioiTinh, HS_Gmail, HS_NgaySinh, HS_SDT from HocSinh h, lop l where h.lop_ma = l.lop_ma and lop_ten = N'" + tenlop + "'", luoidulieuhs);

        }
    }
}
