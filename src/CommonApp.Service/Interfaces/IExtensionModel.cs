using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonApp.Service.Interfaces
{
    public interface IExtensionModel
    {
        string Name { get; }
        string Icon { get; }
        double IconWidth { get; }
        double IconHeight { get; }
    }
}
