using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using practical.Adapters;
using practical.Models;
using SQLitePCL;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace practical.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Q2 : Page
    {
        public Q2()
        {
            this.InitializeComponent();
             AddToDatabase(1, "iloveyou123");
            AddToDatabase(2, "iloveyou1234");
            AddToDatabase(3, "iloveyou12345");
        }
        public void AddToDatabase(int id, string password)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "insert into User (id,password) values(?,?)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, id);
            statement.Bind(2, password);
            var rs = statement.Step();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "select * from User where (id = ? and password = ?)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, userBox.Text);
            statement.Bind(2, passwordBox.Password.ToString());
            if (SQLiteResult.ROW == statement.Step())
            {
                successFail.Text = "Login successfully";
                successFail.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                successFail.Text = "Login failed!";
                successFail.Foreground = new SolidColorBrush(Colors.Red);
            }

        }
    }
}
