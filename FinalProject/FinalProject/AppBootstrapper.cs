namespace FinalAssignment
{
	using System;
	using System.Collections.Generic;
	using Caliburn.Micro;
	using FinalAssignment.ViewModels;
	using InventoryData;
	using InventoryDataInteraction;
    //using Common.Interfaces; don't know what this is for yet...

    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Activated += (instance) =>
            {
                container.BuildUp(instance);
            };

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<MainViewModel>();  // Juan
            container.PerRequest<InventoryViewModel>();  // Colin
            container.PerRequest<NewOrderViewModel>();  // Colin
            container.PerRequest<OrdersViewModel>();  // Robert

            container.Singleton<IInventoryData, DatabaseInteraction>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}