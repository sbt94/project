using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_FinalProject
{
    public static class ConnectionClass
    {
        public static string Generelconnection = @"Data Source=DESKTOP-L673D5F\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
        public static string Customerconnection = @"Data Source=DESKTOP-L673D5F\SQLEXPRESS;Initial Catalog=project;User ID=Customer;Password=54321";

    }
    public static class CurrentUser
    {
        public static string username { get; set; }
        public static string password { get; set; }
        public static string usertype { get; set; }
    }
}
