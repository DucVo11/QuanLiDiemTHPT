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
    public partial class fThongTinTaiKhoan : Form
    {
        Connection connection;
        public string tenDN;
        public fThongTinTaiKhoan()
        {
            InitializeComponent();
            connection = new Connection();

        }

        public fThongTinTaiKhoan(String nhan)
            : this()
        {
            tenDN = nhan;
            textBoxtendangnhap.Text = tenDN;
        }

        private void fThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            thongTin();
       //     hienthichucvu("Select * from ChucVu", comboBoxchucvu, "CV_Ten", "CV_Ma");

        }


        public void thongTin()
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string tenDN = textBoxtendangnhap.Text;
            string newQuery = "select GV_HoTen, GV_DiaChi,GV_GioiTinh,GV_NgaySinh,GV_Gmail, GV_SDT,  " +
                "CV_Ten from GiaoVien gv join ChucVu cv on gv.CV_Ma = cv.CV_Ma where GV_TenDN = '" + tenDN + "'";
            SqlDataAdapter dt = new SqlDataAdapter(newQuery, conn);
            DataSet dase = new DataSet();
            dt.Fill(dase);
            string ten = (string)dase.Tables[0].Rows[0][0];
            string dchi = (string)dase.Tables[0].Rows[0][1];
            string gtinh = (string)dase.Tables[0].Rows[0][2];
            string nsinh = (string)dase.Tables[0].Rows[0][3];
            string gmail = (string)dase.Tables[0].Rows[0][4];
            string sdt = (string)dase.Tables[0].Rows[0][5];
            string chucVu = (string)dase.Tables[0].Rows[0][6];

            textBoxtenhienthi.Text = ten;
            textBoxdiachi.Text = dchi;
            comboBoxgioitinh.Text = gtinh;
            textBoxngaysinh.Text = nsinh;
            textBoxgmail.Text = gmail;
            textBoxsdt.Text = sdt;
            txtCV.Text = chucVu;
        }

        public void hienthichucvu(string sql, ComboBox cb, string ShowV, string HideVal)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();

            dataTable.Load(sqlDataReader);
            cb.DataSource = dataTable;
            cb.DisplayMember = ShowV;
            cb.ValueMember = HideVal;

        }

        private void btncapnhap_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();
            string tenDangNhap = textBoxtendangnhap.Text;
            string hoten = textBoxtenhienthi.Text;
            string dchi = textBoxdiachi.Text;
            string gtinh = comboBoxgioitinh.Text;
            string nsinh = textBoxngaysinh.Text;
            string gmail = textBoxgmail.Text;
            string sdt = textBoxsdt.Text;
           // string chucvu = comboBoxchucvu.SelectedValue.ToString();

            string Sql = "update GiaoVien set GV_HoTen = N'" + hoten + "',GV_DiaChi = N'" + dchi + "',GV_GioiTinh = N'" + gtinh + "'," +
                "GV_NgaySinh = N'" + nsinh + "',GV_Gmail = N'" + gmail + "',GV_SDT = N'" + sdt + "' where GV_TenDN = N'" + tenDangNhap + "'";

            SqlCommand cmd = new SqlCommand(Sql, conn);
            int rs = cmd.ExecuteNonQuery();
            if (rs > 0)
            {
                MessageBox.Show("Cập nhật thành công!!");

                thongTin();
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
