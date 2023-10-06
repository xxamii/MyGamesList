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

        public async Task<JObject> ReadFromDB()
        {
            string text = await File.ReadAllTextAsync(pathToDB);
            JObject result = JObject.Parse(text);
            return result;
        }

        public async Task WriteToDB(JObject data)
        {
            string text = data.ToString();
            await File.WriteAllTextAsync(pathToDB, text);
        }
    }
}
