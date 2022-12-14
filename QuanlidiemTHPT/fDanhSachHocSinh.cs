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
    public partial class fDanhSachHocSinh : Form
    {

        Connection connection;

        public fDanhSachHocSinh()
        {
            connection = new Connection();
            InitializeComponent();
            load();
        }

        public void load()
        {
            hienThiCombobox("Select * from NamHoc", cbNamHoc, "NH_Ma", "NH_Ten");
            hienThiCombobox("Select * from Khoi", cbKhoi, "Khoi_Ma", "Khoi_Ten");
            hienThiCombobox("select * from Lop where Khoi_Ma = 'K01'", cbLop, "Lop_Ma", "Lop_Ten");
        }


        public void hienThiDanhSach()
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string maLop = cbLop.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();

            string query = "select HS_Ma as [Mã HS], HS_HoTen as [Họ tên], HS_DiaChi as [Địa chỉ], HS_GioiTinh as [Giới tính], HS_Gmail as [Gmail], HS_NgaySinh as [Ngày sinh], HS_Sdt as [SĐT]  from HocSinh hs, Lop l where hs.Lop_Ma = l.Lop_Ma and l.Lop_Ma = '"+maLop+"' and NH_Ma = '"+maNH+"'";

            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            dta.Fill(ds, "DS");
            dtgvDanhSach.DataSource = ds;
            dtgvDanhSach.DataMember = "DS";
        }

        public void hienThiCombobox(string query, ComboBox comb, string ma, string ten)
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

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoi = cbKhoi.SelectedValue.ToString();

            hienThiCombobox("select * from Lop where Khoi_Ma = '" + makhoi + "'",cbLop , "Lop_Ma", "Lop_Ten");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            hienThiDanhSach();
        }

        private void fDanhSachHocSinh_Load(object sender, EventArgs e)
        {

        }
    }
}
