using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlidiemTHPT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new fDangNhap());
       //Application.Run(new fMonHoc());
     //  Application.Run(new fMain());
    //   Application.Run(new fDiem());
       //Application.Run(new fThongTinHS());
       //Application.Run(new fLop());
       //Application.Run(new fHocSinh());
       //Application.Run(new fGiaoVien());
       //Application.Run(new fMain());
          //Application.Run(new fPhanCongChuNhiem());
         //Application.Run(new fThongKeKQ());
        }
    }
}
