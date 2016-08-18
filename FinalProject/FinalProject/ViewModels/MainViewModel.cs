using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;
using FinalAssignment.Views;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace FinalAssignment.ViewModels
{
    class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        //Buttons for switching screens
        private ICommand _OrdersButton;
        private ICommand _InventoryButton;
        private ICommand _NewOrderButton;

        private ContentControl RESPECK;
        private ContentControl tester;
        private ObservableCollection<Order> icollection;
        private static string TitleName = "Inventory Application";
        public MainViewModel() {
            this.DisplayName = TitleName;
            
            //Dummy data
            Order dummy1 = new Order();
            dummy1.OrderNumber = 1;
            dummy1.DatePlaced = DateTime.Today;
            User dumdum = new User();
            dumdum.Name = "Mike Jones";
            dumdum.Phone = "218-330-8004";
            dumdum.UserId = 1234;
            dummy1.Purchaser = dumdum;
            dummy1.TotalCost = 1000000;

            Order dummy2 = new Order();
            dummy2.OrderNumber = 2;
            dummy2.DatePlaced = DateTime.Today;
            User dumdum2 = new User();
            dumdum2.Name = "50 Cent";
            dumdum2.Phone = "435-754-8289";
            dumdum2.UserId = 5678;
            dummy2.Purchaser = dumdum2;
            dummy2.TotalCost = .50m;

            icollection = new ObservableCollection<Order>();
            icollection.Add(dummy1);
            icollection.Add(dummy2);
        }

        /// <summary>
        /// This area was for functions the binded buttons would perfom
        /// </summary>
        /// 
        public void stuff()
        {
           // OrdersView x = new OrdersView();
            //RESPECK = new ContentControl();
            
            //RESPECK.Content = x;

            //OrdersViewContent = (ContentControl)((IoC.Get<OrdersViewModel>()).GetView());
        }
        public void stuff2()
        {
            //this.ActivateItem((IScreen)(IoC.Get<InventoryViewModel>()).GetView());
            //MessageBox.Show("InventoryButton Triggered");
        }
        public void stuff3()
        {
            //this.ActivateItem((IScreen)(IoC.Get<NewOrderViewModel>()).GetView());
            //MessageBox.Show("NewOrderButton Triggered");
        }
        //////////////////////////////////////////////////////////////////////////////Buttons
        public ICommand OrdersButton
        {
            get
            {
                
                //MessageBox.Show("OrdersButton Triggered");
                return new DelegateCommand<object>(stuff, true);
            }
            
        }
        public ICommand InventoryButton
        {
            get
            {

                return new DelegateCommand<object>(stuff2, true);
            }

        }
        public ICommand NewOrderButton
        {
            get
            {
                //MessageBox.Show("NewOrdersButton Triggered");
                return new DelegateCommand<object>(stuff3, true);
            }

        }
        //////////////////////////////////////////////////////////////////////////////Buttons
        public ObservableCollection<Order> AllOrders
        {
            get
            {
                return icollection;
            }
        }
        protected override void OnActivate() {
            base.OnActivate();
            Orders();
        }
        //http://stackoverflow.com/questions/9580325/does-caliburn-micro-play-nicely-with-user-controls
        
        public string TitleOfPage
        {
            get
            {
                return TitleName;
            }
            set
            {
                TitleName = value;
                NotifyOfPropertyChange(TitleName);
            }
        }

        public ContentControl theContent
        {
            get
            {
                return RESPECK;
            }
            set
            {
                RESPECK = value;
                NotifyOfPropertyChange(() => RESPECK);
            }
        }

        public void Orders() {
            var ordersVM = IoC.Get<OrdersViewModel>();
            //var ordersV = IoC.Get<OrdersView>();
            //IoC.Get<OrdersViewModel>();
            //OnActivate(ordersVM);
            ActivateItem(ordersVM);
            //OrdersViewContent = (ContentControl)((IoC.Get<OrdersViewModel>()).GetView());
        }
       
        private void OnActivate(OrdersViewModel ordersVM)
        {
            //throw new NotImplementedException();
        }

        //IEnumerable<Order> OrdersView{
        //    get { return icollection; }
        //}
        /////////////////////////////////////////////////////////////////
        private ObservableCollection<OrderItem> orderItems;
        public ObservableCollection<OrderItem> AllItems
        {
            get
            {
                return orderItems;
            }
        }
    }

    internal class DelegateCommand<T> : ICommand
    {
        private System.Action stuff;
        private bool v;

        public DelegateCommand(System.Action stuff, bool v)
        {
            this.stuff = stuff;
            this.v = v;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            stuff();
        }
    }
}
