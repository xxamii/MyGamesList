using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core;
using DatabaseLayer.Abstractions;

namespace DatabaseLayer
{
    internal class DBWorker : IDBWorker
    {
        private readonly string pathToDB;

        public DBWorker(AppSettings appSettings)
        {
            pathToDB = Path.GetFullPath(appSettings.PathToDB);
        }

        public async Task<string> ReadFromDB()
        {
            string data = await File.ReadAllTextAsync(pathToDB);
            return data;
        }

        public async Task WriteToDB(string data)
        {
            await File.WriteAllTextAsync(pathToDB, data);
        }
    }
}
