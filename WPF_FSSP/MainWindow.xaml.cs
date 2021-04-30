using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;


namespace WPF_FSSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // using (umsContext db = new umsContext())
            //{
            //    // получаем объекты из бд и выводим                 
            //    var users = db.Users.ToList();
            //    foreach (User u in users)
            //    {
            //        MessageBox.Show($"{u.Id}.{u.Name} - {u.LastName}");
            //    }
            //}


            //using (umsContext db = new umsContext())
            //{                
            //    var selectedTeams = from t in db.Users where t.Name.StartsWith("a") select t;
            //    foreach (var s in selectedTeams) MessageBox.Show(s.Name);
            //}

            // Рабочий запрос LINQ и вывод в dataGrid
            //umsContext db = new umsContext();
            //var Query = from cust in db.Users select cust;
            //dataGrid1.ItemsSource = Query.ToList();

            using (umsContext db = new umsContext())
            {
                var Query = db.Visitors.FromSqlRaw("SELECT * FROM Visitors limit 10").ToList();
                //var Query = db.Database.ExecuteSqlRaw("SELECT * FROM visitors JOIN court_objects on court_objects.id = visitors.court_object_id");
                dataGrid1.ItemsSource = Query;


                //SELECT * FROM visitors JOIN court_objects on court_objects.id = visitors.court_object_id
            }

        }
    }
}
