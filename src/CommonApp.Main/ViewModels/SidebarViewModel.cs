using System.Linq;
using System.Collections.ObjectModel;

using Prism.Ioc;
using Prism.Mvvm;
using Prism.Events;

using CommonApp.Main.Models;
using CommonApp.Service.Events;

namespace CommonApp.Main.ViewModels
{
    public class SidebarViewModel : BindableBase
    {
        private AppData _appData = null;
        private IEventAggregator _eventAggregator = null;

        public SidebarViewModel(IContainerExtension container, IEventAggregator eventAggregator)
        {
            _appData = container.Resolve<AppData>();
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<RefreshExtensionEvent>().Subscribe(OnRefreshExtension);
        }

        private ObservableCollection<ExtensionViewModel> _extensionCollection = null;
        public ObservableCollection<ExtensionViewModel> ExtensionCollection 
        {
            get { return _extensionCollection; }
        }

        #region Event

        private void OnRefreshExtension()
        {
            _extensionCollection = new ObservableCollection<ExtensionViewModel>(_appData.InternalData.ExtensionModels?.Select(em => new ExtensionViewModel(em)));
            RaisePropertyChanged(nameof(ExtensionCollection));
        }

        #endregion
    }
}
