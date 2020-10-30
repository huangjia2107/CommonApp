using CommonApp.Service.Interfaces;

namespace CommonApp.One.Services
{
    public class OneExtensionModel : IExtensionModel
    {
        public string Name => "One";

        public string Icon => "";

        public double IconWidth => 25d;

        public double IconHeight => 25d;
    }
}
