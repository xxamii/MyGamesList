using Core;
using DatabaseLayer.Abstractions;

namespace DatabaseLayer
{
    public static class DependencyInjectorFactory
    {
        private static IDBWorker? dbWorker;

        public static IDBWorker GetDBWorker()
        {
            if (dbWorker == null)
            {
                AppSettings appSettings = Core.DependencyInjectorFactory.GetAppSettings();
                dbWorker = new DBWorker(appSettings);
            }

            return dbWorker;
        }
    }
}
