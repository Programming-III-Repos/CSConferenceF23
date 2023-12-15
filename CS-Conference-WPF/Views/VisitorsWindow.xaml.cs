using CS_Conference_WPF.Models;
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
using System.Windows.Shapes;

namespace CS_Conference_WPF.Views
{
    /// <summary>
    /// Interaction logic for VisitorsWindow.xaml
    /// </summary>
    public partial class VisitorsWindow : Window
    {
        private List<Visitor> visitors = new List<Visitor>();
        public VisitorsWindow()
        {
            InitializeComponent();
            Seed();
            lbVisitors.ItemsSource = visitors;
        }

        private void Seed()
        {
            visitors.Add(new Visitor() { Name = "Alex", CheckInDate = DateTime.Now, IsSpeaker = true, VisitorStatus = Status.Teacher });
            visitors.Add(new Visitor() { Name = "Sally", CheckInDate = DateTime.Now.AddDays(3), IsSpeaker = false, VisitorStatus = Status.Professional });
            visitors.Add(new Visitor() { Name = "Ben", CheckInDate = DateTime.Now.AddDays(5), IsSpeaker = true, VisitorStatus = Status.Professional });
            visitors.Add(new Visitor() { Name = "Dan", CheckInDate = DateTime.Now.AddDays(-1), IsSpeaker = false, VisitorStatus = Status.Student });
            visitors.Add(new Visitor() { Name = "Palak", CheckInDate = DateTime.Now.AddDays(-4), IsSpeaker = false, VisitorStatus = Status.Student });
        }

        private void BtnClear_Clicked(object sender, RoutedEventArgs e)
        {
            //Approach 1: go over the UI element one by one
            //txtName.Clear();
            //Radio button, check box..

            //Approach 2
            foreach(object UIElement in grdMain.Children) 
            {
                if (UIElement is TextBox txbTemp)
                    txbTemp.Clear();
                else if (UIElement is RadioButton rdbTemp)
                    rdbTemp.IsChecked = false;
                else if (UIElement is CheckBox chkTemp)
                    chkTemp.IsChecked = false;
                else if (UIElement is DatePicker dpTemp)
                    dpTemp.SelectedDate = null;
                else if (UIElement is ComboBox cmbTemp)
                    cmbTemp.SelectedIndex = -1;
            }
        }

        private void BtnSubmit_Clicked(object sender, RoutedEventArgs e)
        {
            //1. Validation
            if(ValidateSubmittedInput()) 
            {
                //2. Object of Visitor //3. Add object to a list
                visitors.Add(GetVisitorObject());
                //4. Show the list of Visitors in the list box
                //lbVisitors.ItemsSource = visitors; //Expensive operation
                lbVisitors.Items.Refresh();
                
                BtnClear_Clicked(sender, e);
            }

        }

        private Visitor GetVisitorObject() 
        { 
            return new Visitor()
            {
                Name = txtName.Text,
                IsSpeaker = chkbSpeaker.IsChecked.Value,
                CheckInDate = dpCheckin.SelectedDate.Value,
                VisitorStatus = rdbPro.IsChecked.Value ? Status.Professional :
                                rdbStudent.IsChecked.Value ? Status.Student : Status.Teacher
            };
        }
        private bool ValidateSubmittedInput()
        {
            StringBuilder message = new StringBuilder();
            //Name
            if (string.IsNullOrEmpty(txtName.Text))
                message.AppendLine("Name is a required field ");
            //Status
            if(rdbPro.IsChecked == false && rdbStudent.IsChecked == false && rdbTeacher.IsChecked == false)
                message.AppendLine("Select a status ");
            //Speaker: no need for validation

            //Check in date
            if(!dpCheckin.SelectedDate.HasValue)
                message.AppendLine("Checkin date is a required field ");

            if (string.IsNullOrEmpty(message.ToString()))
                return true;

            //Messagebox 
            MessageBox.Show(message.ToString(),"Missing Data",MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        
    }
}
