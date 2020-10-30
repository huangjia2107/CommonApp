using Prism.Mvvm;

using CommonApp.Service.Interfaces;

namespace CommonApp.Main.ViewModels
{
    public class ExtensionViewModel: BindableBase
    {
        private IExtensionModel _extensionModel;

        public ExtensionViewModel(IExtensionModel extensionModel)
        {
            _extensionModel = extensionModel;
        }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get { return _isChecked = false; }
            set { SetProperty(ref _isChecked, value); }
        }

        public string Name => _extensionModel.Name;

        public string Icon => _extensionModel.Icon;

        public double IconWidth => _extensionModel.IconWidth;

        public double IconHeight => _extensionModel.IconHeight;
    }
}
