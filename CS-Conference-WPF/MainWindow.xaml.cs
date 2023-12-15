using System;
using System.Collections.Generic;
using System.IO;
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
using CS_Conference_WPF.Models;
using CS_Conference_WPF.Repos;
using CS_Conference_WPF.Views;

namespace CS_Conference_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data member
        private List<Organizer> _organizers = new List<Organizer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Clicked(object sender, RoutedEventArgs e)
        {
            //string msg = "Hello " + txbName.Text;
            //MessageBox.Show(msg);
            //txbName.Clear();

            //Capture Name
            if (string.IsNullOrEmpty(txbName.Text))
            {
                MessageBox.Show("Please enter name", "Missing Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Capture Availability
            List<CheckBox> avlaibleList = stkAvailabilty.Children.OfType<CheckBox>().ToList();

            string availabiltyValues = "";
            foreach (CheckBox checkBox in avlaibleList)
            {
                if (checkBox.IsChecked == true)
                {
                    availabiltyValues += checkBox.Content.ToString()+".";
                }
            }

            if (string.IsNullOrEmpty(availabiltyValues))
            {
                MessageBox.Show("Please check availability", "Missing Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Capture Country - City - Optional
            string country = (cmbCountries.SelectedItem as ComboBoxItem)?.Content.ToString();
            string city = cmbCities.SelectedItem?.ToString();

            //Create a organizer object
            Organizer organizer = new Organizer()
            {
                Name = txbName.Text,
                Availabilty = availabiltyValues,
                Country = string.IsNullOrEmpty(country) ? "NA" : country,
                City = string.IsNullOrEmpty(city) ? "NA" : city
            };

            _organizers.Add(organizer);

            //Save my organizer
            SaveOrganizerData(organizer);

            MessageBox.Show("Organizer added successfully");

            //Clear form

        }

        private void SaveOrganizerData(Organizer organizer)
        {
            try
            {
                //NEVER USE MAGIC VALUES: "Organizers.csv"
                File.AppendAllText("Organizers.csv", organizer.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCountry = (cmbCountries.SelectedItem as ComboBoxItem).Content.ToString();
            //MessageBox.Show(selectedCountry);
            switch (selectedCountry)
            {
                case "Canada":
                    cmbCities.ItemsSource = Data.GetCanadianCities();
                    break;
                case "United States":
                    cmbCities.ItemsSource = Data.GetUSCities();
                    break;
                default:
                    cmbCities.ItemsSource = Data.GetOtherCities();
                    break;
            }

        }

        private void Btn_GotoVisitorWindowClicked(object sender, RoutedEventArgs e)
        {
            VisitorsWindow visitorsWindow = new VisitorsWindow();
            //visitorsWindow.ShowDialog();
            visitorsWindow.Show();

            this.Close();
        }
    }
}
