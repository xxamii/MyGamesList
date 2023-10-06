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
        private JObject _currentJObject;
        private JToken? _currentToken;

        public Repository(IDBWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public async Task<T> CreateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetEntities(Func<T, bool>? filter = null)
        {
            List<T> result = new List<T>();
            await ReadFromDB();

            if (_currentToken != null)
            {
                List<T>? entities = JsonConvert.DeserializeObject<List<T>>(_currentToken.ToString());
                result = entities ?? result;
            }

            result = filter == null ? result : result.Where(filter).ToList();

            return result;
        }

        public async Task<T> UpdateEntity(T entity)
        {
            List<T> result = new List<T>();
            await ReadFromDB();

            if (_currentToken != null)
            {
                List<T>? entities = JsonConvert.DeserializeObject<List<T>>(_currentToken.ToString());
                result = entities ?? result;
            }

            for (int i = 0; i < result.Count(); i++)
            {
                if (result[i].Id == entity.Id)
                {
                    result[i] = entity;
                    break;
                }
            }

            _currentToken = JToken.FromObject(result);
            await WriteToDB();

            return entity;
        }

        private async Task ReadFromDB()
        {
            JObject jObject = await _dbWorker.ReadFromDB();
            JToken? jsonProperty = jObject[typeof(T).Name];

            _currentJObject = jObject;
            _currentToken = jsonProperty;
        }

        private async Task WriteToDB()
        {
            _currentJObject[typeof(T).Name] = _currentToken;
            await _dbWorker.WriteToDB(_currentJObject);
        }
    }
}
