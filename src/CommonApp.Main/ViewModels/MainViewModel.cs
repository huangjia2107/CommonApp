using Prism.Mvvm;

namespace CommonApp.Main.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _title = "Common App";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
