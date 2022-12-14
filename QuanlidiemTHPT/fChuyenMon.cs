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
    public partial class fChuyenMon : Form
    {
        Connection connection;
        public fChuyenMon()
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
            dta.Fill(ds, "ChuyenMonGiaoVien");
            dg.DataSource = ds;
            dg.DataMember = "ChuyenMonGiaoVien";

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

        private void fChuyenMon_Load(object sender, EventArgs e)
        {

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            HienThiCombobox("Select * from MonHoc", cmmh, "MH_Ma", "MH_Ten");
            HienThiCombobox("Select GV_Ma, GV_HoTen from GiaoVien where CV_Ma = 'CV02'", cmgv, "GV_Ma", "GV_HoTen");

            string mamon = cmmh.SelectedValue.ToString();
            ShowData("select  a.GV_Ma as [Mã GV], GV_HoTen as [Họ và tên] from GiaoVien a , ChuyenMon b where a.GV_Ma= b.GV_Ma and MH_Ma = '" + mamon + "' ", luoidulieucm);

        }

        private void cmmh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mamon = cmmh.SelectedValue.ToString();
            ShowData("select GV_HoTen from GiaoVien a , ChuyenMon b where a.GV_Ma= b.GV_Ma and MH_Ma = '"+mamon+"' ",luoidulieucm);
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String Magv = cmgv.SelectedValue.ToString();
            String Mamon = cmmh.SelectedValue.ToString();

            string luu_sql = "insert into ChuyenMon values ( N'" + Magv + "', N'" + Mamon + "')";
            SqlCommand luu = new SqlCommand(luu_sql, conn);
            luu.ExecuteNonQuery();
            MessageBox.Show("Lưu thành công");
            ShowData("select GV_HoTen from GiaoVien a , ChuyenMon b where a.GV_Ma= b.GV_Ma and MH_Ma = '" + Mamon + "' ", luoidulieucm);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            String Magv = cmgv.SelectedValue.ToString();
            String Mamon = cmmh.SelectedValue.ToString();

            string xoa_sql = "delete from ChuyenMon where GV_Ma = '"+Magv+"' and MH_Ma = '"+Mamon+"'";
            SqlCommand xoa = new SqlCommand(xoa_sql, conn);
            xoa.ExecuteNonQuery();
            MessageBox.Show("Xóa thành công");
            ShowData("select GV_HoTen from GiaoVien a , ChuyenMon b where a.GV_Ma= b.GV_Ma and MH_Ma = '" + Mamon + "' ", luoidulieucm);

        }

        private void luoidulieucm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmgv.Text = luoidulieucm.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
