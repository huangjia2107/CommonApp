using Prism.Services.Dialogs;
using CommonApp.Theme.Controls;

namespace CommonApp.Main.Dialogs
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : UserWindow, IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent(); 
        }

        #region IDialogWindow Members

        public IDialogResult Result { get; set; }

        #endregion
    }
}
