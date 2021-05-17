using System;
using System.Data;
using System.Data.SQLite;

namespace EvotorStockManager
{
    class DAL
    {
        public static DataTable GetTable(string tableName)
        {
            try
            {
                using (var connLite = new SQLiteConnection("Data Source = DB_EVOTOR; Version = 3;"))
                {
                    connLite.Open();
                    string query = "SELECT * FROM " + tableName;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connLite);
                    DataTable dt = new DataTable(tableName);
                    da.Fill(dt);
                    return dt;
                }
            }

            catch (SQLiteException ex)
            {
                return null;
            }

        }

        public static int UpdateTable(string tableName, ref DataTable dt)
        {
            try
            {
                using (var connLite = new SQLiteConnection("Data Source = DB_EVOTOR; Version = 3;"))
                {
                    connLite.Open();
                    string query = "SELECT * FROM " + tableName;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connLite);
                    SQLiteCommandBuilder cb = new SQLiteCommandBuilder(da);
                    return da.Update(dt);
                }
            }

            catch (SQLiteException ex)
            {
                return -1;
            }

        }

        public static DataTable SelectTable(string tableName, string select)
        {
            try
            {
                using (var connLite = new SQLiteConnection("Data Source = DB_EVOTOR; Version = 3;"))
                {
                    connLite.Open();
                    string query = select;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connLite);
                    DataTable dt = new DataTable(tableName);
                    da.Fill(dt);
                    return dt;
                }
            }

            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public static int ExecuteDML(string select)
        {
            try
            {
                using (var connLite = new SQLiteConnection("Data Source = DB_EVOTOR; Version = 3;"))
                {
                    connLite.Open();
                    SQLiteCommand cmd = new SQLiteCommand(select, connLite);
                    return cmd.ExecuteNonQuery();
                }
            }

            catch (SQLiteException ex)
            {
                return -1;
            }
        }

        public static string ExecuteScalar(string select)
        {
            try
            {
                using (var connLite = new SQLiteConnection("Data Source = DB_EVOTOR; Version = 3;"))
                {
                    connLite.Open();
                    SQLiteCommand cmd = new SQLiteCommand(select, connLite);
                    return cmd.ExecuteScalar().ToString();
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
