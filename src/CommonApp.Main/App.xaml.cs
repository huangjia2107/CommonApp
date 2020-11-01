using System.Windows;
using System.Windows.Controls;

using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Modularity;
using Prism.Regions;
using Prism.Events;

using CommonApp.Main.Views;
using CommonApp.Main.ViewModels;
using CommonApp.Main.Models;
using CommonApp.Main.Dialogs;
using CommonApp.Main.Regions;
using CommonApp.Service;
using CommonApp.Service.Interfaces;
using CommonApp.Service.Events;

namespace CommonApp.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainViewModel>();
            ViewModelLocationProvider.Register<SidebarControl, SidebarViewModel>();
            ViewModelLocationProvider.Register<StatusControl, StatusViewModel>();
            ViewModelLocationProvider.Register<ZeroControl, ZeroViewModel>();
            ViewModelLocationProvider.Register<MessageDialog, MessageDialogViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(Grid), Container.Resolve<GridRegionAdapter>());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Dialog
            containerRegistry.RegisterDialogWindow<DialogWindow>();
            containerRegistry.RegisterDialog<MessageDialog, MessageDialogViewModel>();

            //version
            var version = ResourceAssembly.GetName().Version;
            var appData = new AppData { Version = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build) };

            containerRegistry.RegisterInstance(appData);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = ResourcesMap.LocationDic[Location.ModulePath] };
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var _regionManager = Container.Resolve<IRegionManager>();
            _regionManager?.RegisterViewWithRegion(RegionNames.WorkName, typeof(ZeroControl));

            //Load Extensions
            var extensionModels = Container.Resolve<IExtensionModel[]>();
            if (extensionModels != null && extensionModels.Length > 0)
            {
                //Save Extensions
                var appData = Container.Resolve<AppData>();
                appData.InternalData.ExtensionModels = extensionModels;
            }
                
            //Sync Extensions
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator?.GetEvent<RefreshExtensionEvent>().Publish();
        }
    }
}
