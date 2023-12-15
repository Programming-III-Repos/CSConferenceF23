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
        public VisitorsWindow()
        {
            InitializeComponent();
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
    }
}
