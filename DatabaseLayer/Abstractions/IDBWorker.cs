using Newtonsoft.Json.Linq;

namespace DatabaseLayer.Abstractions
{
    public interface IDBWorker
    {
        public Task WriteToDB(JObject data);
        public Task<JObject> ReadFromDB();
    }
}
