using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;
using FinalAssignment.Views;
using System.Windows.Input;
using System.Windows;

namespace FinalAssignment.ViewModels
{
    class NewOrderViewModel : Screen
    {
        /// <summary>
        /// Textbox variables
        /// </summary>
        private string _UOrderNumber;
        private string _UPurchaseDate;
        private string _UPurchaser;
        private string _UOrderTotal;
        /// <summary>
        /// //////////////////////////////
        /// </summary>
        

        private ObservableCollection<Order> icollection;
        private IEnumerable<Item> Items;
        private static string Title = "Create New Order";
        public NewOrderViewModel()
        {
            this.DisplayName = Title;

            //Dummy data
            Order ord1 = new Order();
            ord1.OrderNumber = 5;
            ord1.DatePlaced = DateTime.Now;
            User test = new User();
            test.Name = "John Johnson";
            test.Phone = "218-330-8004";
            test.UserId = 1234;
            ord1.Purchaser = test;
            ord1.TotalCost = 1000000;

            Order ord2 = new Order();
            ord2.OrderNumber = 6;
            ord2.DatePlaced = DateTime.Now;
            User test2 = new User();
            test2.Name = "Erik Anderson";
            test2.Phone = "356-318-3450";
            test2.UserId = 5678;
            ord2.Purchaser = test2;
            ord2.TotalCost = 5200;

            icollection = new ObservableCollection<Order>();
            icollection.Add(ord1);
            icollection.Add(ord2);

            ////////////////////////////////////////////////////////

            //Item thing1 = new Item();
            //thing1.Name = "Retro Jordan 4";
            //thing1.Cost = 199.99m;
            //thing1.ItemNumber = 4;
            //thing1.OrderItems = dummy1.OrderItems;
            //thing1.QuantityOnHand = 7;

            //Item thing2 = new Item();
            //thing2.Name = "Retro Jordan 13";
            //thing2.Cost = 249.99m;
            //thing2.ItemNumber = 13;
            //thing2.OrderItems = dummy2.OrderItems;
            //thing2.QuantityOnHand = 17;

            //OrderItem dumster1 = new OrderItem();
            //dumster1.ItemNumber = thing1.ItemNumber;
            //dumster1.Quantity = 5;
            //dumster1.ItemCost = 41;
            //dumster1.Item = thing1;
            //dumster1.OrderNumber = dummy1.OrderNumber;
            //dumster1.OrderItemNumber = thing1.ItemNumber;
            //dumster1.Order = dummy1;

            //OrderItem dumster2 = new OrderItem();
            //dumster2.ItemNumber = thing1.ItemNumber;
            //dumster2.Quantity = 9;
            //dumster2.ItemCost = 70;
            //dumster2.Item = thing2;
            //dumster2.OrderNumber = dummy2.OrderNumber;
            //dumster2.OrderItemNumber = thing2.ItemNumber;
            //dumster2.Order = dummy1;

            //icollection = new ObservableCollection<OrderItem>();
            //icollection.Add(dumster1);
            //icollection.Add(dumster2);

            //icollection = new ObservableCollection<Item>();
            //icollection.Add(thing1);
            //icollection.Add(thing2);

        }

        public IInventoryData DataManager
        {
            get; set;
        }

        /// <summary>
        /// Save Button Handeling. It called the CheckANDSave function when triggered...
        /// </summary>
        public ICommand SaveOrderB
        {
            get
            {
                //MessageBox.Show("NewOrdersButton Triggered");
                return new DelegateCommand<object>(CheckANDSave, true);
            }

        }

