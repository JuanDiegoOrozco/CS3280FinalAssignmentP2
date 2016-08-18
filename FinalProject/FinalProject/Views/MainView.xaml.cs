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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalAssignment.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            OrdersView x = new OrdersView();
            theContent.Children.Add(x);

        }

        

        private void OrdersView_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void OrdersB_Click_1(object sender, RoutedEventArgs e)
        {
            OrdersView x = new OrdersView();
            theContent.Children.RemoveAt(0);
            theContent.Children.Add(x);
        }
        private void InventoryB_Click(object sender, RoutedEventArgs e)
        {
            InventoryView x = new InventoryView();
            theContent.Children.RemoveAt(0);
            theContent.Children.Add(x);
        }

        private void NewOrdersB_Click(object sender, RoutedEventArgs e)
        {
            NewOrderView x = new NewOrderView();
            theContent.Children.RemoveAt(0);
            theContent.Children.Add(x);
        }
    }
}
