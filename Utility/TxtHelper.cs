using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace Utility
{
    public class TxtHelper
    {
        public enum DocSeperator
        {
            Comma,
            Space,
            Semicolon,
            Tab,
        }

        /// <summary>
        /// 将Txt文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">Txt文件路径</param>
        /// <param name="hasHeader">是否有标题行</param>
        /// <returns>返回读取了Txt数据的DataTable</returns>
        public static DataTable TxtToDataTable(string filePath, DocSeperator seperator, bool hasHeader)
        {
            //Encoding encoding = Common.GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            FileStream fs_maxcol = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            //StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            //StreamReader sr = new StreamReader(fs, encoding);
            StreamReader sr_maxcol = new StreamReader(fs_maxcol);
            //string fileContent = sr.ReadToEnd();
            //encoding = sr.CurrentEncoding;
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //逐行读取CSV中的数据
            //设定分隔符
            char sep;
            switch (seperator)
            {
                case DocSeperator.Comma:
                    sep = ',';
                    break;
                case DocSeperator.Space:
                    sep = ' ';
                    break;
                case DocSeperator.Semicolon:
                    sep = ';';
                    break;
                case DocSeperator.Tab:
                    sep = '\t';
                    break;
                default:
                    sep = ',';
                    break;
            }

            //找出列数最多行
            int max_columnCount = 0;
            while ((strLine = sr_maxcol.ReadLine()) != null)
            {
                aryLine = strLine.Split(sep);
                columnCount = aryLine.Length;
                if(columnCount>max_columnCount)
                    max_columnCount = columnCount;
            }
            //先建表
            for (int i = 0; i < max_columnCount; i++)
            {
                DataColumn dc = new DataColumn();
                dt.Columns.Add(dc);
            }

            //判断有无表头
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            strLine = sr.ReadLine();
            if (hasHeader)
            {
                tableHead = strLine.Split(sep);
                columnCount = tableHead.Length;
                //创建列
                for (int i = 0; i < columnCount; i++)
                {
                    DataColumn dc = new DataColumn(tableHead[i]);
                    dt.Columns.Add(dc);
                }
            }
            else//无表头，写第一行
            {
                //先建表
                aryLine = strLine.Split(sep);
                columnCount = aryLine.Length;
                //for (int i = 0; i < columnCount; i++)
                //{
                //    DataColumn dc = new DataColumn();
                //    dt.Columns.Add(dc);
                //}

                //再填充内容
                DataRow dr = dt.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    dr[j] = aryLine[j];
                }
                dt.Rows.Add(dr);
            }
            //接下来读第二行及以后内容
            while ((strLine = sr.ReadLine()) != null)
            {
                //strLine = Common.ConvertStringUTF8(strLine, encoding);
                //strLine = Common.ConvertStringUTF8(strLine);

                aryLine = strLine.Split(sep);
                columnCount = aryLine.Length;
                DataRow dr = dt.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    dr[j] = aryLine[j];
                }
                dt.Rows.Add(dr);
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                if (tableHead != null && tableHead.Length > 0)
                {
                    dt.DefaultView.Sort = tableHead[0] + " asc";
                }
                else
                {
                    dt.DefaultView.Sort = "Column1 asc";
                }
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        /// <summary>
        /// 将DataTable中数据写入到CSV文件中
        /// </summary>
        /// <param name="dt">提供保存数据的DataTable</param>
        /// <param name="fileName">CSV的文件路径</param>
        public static void SaveCSV(DataTable dt, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }
    }
}