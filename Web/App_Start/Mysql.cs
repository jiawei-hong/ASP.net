using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MysqlController
{
    public class SqlController : Controller
    {
        string conn = "server=localhost;port=3306;user id=root;password='';database=member;charset=utf8;";

        MySqlConnection connection = new MySqlConnection();

        public string addUser(string username,string password)
        {
            connection.ConnectionString = conn;
            string data;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                string sql = @"insert into `users`(`username`,`password`) values(@user,@pass)";

                MySqlCommand cmd = new MySqlCommand(sql,connection);
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);
                cmd.ExecuteNonQuery();
                data = "創建會員成功...";
            }
            else
            {
                data = "Fucking Project!";
            }
            return data;
        }
    }
}