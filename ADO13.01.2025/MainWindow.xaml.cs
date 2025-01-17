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

            CountryBox.ItemsSource = db.PromoProductSet.Select(c => c.Country)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            CityBox.ItemsSource = db.CustomerSet.Select(c => c.City)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            StartDateBox.ItemsSource = db.PromoProductSet.Select(c => c.StartDate)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            EndDateBox.ItemsSource = db.PromoProductSet.Select(c => c.EndDate)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            SectionBox.ItemsSource = db.PromoProductSet.Select(c => c.Sections.Name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
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
            AddListItem(db.CustomerSet.ToList());
        }

        private void ShowEmailCustomerButton_Click(object sender, RoutedEventArgs e)
        {        
            var email = db.CustomerSet.Select(c => c.Email).ToList();
            AddListItem(email);

        }

        private void ShowPromoByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var promoList = db.PromoProductSet
                .Where(promo => promo.Country == CountryBox.Text)
                .ToList();

            AddListItem(promoList);
         
        }

        private void ShowCustomerByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var customerList = db.CustomerSet
                .Where(cust => cust.Country == CountryBox.Text)
                .ToList();

            AddListItem(customerList);
        }

        private void ShowCustomerByCityButton_Click(object sender, RoutedEventArgs e)
        {
            var customerList = db.CustomerSet
                .Where(promo => promo.City == CityBox.Text)
                .ToList();

            AddListItem(customerList);
        }

        private void ShowCountCustomerByCityButton_Click(object sender, RoutedEventArgs e)
        {        
            var customerList = db.CustomerSet
                .GroupBy(c => c.City)
                .Select(t => new
                {
                    City = t.Key,
                    Count = t.Count()
                }).ToList();

            AddListItem(customerList);
        }

        private void ShowCountCustomerByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var customerList = db.CustomerSet
                .GroupBy(c => c.Country)
                .Select(t => new
                {
                    Country = t.Key,
                    Count = t.Count()
                }).ToList();

            AddListItem(customerList);
        }

        private void ShowCountCityByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var customerList = db.CustomerSet
                .GroupBy(c => c.Country)
                .Select(t => new
                {
                    City = t.Key,
                    Count = t.Count()
                }).ToList();

            AddListItem(customerList);
        }

        private void ShowAvgCityByCountryButton_Click(object sender, RoutedEventArgs e)
        {
            listResult.Items.Clear();
            var customerList = db.CustomerSet
                .GroupBy(c => c.Country)
                .Select(t => new
                {
                    Country = t.Key,
                    Avg = t.Count()
                }).Average(a => a.Avg);

            listResult
                .Items
                .Add("Среднее кол-во городов = " + customerList);       
        }

        private void ShowPromoByRangeDateButton_Click(object sender, RoutedEventArgs e)
        {
           
            DateTime startDate = DateTime.Parse(StartDateBox.Text);
            DateTime endDate = DateTime.Parse(EndDateBox.Text);
            string section = SectionBox.Text;

            var promoList = db.PromoProductSet
                                .Where(x => x.StartDate >= startDate 
                                    && x.EndDate <= endDate 
                                    && x.Sections.Name == section)
                                .ToList();
            AddListItem(promoList);
        }

        private void ShowTopCountryByCustomerButton_Click(object sender, RoutedEventArgs e)
        {        
            var top3CountryByCustomer = db.CustomerSet
               .GroupBy(c => c.Country)
               .Select(t => new
               {
                   Country = t.Key,
                   Count = t.Count()
               })
               .OrderByDescending(c => c.Count)
               .Take(2)
               .ToList();

            AddListItem(top3CountryByCustomer);
        }

        private void AddListItem<T>(List<T> items)
        {
            listResult.Items.Clear();

            foreach (var item in items)
            {
                listResult.Items.Add(item);
            }
        }
    }
}
