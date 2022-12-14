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
    public partial class fDiem : Form
    {

        Connection connection;

        public fDiem()
        {
            connection = new Connection();
            InitializeComponent();
        }

        private void fDiem_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            hienThiCombobox("Select * from NamHoc", cbNamHoc, "NH_Ma", "NH_Ten");
            hienThiCombobox("Select * from Khoi", cbKhoi, "Khoi_Ma", "Khoi_Ten");
            hienThiCombobox("select * from Lop where Khoi_Ma = 'K01'", cbLop, "Lop_Ma", "Lop_Ten");
            hienThiCombobox("select * from MonHoc", cbMonHoc, "MH_Ma", "MH_Ten");
            hienThiCombobox("Select * from HocKi", cbHocKi, "HK_Ma", "HK_Ten");
            hienThiCombobox("select * from LoaiDiem", cbLoaiDiem, "LD_Ma", "LD_Ten");
            hienThiDanhSachHocSinh();
            hienThiDanhSachDiem();
        }

        public void hienThiDanhSachHocSinh() 
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string tenLop = cbLop.Text;

            string maNH = cbNamHoc.SelectedValue.ToString();

            string query = "select  HS_Ma as [Mã học sinh], HS_HoTen as [Tên học sinh] from HocSinh hs, Lop l where hs.Lop_Ma = l.Lop_Ma and NH_Ma = N'" + maNH + "' and Lop_Ten = N'" + tenLop + "'";
            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dtgvDS.DataSource = dt;

        }

        public void hienThiDanhSachDiem()
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string maHS = tbMaHS.Text;
            string tenHK = cbHocKi.Text;
            string tenMon = cbMonHoc.Text;
            string query = "select LD_Ten as [Loại điểm], CTD_Lan as [Lần], CTD_Diem as [Điểm] from ChiTietDiem ct, LoaiDiem ld, HocKi hk, MonHoc mh where ct.LD_Ma=ld.LD_Ma and ct.HK_Ma = hk.HK_Ma and ct.MH_Ma = mh.MH_Ma and HS_Ma = N'" + maHS + "' and MH_Ten = N'" + tenMon + "' and HK_Ten = N'" + tenHK + "'";
            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            dta.Fill(dt);
            dtgvDiem.DataSource = dt;

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

        void themDiem() // Nhập điểm
        {
            string maHS = tbMaHS.Text;
            string maHocKi = cbHocKi.SelectedValue.ToString();
            string maMonHoc = cbMonHoc.SelectedValue.ToString();
            string maLoaiDiem = cbLoaiDiem.SelectedValue.ToString();
            int lan = Convert.ToInt32(cbLan.Text);
            float diem = (float)numDiem.Value;

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "insert into ChiTietDiem values (N'" + maHS + "', N'" + maHocKi + "', N'" + maMonHoc + "', N'" + maLoaiDiem + "', " + lan + ", " + diem + ")";
            SqlCommand themDiem = new SqlCommand(query, conn);
            int result = themDiem.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Thêm thành công");
                hienThiDanhSachDiem();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        void xoaDiem() // Xóa điểm
        {
            string maHS = tbMaHS.Text;
            string maHocKi = cbHocKi.SelectedValue.ToString();
            string maMonHoc = cbMonHoc.SelectedValue.ToString();
            string maLoaiDiem = cbLoaiDiem.SelectedValue.ToString();
            int lan = Convert.ToInt32(cbLan.Text);

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "delete ChiTietDiem where  HS_Ma = N'" + maHS + "' and HK_Ma = N'" + maHocKi + "' and MH_Ma = N'" + maMonHoc + "' and LD_Ma = N'" + maLoaiDiem + "' and CTD_Lan = " + lan + "";
            SqlCommand themDiem = new SqlCommand(query, conn);
            int result = themDiem.ExecuteNonQuery();
            if (result > 0)
            {
                if (MessageBox.Show("Xác nhận xóa điểm", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa thành công");
                    hienThiDanhSachDiem();
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        void suaDiem() // Sửa điểm
        {
            string maHS = tbMaHS.Text;
            string maHocKi = cbHocKi.SelectedValue.ToString();
            string maMonHoc = cbMonHoc.SelectedValue.ToString();
            string maLoaiDiem = cbLoaiDiem.SelectedValue.ToString();
            int lan = Convert.ToInt32(cbLan.Text);
            float diem = (float)numDiem.Value;

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "update ChiTietDiem set CTD_Diem = " + diem + " where HS_Ma = N'" + maHS + "' and HK_Ma = N'" + maHocKi + "' and MH_Ma = N'" + maMonHoc + "' and LD_Ma = N'" + maLoaiDiem + "' and CTD_Lan = " + lan;
            SqlCommand themDiem = new SqlCommand(query, conn);
            int result = themDiem.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Sửa thành công");
                hienThiDanhSachDiem();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dtgvDS_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            this.tbMaHS.Text = dtgvDS.Rows[i].Cells[0].Value.ToString();
            this.tbTenHS.Text = dtgvDS.Rows[i].Cells[1].Value.ToString();
        }

        private void dtgvDiem_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            this.cbLoaiDiem.Text = dtgvDiem.Rows[i].Cells[0].Value.ToString();
            this.cbLan.Text = dtgvDiem.Rows[i].Cells[1].Value.ToString();
            this.numDiem.Value = Convert.ToInt32(dtgvDiem.Rows[i].Cells[2].Value.ToString());
        }

        private void tbMaHS_TextChanged(object sender, EventArgs e)
        {
            hienThiDanhSachDiem();
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiDanhSachHocSinh();
           
        }

        private void cbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKhoi = cbKhoi.SelectedValue.ToString();

            hienThiCombobox("select * from Lop where Khoi_Ma = '" + maKhoi + "'", cbLop, "Lop_Ma", "Lop_Ten");
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiDanhSachHocSinh();
            
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiDanhSachDiem();
        }

        private void cbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiDanhSachDiem();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themDiem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaDiem();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaDiem();
        }

       
    }
}
