using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// ����MySQL�����ݲ����
/// </summary>
/// <remarks>
/// �ο���MS Petshop 4.0
/// </remarks>

namespace Utility
{
    public class MySqlHelper
    {
        #region ���ݿ������ַ���
        public static readonly string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["FLESConnString"].ToString();
        #endregion

        #region PrepareCommand
        /// <summary>
        /// CommandԤ����
        /// </summary>
        /// <param name="conn">MySqlConnection����</param>
        /// <param name="trans">MySqlTransaction���󣬿�Ϊnull</param>
        /// <param name="cmd">MySqlCommand����</param>
        /// <param name="cmdType">CommandType���洢���̻�������</param>
        /// <param name="cmdText">SQL����洢������</param>
        /// <param name="cmdParms">MySqlCommand�������飬��Ϊnull</param>
        private static void PrepareCommand(MySqlConnection conn, MySqlTransaction trans, MySqlCommand cmd, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// ִ������
        /// </summary>
        /// <param name="ConnString">���ݿ������ַ���</param>
        /// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        /// <param name="cmdText">SQL����洢������</param>
        /// <param name="cmdParms">MySqlCommand��������</param>
        /// <returns>����������ļ�¼����</returns>
        public static int ExecuteTxtNonQuery(string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                PrepareCommand(conn, null, cmd, CommandType.Text, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        ///// <summary>
        ///// ִ������
        ///// </summary>
        ///// <param name="conn">Connection����</param>
        ///// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        ///// <param name="cmdText">SQL����洢������</param>
        ///// <param name="cmdParms">MySqlCommand��������</param>
        ///// <returns>����������ļ�¼����</returns>
        //public static int ExecuteNonQuery(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        //{
        //    MySqlCommand cmd = new MySqlCommand();
        //    PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
        //    int val = cmd.ExecuteNonQuery();
        //    cmd.Parameters.Clear();
        //    return val;
        //}

        ///// <summary>
        ///// ִ������
        ///// </summary>
        ///// <param name="trans">MySqlTransaction����</param>
        ///// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        ///// <param name="cmdText">SQL����洢������</param>
        ///// <param name="cmdParms">MySqlCommand��������</param>
        ///// <returns>����������ļ�¼����</returns>
        //public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        //{
        //    MySqlCommand cmd = new MySqlCommand();
        //    PrepareCommand(trans.Connection, trans, cmd, cmdType, cmdText, cmdParms);
        //    int val = cmd.ExecuteNonQuery();
        //    cmd.Parameters.Clear();
        //    return val;
        //}
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// ִ��������ص�һ�е�һ�е�ֵ
        /// </summary>
        /// <param name="ConnString">���ݿ������ַ���</param>
        /// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        /// <param name="cmdText">SQL����洢������</param>
        /// <param name="cmdParms">MySqlCommand��������</param>
        /// <returns>����Object����</returns>
        public static object ExecuteTxtScalar(string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection connection = new MySqlConnection(ConnString))
            {
                PrepareCommand(connection, null, cmd, CommandType.Text, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        ///// <summary>
        ///// ִ��������ص�һ�е�һ�е�ֵ
        ///// </summary>
        ///// <param name="ConnString">���ݿ������ַ���</param>
        ///// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        ///// <param name="cmdText">SQL����洢������</param>
        ///// <param name="cmdParms">MySqlCommand��������</param>
        ///// <returns>����Object����</returns>
        //public static object ExecuteScalar(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
        //{
        //    MySqlCommand cmd = new MySqlCommand();
        //    PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
        //    object val = cmd.ExecuteScalar();
        //    cmd.Parameters.Clear();
        //    return val;
        //}
        #endregion

        #region ExecuteReader
        /// <summary>
        /// ִ�������洢���̣�����MySqlDataReader����
        /// ע��MySqlDataReader����ʹ��������Close���ͷ�MySqlConnection��Դ
        /// </summary>
        /// <param name="ConnString">���ݿ������ַ���</param>
        /// <param name="cmdType">�������ͣ��洢���̻�SQL��䣩</param>
        /// <param name="cmdText">SQL����洢������</param>
        /// <param name="cmdParms">MySqlCommand��������</param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteTxtReader(string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(ConnString);
            try
            {
                PrepareCommand(conn, null, cmd, CommandType.Text, cmdText, cmdParms);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return dr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// ִ�������洢���̣�����DataSet����
        /// </summary>
        /// <param name="ConnString">���ݿ������ַ���</param>
        /// <param name="cmdType">��������(�洢���̻�SQL���)</param>
        /// <param name="cmdText">SQL����洢������</param>
        /// <param name="cmdParms">MySqlCommand��������(��Ϊnullֵ)</param>
        /// <returns></returns>
        public static DataSet ExecuteTxtDataSet(string cmdText, params MySqlParameter[] cmdParms)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                PrepareCommand(conn, null, cmd, CommandType.Text, cmdText, cmdParms);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                cmd.Parameters.Clear();
                return ds;
            }
        }
        #endregion

    }
}
