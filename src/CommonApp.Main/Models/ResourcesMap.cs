using System;
using System.Collections.Generic;

namespace CommonApp.Main.Models
{
    public static class ResourcesMap
    {
        public static Dictionary<Location, string> LocationDic = new Dictionary<Location, string>
        {
            [Location.GlobalConfigFile] = AppDomain.CurrentDomain.BaseDirectory + "Config\\GlobalConfig.json",
			[Location.DataSourceFile] = AppDomain.CurrentDomain.BaseDirectory + "Config\\DataSource.ds",
            [Location.ModulePath] = AppDomain.CurrentDomain.BaseDirectory + "Modules",
        };
    }
}
