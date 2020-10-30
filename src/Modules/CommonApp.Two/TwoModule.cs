using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using CommonApp.Service;
using CommonApp.Service.Interfaces;
using CommonApp.One.Views;
using CommonApp.One.Services;

namespace CommonApp.One
{
    public class TwoModule : IModule
    {
        private IRegionManager _regionManager = null;

        #region IModule Members

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
            _regionManager.RegisterViewWithRegion(RegionNames.WorkName, typeof(TwoControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IExtensionModel, TwoExtensionModel>("TwoModule");
        }

        #endregion
    }
}
