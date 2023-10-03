using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core.Models;
using DatabaseLayer.Abstractions;

namespace DatabaseLayer
{
    internal class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly IDBWorker _dbWorker;

        public Repository(IDBWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public async Task CreateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetEntities(Func<T, bool> filter)
        {
            List<T> result = new List<T>();
            string jsonString = await _dbWorker.ReadFromDB();
            JObject jObject = JObject.Parse(jsonString);
            JToken? jsonProperty = jObject[typeof(T).Name];

            if (jsonProperty != null)
            {
                List<T>? entities = JsonConvert.DeserializeObject<List<T>>(jsonProperty.ToString());
                result = entities ?? result;
            }
            
            return result;
        }

        public async Task UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
