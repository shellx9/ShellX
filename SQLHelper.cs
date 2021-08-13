using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;

namespace rdp
{
    public abstract class SqlLiteHelper
    {    
        public static string ConnSqlLiteDbPath = "data\\shell.db";   
        public static string Info()
        {
            //Console.WriteLine("SQL Info   ");
            string db= string.Format(@"{0}", ConnSqlLiteDbPath);
            if (!File.Exists(db))
            {
                //Console.WriteLine("SqlLite  null");//输出语句，自动换行
                if (NewDbFile(db))
                {
                    NewTable();  // 创建表
                    list_tab_add();  //写入数据
                }
            }
            return "";
        }
        static public void list_tab_add()  //写入数据
        {
            string sError = ""; // string.Empty;
            string sSql = "INSERT INTO \"list\" VALUES(1, '名称', 200, 1);";
            UpdateData(out sError, sSql, true);
            sSql = "INSERT INTO \"list\" VALUES(2, '服务器IP', 170, 2);";
            UpdateData(out sError, sSql, true);
            sSql = "INSERT INTO \"list\" VALUES(3, '用户名', 100, 3);";
            UpdateData(out sError, sSql, true);
            sSql = "INSERT INTO \"list\" VALUES(4, '备注', 150, 4);";
            UpdateData(out sError, sSql, true);
            sSql = "INSERT INTO \"list\" VALUES(5, 'ping', 60, 5);";
            UpdateData(out sError, sSql, true);
        }
        static public void NewTable()  // 创建表
        {
            string shell_tab= "CREATE TABLE \"shell\" (" +
"  \"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
"  \"ip\" TEXT NOT NULL," +
"  \"post\" integer," +
"  \"user\" TEXT NOT NULL," +
"  \"password\" TEXT," +
"  \"name\" TEXT," +
"  \"bz\" TEXT," +
"  \"top\" integer DEFAULT 99," +
"  \"os\" integer DEFAULT 0," +
"  \"fz\" integer DEFAULT 0," +
"  \"Color\" integer DEFAULT 0" +
");";
            string fz_tab= "CREATE TABLE \"fz\" (" +
"  \"id\" integer NOT NULL PRIMARY KEY AUTOINCREMENT," +
"  \"name\" TEXT NOT NULL," +
"  \"top\" integer DEFAULT 99" +
");";
            string list_tab= "CREATE TABLE \"list\" (" +
"  \"id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
"  \"name\" TEXT NOT NULL," +
"  \"px\" integer NOT NULL," +
"  \"i\" integer" +
");";

            SQLiteConnection sqliteConn = new SQLiteConnection(ConnString);
            if (sqliteConn.State != System.Data.ConnectionState.Open)
            {
                sqliteConn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = shell_tab;
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = fz_tab;
                cmd.ExecuteNonQuery();

                cmd = new SQLiteCommand();
                cmd.Connection = sqliteConn;
                cmd.CommandText = list_tab;
                cmd.ExecuteNonQuery();
            }
            sqliteConn.Close();
        }

        public static string ConnString
        {
            get
            {
                return string.Format(@"Data Source={0}", ConnSqlLiteDbPath);
            }
        }

     
        static public Boolean NewDbFile(string dbPath)  // 新建数据库文件
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("新建数据库文件" + dbPath + "失败：" + ex.Message);
            }
        }
        // 取datatable
        public static DataTable GetDataTable(out string sError, string sSQL)
        {
            DataTable dt = null;
            sError = string.Empty;
            try
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = sSQL;
                cmd.Connection = conn;
                SQLiteDataAdapter dao = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                dao.Fill(dt);
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            return dt;
        }
        // 取某个单一的元素
        public static object GetSingle(out string sError, string sSQL)
        {
            DataTable dt = GetDataTable(out sError, sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows;
            }
            return null;
        }
        // 取最大的ID
        public static Int32 GetMaxID(out string sError, string sKeyField, string sTableName)
        {
            DataTable dt = GetDataTable(out sError, "select ifnull(max([" + sKeyField + "]),0) as MaxID from[" + sTableName + "]");
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            return 0;
        }
        // 执行insert,update,delete 动作，也可以使用事务
        public static bool UpdateData(out string sError, string sSQL, bool bUseTransaction = false)
        {
            int iResult = 0;
            sError = string.Empty;
            if (!bUseTransaction)
            {
                try
                {
                    SQLiteConnection conn = new SQLiteConnection(ConnString);
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand(conn);
                    comm.CommandText = sSQL;
                    iResult = comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    sError = ex.Message;
                    iResult = -1;
                }
            }
            else // 使用事务
            {
                DbTransaction trans = null;
                try
                {
                    SQLiteConnection conn = new SQLiteConnection(ConnString);
                    conn.Open();
                    trans = conn.BeginTransaction();
                    SQLiteCommand comm = new SQLiteCommand(conn);
                    comm.CommandText = sSQL;
                    iResult = comm.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    sError = ex.Message;
                    iResult = -1;
                    trans.Rollback();
                }
            }
            return iResult > 0;
        }
    }
}
