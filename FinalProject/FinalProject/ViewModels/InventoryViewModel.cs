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
    class InventoryViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private ObservableCollection<Item> icollection;
        public InventoryViewModel()
        {
            this.DisplayName = "Inventory Application";

            //Dummy data
            Item inv1 = new Item();
            inv1.ItemNumber = 1;
            inv1.Name = "Boxers";
            inv1.Cost = 2500;
            inv1.QuantityOnHand = 250000;

            icollection = new ObservableCollection<Item>();
            icollection.Add(inv1);

            Item inv2 = new Item();
            inv2.ItemNumber = 2;
            inv2.Name = "Briefs";
            inv2.Cost = 2000;
            inv2.QuantityOnHand = 625000;

            icollection.Add(inv2);
        }
        public ObservableCollection<Item> AllItems
        {
            get
            {
                return icollection;
            }
        }
        protected override void OnActivate()
        {
            base.OnActivate();
            Orders();
            foreach (Item od in icollection)
            {
                //OrdersViewList.
            }
        }
        public void Orders()
        {
            //var ordersVM = IoC.Get<OrdersViewModel>();
            //IoC.Get<OrdersViewModel>();
            //OnActivate(ordersVM);
        }
        IEnumerable<Item> ItemsView
        {
            get { return icollection; }
        }
    }
}
