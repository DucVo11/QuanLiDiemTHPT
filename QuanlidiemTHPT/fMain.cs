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
    public partial class fMain : Form
    {
        Connection connection;
        public string tenDN;
        public fMain()
        {
            connection = new Connection();
            InitializeComponent();
        }
        public fMain(string nhan)
           : this()
        {
            tenDN = nhan;
            lbTenDN.Text = tenDN;
        }

        public void phanQuyen()
        {
            SqlConnection conn = connection.getSqlConnection();
            conn.Open();

            string tenDN = lbTenDN.Text;
            string query = "select Quyen_Ma from GiaoVien where GV_TenDN = '" + tenDN + "'";
            SqlDataAdapter dt = new SqlDataAdapter(query, conn);
            DataSet dase = new DataSet();
            dt.Fill(dase);
            string a = (string)dase.Tables[0].Rows[0][0];
            string temp = "Q01";
            if (a.CompareTo(temp) != 0)
            {
                quảnLíToolStripMenuItem.Visible = false;
                phânCôngGiáoViênToolStripMenuItem.Visible = false;
                phânCôngChủNhiệmToolStripMenuItem.Visible = false;
                danhSáchGiáoViênToolStripMenuItem.Visible = false;
            }
           
           

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            phanQuyen();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                fDangNhap dangNhap = new fDangNhap();
                dangNhap.ShowDialog();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fDoiMatKhau fdoiMatKhau = new fDoiMatKhau(lbTenDN.Text);
            fdoiMatKhau.ShowDialog();
        }

        private void họcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHocSinh f = new fHocSinh();
            f.Show();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fGiaoVien f = new fGiaoVien();
            f.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTinTaiKhoan f1 = new fThongTinTaiKhoan(lbTenDN.Text);
            f1.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fDoiMatKhau fdoiMatKhau = new fDoiMatKhau(lbTenDN.Text);
            fdoiMatKhau.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                fDangNhap dangNhap = new fDangNhap();
                dangNhap.ShowDialog();
            }
        }

        private void khốiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fKhoi fKhoi = new fKhoi();
            fKhoi.ShowDialog();
        }

        private void MonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMonHoc fMonHoc = new fMonHoc();
            fMonHoc.ShowDialog();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLop fLop = new fLop();
            fLop.ShowDialog();
        }

        private void giảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPhanCongGiangDay fPc = new fPhanCongGiangDay();
            fPc.ShowDialog();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDiem fDiem = new fDiem();
            fDiem.ShowDialog();
        }

        private void chuyênMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChuyenMon fChuyenMon = new fChuyenMon();
            fChuyenMon.ShowDialog();
        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTimDiemHS fTD = new fTimDiemHS();
            fTD.ShowDialog();
        }

        private void khốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhoi fK = new fKhoi();
            fK.ShowDialog();
        }

        private void lớpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fLop fL = new fLop();
            fL.ShowDialog();
        }

        private void phânCôngGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPhanCongGiangDay fPC = new fPhanCongGiangDay();
            fPC.ShowDialog();
        }

        private void nhậpĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDiem fD = new fDiem();
            fD.ShowDialog();
        }

        private void danhSáchSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhSachHocSinh fDSHS = new fDanhSachHocSinh();
            fDSHS.ShowDialog();
        }

        private void phânCôngChủNhiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPhanCongChuNhiem fCN = new fPhanCongChuNhiem();
            fCN.ShowDialog();
        }

        private void danhSáchGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhSachGiaoVien fDSGV = new fDanhSachGiaoVien();
            fDSGV.ShowDialog();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fMonHoc fM = new fMonHoc();
            fM.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongTin fTT = new fThongTin();
            fTT.ShowDialog();
        }
    }
}
