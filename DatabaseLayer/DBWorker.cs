using System.IO;
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
            string text = await File.ReadAllTextAsync(pathToDB);
            return text;
        }

        public async Task WriteToDB(string data)
        {
            await File.WriteAllTextAsync(pathToDB, data);
        }
    }
}
