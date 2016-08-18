using FinalAssignment.ViewModels;
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

namespace FinalAssignment.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel();
        }

        private void OrdersB_Click(object sender, RoutedEventArgs e)
        {
            //var viewWindow = new OrdersView();
            //viewWindow.Show();
        }

        private void InventoryB_Click(object sender, RoutedEventArgs e)
        {
            //var viewWindow = new InventoryView();
            //viewWindow.Show();
        }

        private void NewOrdersB_Click(object sender, RoutedEventArgs e)
        {
            //var viewWindow = new NewOrderView();
            //viewWindow.Show();
        }
    }
}
