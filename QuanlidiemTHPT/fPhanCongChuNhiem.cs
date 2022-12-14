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
    public partial class fPhanCongChuNhiem : Form
    {
        Connection connection;
        public fPhanCongChuNhiem()
        {
            connection = new Connection();
            InitializeComponent();
        }

        private void fPhanCongChuNhiem_Load(object sender, EventArgs e)
        {
            hienThiDanhSach();
            HienThiCombobox("Select * from Khoi", cbKhoi, "Khoi_ma", "Khoi_Ten");
            HienThiCombobox("Select * from Lop where khoi_ma ='k01'", cbLop, "Lop_Ma", "Lop_Ten");
            HienThiCombobox("Select * from GiaoVien where CV_Ma = 'CV02'", cbGiaoVien, "GV_Ma", "GV_HoTen");
            HienThiCombobox("Select * from NamHoc ", cbNamHoc, "NH_Ma", "NH_Ten");
        }

        public void hienThiDanhSach()
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string tenKhoi = cbKhoi.Text;
            string tenNH = cbNamHoc.Text;

            string query = "select Lop_Ten, GV_HoTen from ChuNhiem cn, Lop l, Khoi k, GiaoVien gv, NamHoc nh where cn.Lop_Ma = l.Lop_Ma and cn.GV_Ma = gv.GV_Ma and l.Khoi_Ma = k.Khoi_Ma and l.NH_Ma = nh.NH_Ma and Khoi_Ten = N'"+tenKhoi+"' and NH_Ten = N'"+tenNH+"'";

            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            dta.Fill(ds, "DS");
            dtgvDanhSach.DataSource = ds;
            dtgvDanhSach.DataMember = "DS";

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

        void themPC()
        {
            string maGV = cbGiaoVien.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "insert into ChuNhiem values (N'" + maGV + "', N'" + maLop + "', N'" + maNH +"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Thêm thành công");
                hienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        void suaPC()
        {
            string maGV = cbGiaoVien.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "update ChuNhiem set GV_Ma = N'" + maGV + "' where Lop_Ma =  N'" + maLop + "' and NH_Ma = N'" + maNH + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Cật nhập thành công");
                hienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        void xoaPC()
        {
            string maGV = cbGiaoVien.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "delete ChuNhiem where GV_Ma = N'" + maGV + "' and Lop_Ma = N'" + maLop + "' and NH_Ma = N'" + maNH + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Xóa thành công");
                hienThiDanhSach();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoi = cbKhoi.SelectedValue.ToString();
            string tenNH = cbNamHoc.Text;
            HienThiCombobox("Select * from Lop l, NamHoc nh where l.NH_Ma = nh.NH_Ma and khoi_ma ='" + makhoi + "' and NH_Ten = '"+tenNH+"'", cbLop, "Lop_Ma", "Lop_Ten");
            hienThiDanhSach();

        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoi = cbKhoi.SelectedValue.ToString();
            string tenNH = cbNamHoc.Text;
            HienThiCombobox("Select * from Lop l, NamHoc nh where l.NH_Ma = nh.NH_Ma and khoi_ma ='" + makhoi + "' and NH_Ten = '" + tenNH + "'", cbLop, "Lop_Ma", "Lop_Ten");
            hienThiDanhSach();
        }

        private void dtgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            this.cbLop.Text = dtgvDanhSach.Rows[i].Cells[0].Value.ToString();
            this.cbGiaoVien.Text = dtgvDanhSach.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themPC();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaPC();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaPC();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
