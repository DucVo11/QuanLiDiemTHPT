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
using System.Configuration;

namespace QuanlidiemTHPT
{
    public partial class fDoiMatKhau : Form
    {
        Connection connection;

        public string tenDN;

        public fDoiMatKhau()
        {
            connection = new Connection();
            InitializeComponent();
        }

        public fDoiMatKhau(string nhan)
            : this()
        {
            tenDN = nhan;
            txttendn.Text = tenDN;
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btncapnhat_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string tenDN = txttendn.Text;
            string makhau = txtmkhientai.Text;
            string mkMoi = txtmkmoi.Text;
            string mkNhapLai = txtnhaplaimk.Text;
            string sql = "select * from GiaoVien where GV_TenDN= N'" + tenDN + "' and GV_MatKhau = N'" + makhau + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count.ToString() == "1")
            {
                if (mkMoi.CompareTo(mkNhapLai) == 0)
                {
                    string query = "update GiaoVien set GV_MatKhau = N'" + mkMoi + "' where GV_TenDN = '" + tenDN + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp");
                }
            }
            else
            {
                MessageBox.Show("Sai");

            }
        }

        private void btnhuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
            

        }

        private void txtnhaplaimk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmkmoi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

