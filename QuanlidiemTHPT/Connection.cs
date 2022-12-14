using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanlidiemTHPT
{
    class Connection
    {
            private static string stringConnection= (@"Data Source=DUCVO; Initial Catalog= QuanLiDiem;Integrated Security= true");
           //  private static string stringConnection = "Server = KHANN\\ADMIN; database = QuanLiDiem; integrated security = true"; //Khangg
         //      private static string stringConnection = "Server = DESKTOP-SDUMHO6\\MSSQLSERVER03; database = QuanLiDiem; integrated security = true"; //Tuyen 
        //     private static string stringConnection = "Server = DESKTOP-V3GQV9Q; database = QuanLiDiem; integrated security = true";  // Phat
        public SqlConnection getSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
        

    }

}
