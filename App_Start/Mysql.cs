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

        public string Userregister(string username,string account,string password)
        {
            connection.ConnectionString = conn;
            string data;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                string sql = @"insert into `users`(`username`,`account`,`password`) values(@user,@account,@pass)";

                MySqlCommand cmd = new MySqlCommand(sql,connection);
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("account", account);
                cmd.Parameters.AddWithValue("pass", password);
                cmd.ExecuteNonQuery();
                data = "創建會員成功，開始您的冒險旅程!";
            }
            else
            {                
                data = "Fucking Project!";
            }
            return data;
        }

        public string Userlogin(string username,string password)
        {
            connection.ConnectionString = conn;
            string ans = null;
            DataSet dataSet = new DataSet();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                string sql = @"select * from `users` where account=@user and password=@pass";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", password);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataSet, "User");
                DataTable table = dataSet.Tables["User"];

                if (table.Rows.Count == 0)
                {
                    ans = "登入失敗...";
                }
                else
                {

                    ans = "登入成功 " + table.Rows[0]["username"].ToString();
                }
            }

            return ans;
        }
    }
}