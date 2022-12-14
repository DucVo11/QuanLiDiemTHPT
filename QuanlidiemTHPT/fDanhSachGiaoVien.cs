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
    public partial class fDanhSachGiaoVien : Form
    {
        Connection connection;
        public fDanhSachGiaoVien()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void fDanhSachGiaoVien_Load(object sender, EventArgs e)
        {
       
        }


        public void hienThiDanhSach(string query)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            SqlDataAdapter dta = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            dta.Fill(ds, "DS");
            dtgvDanhSach.DataSource = ds;
            dtgvDanhSach.DataMember = "DS";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int tenCV = cbChucVu.SelectedIndex;
            if(tenCV == 0)
            {
                hienThiDanhSach("select * from GiaoVien");
            }
            else if(tenCV == 1)
            {
                hienThiDanhSach("select * from GiaoVien where CV_Ma <> 'CV02'");
            }
            else
            {
                hienThiDanhSach("select * from GiaoVien where CV_Ma = 'CV02'");
            }
        }


    }
}
