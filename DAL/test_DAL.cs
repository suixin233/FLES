using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class test_DAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int add(Model.test model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into test(");
            strSql.Append("Password,Name)");
            strSql.Append(" values (");
            strSql.Append("@Password,@Name)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Password", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,255),
                                          };
            parameters[0].Value = model.Password;
            parameters[1].Value = model.Name;

            object obj = Utility.MySqlHelper.ExecuteTxtScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int update(Model.test model)
        {
            string strSql = "UPDATE test SET Password=@Password,Name=@Name WHERE Id=@Id";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Password", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Name", MySqlDbType.VarChar,255)};

            parameters[0].Value = model.Password;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ID;

            object obj = Utility.MySqlHelper.ExecuteTxtScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from test ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", SqlDbType.Int)
            };
            parameters[0].Value = Id;

            int rows = Utility.MySqlHelper.ExecuteTxtNonQuery(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<test> GetAlltest()
        {
            string strSql = "select * from test ";
            DataSet ds = Utility.MySqlHelper.ExecuteTxtDataSet(strSql);
            List<test> list = new List<test>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(ConvertRowToEntity(dr));
            }
            return list;
        }

        private test ConvertRowToEntity(DataRow r)
        {
            return new test(Convert.ToInt32(r["Id"]), r["Password"].ToString(), r["Name"].ToString());
        }


    }
}
