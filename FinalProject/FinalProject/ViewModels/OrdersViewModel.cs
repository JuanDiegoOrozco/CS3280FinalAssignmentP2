using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using InventoryData;
using System.Collections.ObjectModel;

namespace FinalAssignment.ViewModels
{
    class OrdersViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private ObservableCollection<Order> icollection;
        private static Order SelectedItemInfo;
        public OrdersViewModel()
        {
            this.DisplayName = "View Orders";
            //Console.WriteLine("Wen through the Orders constructor!!!!!!");
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

            //////////////////////////////////////////////////////

            Item thing1 = new Item();
            thing1.Name = "Adidas";
            thing1.Cost = 69.99m;
            thing1.ItemNumber = 71;
            thing1.OrderItems = dummy2.OrderItems;
            thing1.QuantityOnHand = 17;

            Item thing2 = new Item();
            thing2.Name = "Retro Jordan 13";
            thing2.Cost = 249.99m;
            thing2.ItemNumber = 13;
            thing2.OrderItems = dummy2.OrderItems;
            thing2.QuantityOnHand = 17;

            Item thing3 = new Item();
            thing3.Name = "Playstation 5";
            thing3.Cost = 499.99m;
            thing3.ItemNumber = 21;
            thing3.OrderItems = dummy2.OrderItems;
            thing3.QuantityOnHand = 17;

            OrderItem dumster1 = new OrderItem();
            dumster1.ItemNumber = thing1.ItemNumber;
            dumster1.Quantity = 5;
            dumster1.ItemCost = 41;
            dumster1.Item = thing1;
            dumster1.OrderNumber = dummy1.OrderNumber;
            dumster1.OrderItemNumber = thing1.ItemNumber;
            dumster1.Order = dummy1;

            OrderItem dumster2 = new OrderItem();
            dumster2.ItemNumber = thing1.ItemNumber;
            dumster2.Quantity = 9;
            dumster2.ItemCost = 70;
            dumster2.Item = thing2;
            dumster2.OrderNumber = dummy2.OrderNumber;
            dumster2.OrderItemNumber = thing2.ItemNumber;
            dumster2.Order = dummy1;

            OrderItem dumster3 = new OrderItem();
            dumster3.ItemNumber = thing3.ItemNumber;
            dumster3.Quantity = 9;
            dumster3.ItemCost = 70;
            dumster3.Item = thing3;
            dumster3.OrderNumber = dummy2.OrderNumber;
            dumster3.OrderItemNumber = thing3.ItemNumber;
            dumster3.Order = dummy1;




            //items = new ObservableCollection<Item>();
            dummy1.OrderItems.Add(dumster1);
            dummy2.OrderItems.Add(dumster2);
            dummy2.OrderItems.Add(dumster3);
            //orderItems = (ObservableCollection<OrderItem>)dummy1.OrderItems;
            orderItems = new ObservableCollection<OrderItem>();

            //foreach (OrderItem x in SelectedItemInfo.OrderItems)
            //{
            //    orderItems.Add(x);
            //}
        }
        public ObservableCollection<Order> AllOrders
        {
            get
            {
                return icollection;
            }
        }
        protected override void OnActivate()
        {
            //base.OnActivate();
            Orders();
           
        }
        public void Orders()
        {
            //var ordersVM = IoC.Get<OrdersViewModel>();
            //IoC.Get<OrdersView>();
            //OnActivate(ordersVM);
        }
        //IEnumerable<Order> OrdersView
        //{
        //    get { return icollection; }
        //}
        /////////////////////////////////////////////////////////////////
        private ObservableCollection<OrderItem> orderItems;
        private static ObservableCollection<OrderItem> tester;
        public Order SelectedItem
        {
            get
            {
                return SelectedItemInfo;
            }
            set
            {
                //SelectedItemInfo = new Order();
                SelectedItemInfo = value;
                NotifyOfPropertyChange("AllItems");
            }
        }
        public ObservableCollection<OrderItem> AllItems
        {
            get
            {
                if (SelectedItemInfo !=null)
                {
                    //if (orderItems.Count != 0)
                    //{
                    //    foreach (OrderItem x in orderItems)
                    //    {
                    //        orderItems.Remove(x);
                    //        if (orderItems.Count < 1)
                    //        {
                    //            break;
                    //        }
                    //    }
                    //}
                    orderItems = new ObservableCollection<OrderItem>();
                    foreach (OrderItem x in SelectedItem.OrderItems)
                    {
                        orderItems.Add(x);
                        
                    }
                }
                
               
                return orderItems;
            }
        }
    }
}
