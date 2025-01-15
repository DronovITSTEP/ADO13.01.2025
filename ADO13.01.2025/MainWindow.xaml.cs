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

namespace ADO13._01._2025
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpamModelContainer db;
        public MainWindow()
        {
            InitializeComponent();
            db = new SpamModelContainer();

            CountryBox.ItemsSource = db.PromoProductSet.ToList();
            CountryBox.DisplayMemberPath = "Country";
        }

        private void connection_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.Database.Exists())
                {
                    MessageBox.Show("Подключено");
                    connection_btn.Visibility = Visibility.Collapsed;
                    StackButton.Visibility = Visibility.Visible;
                }
                else
                    MessageBox.Show("Ошибка подключения");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка. {ex.Message}");
            }
        }

        private void ShowAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in db.CustomerSet.ToList())
            {
                string customer = item.FirstName + " " + item.LastName;
                listResult.Items.Add(customer);
            }

        }

        private void ShowEmailCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            /*var email = db.CustomerSet.Select(c => c.Email).ToList();
             listResult.ItemsSource = email; */
            listResult.ItemsSource = db.CustomerSet.ToList();
           listResult.DisplayMemberPath = "Email";
        }

        private void ShowPromoByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var promoList = db.PromoProductSet
                .Where(promo => promo.Country == CountryBox.Text)
                .ToList();
           
            foreach (var item in promoList)
            {
                listResult.Items.Add(item.Name + " " + item.Country);
            }           
        }
    }
}
