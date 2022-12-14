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
    public partial class fTimDiemHS : Form
    {
        Connection connection;

        public fTimDiemHS()
        {
            connection = new Connection();
            InitializeComponent();
        }

        private void fTimDiemHS_Load(object sender, EventArgs e)
        {
            hienThiCombobox("Select * from NamHoc", cbNH, "NH_Ma", "NH_Ten");
            hienThiCombobox("Select * from HocKi", cbHK, "HK_Ma", "HK_Ten");
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

        public void timHS()
        {
            string maHocSinh = tbMaSV.Text;
            string maNH = cbNH.SelectedValue.ToString();
            string maHK = cbHK.SelectedValue.ToString();
            string query = "select HS_Ma, HS_HoTen from HocSinh hs, Lop l where hs.Lop_Ma = l.Lop_Ma and hs.HS_Ma = '" + maHocSinh + "' and NH_Ma = '" + maNH + "'";
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataSet dts = new DataSet();
            dta.Fill(dts);

            string maHS = (string)dts.Tables[0].Rows[0][0];
            string tenHS = (string)dts.Tables[0].Rows[0][1];

            tbHienThiMa.Text = maHS;
            tbTen.Text = tenHS;

        }

        public void hienThiDiem()
        {
            string maHocSinh = tbMaSV.Text;
            string maNH = cbNH.SelectedValue.ToString();
            string maHK = cbHK.SelectedValue.ToString();
            string query = "select MH_Ten as [Môn học], ROUND(sum(CTD_Diem*LD_HeSo)/sum(LD_HeSo), 1, 1) as [TBM] from ChiTietDiem ct, LoaiDiem ld, MonHoc mh, HocSinh hs, lop l where ct.LD_Ma = ld.LD_Ma and ct.MH_Ma = mh.MH_Ma and ct.HS_Ma = hs.HS_Ma and hs.Lop_Ma = l.Lop_Ma and ct.HS_Ma = N'" + maHocSinh + "' and HK_Ma = '" + maHK + "' and NH_Ma = '" + maNH + "' group by MH_Ten";
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlDataAdapter dta = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            dta.Fill(dt);
            dtgvChiTiet.DataSource = dt;

        }

        public void hienThiDTB()
        {
            string maHocSinh = tbMaSV.Text;
            string maNamHoc = cbNH.SelectedValue.ToString();
            string maHocKi = cbHK.SelectedValue.ToString();

            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "tbm";

            SqlParameter maHS = new SqlParameter("@maHS", SqlDbType.NVarChar);
            SqlParameter maNH = new SqlParameter("@maNH", SqlDbType.NVarChar);
            SqlParameter maHK = new SqlParameter("@maHK", SqlDbType.NVarChar);

            maHS.Value = maHocSinh;
            maNH.Value = maNamHoc;
            maHK.Value = maHocKi;

            cmd.Parameters.Add(maHS);
            cmd.Parameters.Add(maNH);
            cmd.Parameters.Add(maHK);

            cmd.Connection = conn;

            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read())
            {
                double kq = dta.GetDouble(0);
                tbTBM.Text = Convert.ToString(kq);
                if (kq >= 8.0)
                {
                    tbXepLoai.Text = "Giỏi";
                }
                else
                if (kq >= 6.5 && kq < 8.0)
                {
                    tbXepLoai.Text = "Khá";
                }
                else
                if (kq >= 5.0 && kq < 6.5)
                {
                    tbXepLoai.Text = "Trung Bình";
                }
                else
                {
                    tbXepLoai.Text = "Yếu";
                }
            }
            dta.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timHS();
            hienThiDiem();
            hienThiDTB();
        }

    }
}
