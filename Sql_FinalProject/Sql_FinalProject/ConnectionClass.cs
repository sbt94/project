using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_FinalProject
{
    public static class ConnectionClass
    {
        public static string Generelconnection = @"Data Source=DESKTOP-TQ2RPAH;Initial Catalog=FinalSQL;Integrated Security=True";
        public static string Customerconnection = @"Data Source=DESKTOP-TQ2RPAH;Initial Catalog=FinalSQL;User ID=Customer;Password=54321";
        public static string Managerconnection = @"Data Source=DESKTOP-TQ2RPAH;Initial Catalog=FinalSQL;User ID=Manager;Password=12345";
        public static string Employeeconnection = @"Data Source=DESKTOP-TQ2RPAH;Initial Catalog=FinalSQL;User ID=Employee;Password=6789";

    }
}
