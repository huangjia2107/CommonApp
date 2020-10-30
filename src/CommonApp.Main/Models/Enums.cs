
namespace CommonApp.Main.Models
{
    public enum Location
    {
        GlobalConfigFile,
		DataSourceFile,
        ModulePath,
    }

    public enum MessageType
    { 
        None, 
        Error, 
        Warning,
        Information, 
        Question
    }

    public enum MessageButton
    {
        OK, 
        OKCancel,
        YesNoCancel,
        YesNo
    }
}
