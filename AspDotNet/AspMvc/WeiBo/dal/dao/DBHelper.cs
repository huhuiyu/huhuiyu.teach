using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Reflection;

namespace WeiBo.dal.dao
{
    public class DBHelper
    {

        private static void ProgressArgs(SqlCommand comm, object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                comm.Parameters.AddWithValue("@p" + i, args[i]);
            }
        }

        public static Dictionary<string, string> GetReaderRowNames(SqlDataReader reader)
        {
            Dictionary<string, string> rows = new Dictionary<string, string>();
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                rows.Add(reader.GetName(i).ToLower(), reader.GetName(i));
            }
            return rows;
        }

        public static Dictionary<string, PropertyInfo> GetObjectPropertyInfos(object o)
        {
            Dictionary<string, PropertyInfo> infos = new Dictionary<string, PropertyInfo>();
            Type t = o.GetType();
            PropertyInfo[] pis = t.GetProperties();
            foreach (PropertyInfo info in pis)
            {
                infos.Add(info.Name.ToLower(), info);
            }
            return infos;
        }

        public static void SetSqlData(SqlDataReader reader, Object o, Dictionary<string, string> rows, Dictionary<string, PropertyInfo> pis)
        {
            foreach (string row in rows.Keys)
            {
                if (pis.ContainsKey(row))
                {
                    PropertyInfo pi = pis[row];
                    string name = rows[row];
                    pi.SetValue(o, reader[name]);
                }
            }
        }

        public static T QueryOneRow<T>(T t, string sql, params object[] args)
        {
            Type type = t.GetType();
            T data = default(T);
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProgressArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                Dictionary<string, string> rows = GetReaderRowNames(reader);
                Dictionary<string, PropertyInfo> pis = GetObjectPropertyInfos(t);

                if (reader.Read())
                {
                    data = (T)Activator.CreateInstance(type);
                    SetSqlData(reader, data, rows, pis);
                }
                reader.Close();
                conn.Close();
            }
            return data;
        }

        public static List<T> QueryRows<T>(T t, string sql, params object[] args)
        {
            Type type = t.GetType();
            List<T> list = new List<T>();
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(
                    sql, conn);
                ProgressArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                Dictionary<string, string> rows = GetReaderRowNames(reader);
                Dictionary<string, PropertyInfo> pis = GetObjectPropertyInfos(t);

                while (reader.Read())
                {
                    T data = (T)Activator.CreateInstance(type);
                    SetSqlData(reader, data, rows, pis);
                    list.Add(data);
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }

        public static object QueryOne(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProgressArgs(comm, args);
                object r = comm.ExecuteScalar();
                conn.Close();
                return r;
            }
        }

        public static int Update(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProgressArgs(comm, args);
                int r = comm.ExecuteNonQuery();
                conn.Close();
                return r;
            }
        }

        public static List<Dictionary<string, object>> QueryDicRows(string sql, params object[] args)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(
                    sql, conn);
                ProgressArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                Dictionary<string, string> rows = GetReaderRowNames(reader);

                while (reader.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    foreach (string key in rows.Keys)
                    {
                        dic.Add(key, reader[rows[key]]);
                    }
                    list.Add(dic);
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }

    }
}