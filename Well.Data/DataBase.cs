using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Well.Data
{
    public class DataBase
    {
        public IDbConnection NewDB(int flag = 1)
        {
            if (flag == 1)
            {
                var sd = new SQLiteConnection(ConnectionString);
                return sd;
            }
            else
            {
                var sd = new SQLiteConnection(WebConnectionString);
                return sd;
            }
        }



        protected string ConnectionString
        {
            get
            {

                var path = string.Format("Data Source={0};", AppDomain.CurrentDomain.BaseDirectory + "data\\six.db3");
                return path;
            }
        }

        protected string WebConnectionString
        {
            get
            {

                var path = string.Format("Data Source={0};", AppDomain.CurrentDomain.BaseDirectory + "App_Data\\six.db3");
                return path;
            }
        }
    }
}
