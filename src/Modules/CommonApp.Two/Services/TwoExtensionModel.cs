using CommonApp.Service.Interfaces;

namespace CommonApp.One.Services
{
    public class TwoExtensionModel : IExtensionModel
    {
        public string Name => "Two";

        public string Icon => "";

        public double IconWidth => 25d;

        public double IconHeight => 25d;
    }
}
