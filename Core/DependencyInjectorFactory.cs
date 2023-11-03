using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class DependencyInjectorFactory
    {
        public static AppSettings GetAppSettings()
        {
            return new AppSettings();
        }
    }
}
