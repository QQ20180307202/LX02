using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
namespace DAL
{
    class UserInfo
    {
        private static UserInfo _instance = new UserInfo();

        private UserInfo() { }
        private static UserInfo Instance
        {
            get
            {
                return _instance;
            }
        }
        string cns = AppConfigurtaionServices.Configuration.GetConnectionString("cns");
        public string UserCheck(string UserName)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select password from userinfo where username=@username;";
                return cn.ExecuteScalar<string>(sql, new { username = UserName });
            }
        }
        public Model.UserInfo GetModel(string UserName)
        {
            using (IDbConnection cn = new MySq1Connection(cns))
            {
                string sql = "select * from userinfo where username=@usernamne";
                return cn.QueryFirstOrDefault<Mode1.UserInfo>(sql, new { username = UserName });
            }
        }
        public IEnumer able<Model.UserInfo> GetAll (){
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select * from userinfo";
                return cn.Query<Model.UserInfo>(sq1);
            }
        }

        public int GetCount()
        {
            using (IDbConnection cn = nev MySq1Connect ion(cns))
                {
                string sq1 = "select count(1) from userinfo";
                return cn.Execut eScalar<int>(sq1);
            }
        }


        public IEnumerable<Model.UserInfoNo> GetPage(Model.Page page)
        {
            using (IDbCornection cn = new MlySq1Connect ion(cns))
            {
                string sql = "with a as (select row_number() over(order by username) as rum, userinfo.* from userinfo)";
                sql += "select * from a where num between(@pageIndex-1) *@pageSize + 1 and @pageIndex*@pageSize:";
                return cn.Query(Model.UserInfoNo > (sql, page);
            }
        }
    }


