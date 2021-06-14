using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using practical.Models;
using System.IO;

namespace practical.Adapters
{
    class SQLiteHelper
    {
        private readonly string dbName = "exam.db";

        private static SQLiteHelper sQLiteHelper;

        public static SQLiteHelper GetInstance()
        {
            if (sQLiteHelper == null)
            {
                sQLiteHelper = new SQLiteHelper();
            }
            return sQLiteHelper;
        }

        private SQLiteHelper()
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            sQLiteConnection = new SQLiteConnection(path); // tao db;
            CreateCartTable();
        }

        public SQLiteConnection sQLiteConnection { get; private set; }

        public void CreateCartTable() // tao bang cart
        {
            var sql_txt = @"CREATE TABLE IF NOT EXISTS User(id integer primary key, password varchar(200))";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }
    }
}
