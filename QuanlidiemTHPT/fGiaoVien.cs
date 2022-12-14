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
    public partial class fGiaoVien : Form
    {
        Connection connection;


        public fGiaoVien()
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
            dta.Fill(ds, "GiaoVien");
            dg.DataSource = ds;
            dg.DataMember = "GiaoVien";

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

        private void luoidatahs(object sender, DataGridViewCellEventArgs e)
        {
            Magv.Text = luoidulieugv.Rows[e.RowIndex].Cells[0].Value.ToString();
            Tengv.Text = luoidulieugv.Rows[e.RowIndex].Cells[1].Value.ToString();
            Tendngv.Text = luoidulieugv.Rows[e.RowIndex].Cells[2].Value.ToString();
            Gtinhgv.Text = luoidulieugv.Rows[e.RowIndex].Cells[3].Value.ToString();
            Dchigv.Text = luoidulieugv.Rows[e.RowIndex].Cells[4].Value.ToString();
            Nsinhgv.Text = luoidulieugv.Rows[e.RowIndex].Cells[5].Value.ToString();
            Emailgv.Text = luoidulieugv.Rows[e.RowIndex].Cells[6].Value.ToString();
            Sdtgv.Text = luoidulieugv.Rows[e.RowIndex].Cells[7].Value.ToString();
            Quyengv.Text = luoidulieugv.Rows[e.RowIndex].Cells[8].Value.ToString();
            Cvugv.Text = luoidulieugv.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void fGiaoVien_Load(object sender, EventArgs e)
        {

            HienThiCombobox("Select * from ChucVu", Cvugv, "CV_Ma", "CV_Ten");
            HienThiCombobox("Select * from Quyen", Quyengv, "Quyen_Ma", "Quyen_Ten");
            HienThiCombobox("Select * from ChucVu", Tkcvugv, "CV_Ma", "CV_Ten");
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            ShowData("select GV_Ma, GV_HoTen, GV_TenDN, GV_GioiTinh, GV_DiaChi, GV_NgaySinh, GV_Gmail, GV_SDT, Quyen_Ten, CV_Ten  from GiaoVien g, ChucVu c, Quyen q where g.cv_ma = c.cv_ma and g.quyen_ma = q.quyen_ma ", luoidulieugv);
        }

 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string newQuery = "select SUBSTRING(MAX(GV_MA),3,2)+1 " +
                      "from GiaoVien";
            SqlDataAdapter dt = new SqlDataAdapter(newQuery, conn);
            DataSet dase = new DataSet();
            dt.Fill(dase);
            int a = (int)dase.Tables[0].Rows[0][0];
            string newMaGV = "GV0" + a.ToString();

            btnLuu.Enabled = true;

            Magv.Text = newMaGV;
            Magv.Enabled = false;
            Tengv.Text = "";
            Tendngv.Text = "";
            mkgv.Text = "";
            Nlmkgv.Text = "";
            Gtinhgv.Text = "";
            Dchigv.Text = "";
            Nsinhgv.Text = "";
            Emailgv.Text = "";
            Sdtgv.Text = "";
            Quyengv.Text = "";
            Cvugv.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String MaGV = Magv.Text;
            String HoTen = Tengv.Text;
          
            String GT = Gtinhgv.Text;
            String DC = Dchigv.Text;
            String NS = Nsinhgv.Text;
            String EMI = Emailgv.Text;
            String SDT = Sdtgv.Text;
            String Quyen = Quyengv.SelectedValue.ToString();
            String CV = Cvugv.SelectedValue.ToString();

                string sua_sql = "update GiaoVien set  GV_HoTen = N'" + HoTen + "', GV_GioiTinh = N'" + GT + "', GV_DiaChi = N'" + DC + "', GV_NgaySinh = N'" + NS + "',  GV_Gmail = N'" + EMI + "',GV_SDT =  N'" + SDT + "', Quyen_Ma = N'" + Quyen + "', CV_MA =  N'" + CV + "' where GV_MA = N'" + MaGV + "'";
                SqlCommand sua = new SqlCommand(sua_sql, conn);
                sua.ExecuteNonQuery();
   

 
           MessageBox.Show("Sửa thành công");
            ShowData("select GV_Ma, GV_HoTen, GV_TenDN, GV_GioiTinh, GV_DiaChi, GV_NgaySinh, GV_Gmail, GV_SDT, Quyen_Ten, CV_Ten  from GiaoVien g, ChucVu c, Quyen q where g.cv_ma = c.cv_ma and g.quyen_ma = q.quyen_ma ", luoidulieugv);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string MaGV = Magv.Text;
            if (MaGV == "")
            {
                MessageBox.Show("Chưa chọn giáo viên");
            }
            else
            {
                SqlCommand xoa_sql = new SqlCommand("Delete from GiaoVien where GV_Ma = '" + MaGV + "'", conn);

                xoa_sql.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");

                ShowData("select GV_Ma, GV_HoTen, GV_TenDN, GV_GioiTinh, GV_DiaChi, GV_NgaySinh, GV_Gmail, GV_SDT, Quyen_Ten, CV_Ten  from GiaoVien g, ChucVu c, Quyen q where g.cv_ma = c.cv_ma and g.quyen_ma = q.quyen_ma ", luoidulieugv);

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String MaGV = Magv.Text;
            String HoTen = Tengv.Text;
            String TenDN = Tendngv.Text;
            String MK = mkgv.Text;
            String Nlmk = Nlmkgv.Text;
            String GT = Gtinhgv.Text;
            String DC = Dchigv.Text;
            String NS = Nsinhgv.Text ;
            String EMI = Emailgv.Text;
            String SDT = Sdtgv.Text;
            String Quyen = Quyengv.SelectedValue.ToString();
            String CV = Cvugv.SelectedValue.ToString();

            if (MK == Nlmk)
            {
                string luu_sql = "insert into GiaoVien values ( N'" + MaGV + "', N'" + HoTen + "', N'" + TenDN + "', N'" + MK + "', N'" + GT + "',  N'" + DC + "', N'" + NS + "',  N'" + EMI + "',  N'" + SDT + "',  N'" + Quyen + "',  N'" + CV + "')";
                SqlCommand luu = new SqlCommand(luu_sql, conn);
                luu.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Hai mật khẩu không giống nhau");
            }


          
            MessageBox.Show("Lưu thành công");
            ShowData("select GV_Ma, GV_HoTen, GV_TenDN, GV_GioiTinh, GV_DiaChi, GV_NgaySinh, GV_Gmail, GV_SDT, Quyen_Ten, CV_Ten  from GiaoVien g, ChucVu c, Quyen q where g.cv_ma = c.cv_ma and g.quyen_ma = q.quyen_ma ", luoidulieugv);



        }

        private void Tkcvugv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Macv = Tkcvugv.SelectedValue.ToString();
            ShowData("select GV_Ma, GV_HoTen, GV_TenDN, GV_GioiTinh, GV_DiaChi, GV_NgaySinh, GV_Gmail, GV_SDT, Quyen_Ten, CV_Ten  from GiaoVien g, ChucVu c, Quyen q where g.cv_ma = c.cv_ma and g.quyen_ma = q.quyen_ma and c.cv_ma = '"+ Macv +"' ", luoidulieugv);
        }
    }
}
