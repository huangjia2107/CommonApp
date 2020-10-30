using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using CommonApp.Service;
using CommonApp.Service.Interfaces;
using CommonApp.One.Views;
using CommonApp.One.Services;

namespace CommonApp.One
{
    public class OneModule : IModule
    {
        private IRegionManager _regionManager = null;

        #region IModule Members

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
            _regionManager.RegisterViewWithRegion(RegionNames.WorkName, typeof(OneControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IExtensionModel, OneExtensionModel>("OneModule");
        }

        #endregion
    }
}
