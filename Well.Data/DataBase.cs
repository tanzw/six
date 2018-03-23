using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Well.Data
{
    public class DataBase
    {
        public IDbConnection NewDB()
        {

            var sd = new SQLiteConnection(ConnectionString);
            return sd;
        }

        protected string ConnectionString
        {
            get
            {

                var path = string.Format("Data Source={0};", Directory.GetCurrentDirectory() + "\\data\\six.db3");
                return path;
            }
        }
    }
}
