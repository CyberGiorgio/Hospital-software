using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colloquio
{
    public static class DbConnection
    {
        static SqlConnection conn;
        public static SqlConnection DbConnect()        //connection to database
        {
            try
            {
                string pathDb = @"C:\Users\white\source\repos\HospitalSoftware\Colloquio\dbColloquio.mdf";
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + pathDb + ";Integrated Security=True;Connect Timeout=30");
                conn.Open();
            }
            catch (Exception ex)        //error message if connection problem
            {
                MessageBox.Show(ex.Message);
            }
            return conn;
        }
    }
}
