using Newtonsoft.Json.Linq;

namespace DatabaseLayer.Abstractions
{
    public interface IDBWorker
    {
        public Task WriteToDB(string data);
        public Task<string> ReadFromDB();
    }
}
