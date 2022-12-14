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
    public partial class fPhanCongGiangDay : Form
    {
        Connection connection;

        public fPhanCongGiangDay()
        {
            InitializeComponent();
            connection = new Connection();
          
        }

        private void fPhanCongGiangDay_Load(object sender, EventArgs e)
        {

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            HienThiCombobox("Select * from Khoi", cbKhoi, "Khoi_ma", "Khoi_Ten");
            HienThiCombobox("Select * from Lop where khoi_ma ='K01'", cbLop, "Lop_Ma", "Lop_Ten");
            HienThiCombobox("Select * from MonHoc", cbMonHoc, "MH_Ma", "MH_Ten");
            HienThiCombobox("Select * from GiaoVien a, ChuyenMon b where a.GV_Ma = b.GV_Ma and MH_Ma = 'M01'", cbGiaoVien, "GV_Ma", "GV_HoTen");
            HienThiCombobox("Select * from HocKi", cbHocKi, "HK_Ma", "HK_Ten");
            HienThiCombobox("Select * from NamHoc ", cbNamHoc, "NH_Ma", "NH_Ten");

        }

        public void ShowData(string truyvanDB, DataGridView dg)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlDataAdapter dta = new SqlDataAdapter(truyvanDB, conn);
            DataSet ds = new DataSet();
            dta.Fill(ds, "PhanCongGiaoVien");
            dg.DataSource = ds;
            dg.DataMember = "PhanCongGiaoVien";

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
            string maMon = cbMonHoc.SelectedValue.ToString();
            string maHK = cbHocKi.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "insert into GiangDay values (N'"+maGV+"', N'"+maLop+"', N'"+maMon+"', N'"+maNH+"', N'"+maHK+"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Thêm thành công");
                ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, GiaoVien gv, MonHoc mh where gd.GV_Ma = gv.GV_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ma = N'" + maLop + "' and NH_Ma = N'" + maNH + "' and HK_Ma = N'" + maHK + "'", luoidulieupcgv);

            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        void suaPC() 
        {
            string maGV = cbGiaoVien.SelectedValue.ToString();
            string maMon = cbMonHoc.SelectedValue.ToString();
            string maHK = cbHocKi.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "update GiangDay set GV_Ma = N'" + maGV + "' where Lop_Ma = N'" + maLop + "' and MH_Ma = N'" + maMon + "' and NH_Ma = N'" + maNH + "' and HK_Ma = N'" + maHK + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật thành công");
                ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, GiaoVien gv, MonHoc mh where gd.GV_Ma = gv.GV_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ma = N'" + maLop + "' and NH_Ma = N'" + maNH + "' and HK_Ma = N'" + maHK + "'", luoidulieupcgv);

            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        void xoaPC() 
        {
            string maGV = cbGiaoVien.SelectedValue.ToString();
            string maMon = cbMonHoc.SelectedValue.ToString();
            string maHK = cbHocKi.SelectedValue.ToString();
            string maNH = cbNamHoc.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string query = "delete GiangDay where GV_Ma = '"+maGV+"' and Lop_Ma = '"+maLop+"' and MH_Ma = '"+maMon+"' and NH_Ma = '"+maNH+"' and HK_Ma = '"+maHK+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                if (MessageBox.Show("Xác nhận xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Xóa thành công");
                    ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, GiaoVien gv, MonHoc mh where gd.GV_Ma = gv.GV_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ma = N'" + maLop + "' and NH_Ma = N'" + maNH + "' and HK_Ma = N'" + maHK + "'", luoidulieupcgv);
                   
                }
              
            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pctkkhoigv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makhoi = cbKhoi.SelectedValue.ToString();
            HienThiCombobox("Select * from Lop where khoi_ma ='"+makhoi+"'", cbLop, "Lop_Ma", "Lop_Ten");
          
        }

        private void Tkmh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maMon = cbMonHoc.SelectedValue.ToString();
            HienThiCombobox("Select * from GiaoVien a, ChuyenMon b where a.GV_Ma = b.GV_Ma and MH_Ma = '" + maMon + "'", cbGiaoVien, "GV_Ma", "GV_HoTen");

        }

        private void Tknh_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            string tenMon = cbMonHoc.Text;
            string namHoc = cbNamHoc.Text;
            string tenLop = cbLop.Text;
            string hocKi = cbHocKi.Text;

            ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, lop l, GiaoVien gv, NamHoc nh, HocKi hk, MonHoc mh where gd.Lop_Ma = l.Lop_Ma and gd.GV_Ma = gv.GV_Ma and gd.NH_Ma = nh.NH_Ma and gd.HK_Ma = hk.HK_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ten = N'" + tenLop + "' and NH_Ten = N'" + namHoc + "' and HK_Ten = N'" + hocKi + "'", luoidulieupcgv);

        }

        private void Pctklopgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenMon = cbMonHoc.Text;
            string namHoc = cbNamHoc.Text;
            string tenLop = cbLop.Text;
            string hocKi = cbHocKi.Text;
            ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, lop l, GiaoVien gv, NamHoc nh, HocKi hk, MonHoc mh where gd.Lop_Ma = l.Lop_Ma and gd.GV_Ma = gv.GV_Ma and gd.NH_Ma = nh.NH_Ma and gd.HK_Ma = hk.HK_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ten = N'" + tenLop + "' and NH_Ten = N'" + namHoc + "' and HK_Ten = N'" + hocKi + "'", luoidulieupcgv);

        }

        private void Pctkhkgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenMon = cbMonHoc.Text;
            string namHoc = cbNamHoc.Text;
            string tenLop = cbLop.Text;
            string hocKi = cbHocKi.Text;
            ShowData("select MH_Ten as [Môn Hoc], GV_HoTen as [Giáo Viên] from GiangDay gd, lop l, GiaoVien gv, NamHoc nh, HocKi hk, MonHoc mh where gd.Lop_Ma = l.Lop_Ma and gd.GV_Ma = gv.GV_Ma and gd.NH_Ma = nh.NH_Ma and gd.HK_Ma = hk.HK_Ma and gd.MH_Ma = mh.MH_Ma and Lop_Ten = N'" + tenLop + "' and NH_Ten = N'" + namHoc + "' and HK_Ten = N'" + hocKi + "'", luoidulieupcgv);

        }

        private void luoidulieupcgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = e.RowIndex;
            this.cbMonHoc.Text = luoidulieupcgv.Rows[i].Cells[0].Value.ToString();
            this.cbGiaoVien.Text = luoidulieupcgv.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themPC();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaPC();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaPC();
        }
    }
}