        /// <summary>
        /// This is where you check for valid input and save
        /// </summary>
        public void CheckANDSave()
        {
            bool AbleToSave = true;//used to see if they can save
            int regOrderNumber;// if parse is successful this should have a value
            DateTime Udate;// tool for parsing dates this should have a value if successful
            decimal OrderTotal;// if parse is successful this should have a value
            //////////////////////////////////////////////////////////_UOrderNumber Error Handeling
            if (String.IsNullOrWhiteSpace(_UOrderNumber))
            {// check if empty
                MessageBox.Show("Please Type in the Order Number");
                AbleToSave = false;
            }
            else if (!Int32.TryParse(_UOrderNumber, out regOrderNumber))
            {
                AbleToSave = false;
                MessageBox.Show("Please Type in the Order Number");
            }
            else if(regOrderNumber != null)
            {
                if(regOrderNumber <= 0)
                {
                    AbleToSave = false;
                    MessageBox.Show("Please Type in a number greater than 0 for Order Number");
                }
            }
            //////////////////////////////////////////////////////////_UOrderNumber Error Handeling

            //////////////////////////////////////////////////////////_UPurchaseDate Error Handeling
            if (String.IsNullOrWhiteSpace(_UPurchaseDate))
            {// check if empty
                MessageBox.Show("Please Type in a Purchase Date");
                AbleToSave = false;
            }
            else if (!DateTime.TryParse(_UPurchaseDate,out Udate))
            {
                AbleToSave = false;
                MessageBox.Show("Please enter a proper date format");
            }
            //////////////////////////////////////////////////////////_UPurchaseDate Error Handeling

            //////////////////////////////////////////////////////////_UPurchaser Error Handeling
            if (String.IsNullOrWhiteSpace(_UPurchaser))
            {// check if empty
                MessageBox.Show("Please Type in a Purchaser");
                AbleToSave = false;
            }
            //////////////////////////////////////////////////////////_UPurchaser Error Handeling

            //////////////////////////////////////////////////////////_UOrderTotal Error Handeling
            if (String.IsNullOrWhiteSpace(_UOrderTotal))
            {// check if empty
                MessageBox.Show("Please Type in the Order Total");
                AbleToSave = false;
            }
            else if (!Decimal.TryParse(_UOrderTotal, out OrderTotal))
            {
                AbleToSave = false;
                MessageBox.Show("Please Type in the Order Number");
            }
            else if (OrderTotal != null)
            {
                if (OrderTotal <= 0)
                {
                    AbleToSave = false;
                    MessageBox.Show("Please Type in a number greater than 0 for Order Total");
                }
            }
            //////////////////////////////////////////////////////////_UOrderTotal Error Handeling

        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            Items = await DataManager.GetItemsAsync();

            //IoC.Get<OrdersViewModel>(). = Title;
        }

        public ObservableCollection<Order> AllOrders
        {
            get
            {
                return icollection;
            }
        }
        public void Orders()
        {
            //var ordersVM = IoC.Get<OrdersViewModel>();
            //IoC.Get<OrdersViewModel>();
            //OnActivate(ordersVM);
        }
        IEnumerable<Order> OrdersView
        {
            get { return icollection; }
        }

        /////////////////////////////////////////////////////////////////

        private ObservableCollection<OrderItem> orderItems;
        public ObservableCollection<OrderItem> AllItems
        {
            get
            {
                return orderItems;
            }
        }

        /// <summary>
        /// This is where you receive the textbox's information
        /// </summary>
        /// 
        public string UOrderNumber
        {
            get
            {
                return _UOrderNumber;
            }
            set
            {
                _UOrderNumber = value;
                NotifyOfPropertyChange(_UOrderNumber);
            }
        }
        public string UPurchaseDate
        {
            get
            {
                return _UPurchaseDate;
            }
            set
            {
                _UPurchaseDate = value;
                NotifyOfPropertyChange(_UPurchaseDate);
            }
        }
        public string UPurchaser
        {
            get
            {
                return _UPurchaser;
            }
            set
            {
                _UPurchaser = value;
                NotifyOfPropertyChange(_UPurchaser);
            }
        }
        public string UOrderTotal
        {
            get
            {
                return _UOrderTotal;
            }
            set
            {
                _UOrderTotal = value;
                NotifyOfPropertyChange(_UOrderTotal);
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////
        /// </summary>
        /// 

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
}
