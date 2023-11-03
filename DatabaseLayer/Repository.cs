using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Core.Models;
using DatabaseLayer.Abstractions;
using static System.Net.Mime.MediaTypeNames;

namespace DatabaseLayer
{
    internal class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly IDBWorker _dbWorker;
        private JObject? _currentJObject;

        public Repository(IDBWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public async Task<T> CreateEntity(T entity)
        {
            List<T> result = await ReadFromDB();

            int id = GetNewId(result);
            entity.Id = id;
            result.Add(entity);

            await WriteToDB(result);
            return entity;
        }

        public async Task DeleteEntity(T entity)
        {
            List<T> result = await ReadFromDB();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Id == entity.Id)
                {
                    result.RemoveAt(i);
                    break;
                }
            }

            await WriteToDB(result);
        }

        public async Task<List<T>> GetEntities(Func<T, bool>? filter = null)
        {
            List<T> result = await ReadFromDB();
            result = filter == null ? result : result.Where(filter).ToList();
            return result;
        }

        public async Task<T> UpdateEntity(T entity)
        {
            List<T> result = await ReadFromDB();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Id == entity.Id)
                {
                    result[i] = entity;
                    await WriteToDB(result);
                    return result[i];
                }
            }

            return entity;
        }

        public async Task<List<T>> ReadFromDB()
        {
            string data = await _dbWorker.ReadFromDB();
            JObject jObject = JObject.Parse(data);
            JToken? jsonProperty = jObject[typeof(T).Name];
            List<T> result = new List<T>();

            if (jsonProperty != null)
            {
                List<T>? entities = JsonConvert.DeserializeObject<List<T>>(jsonProperty.ToString());
                result = entities ?? result;
            }

            _currentJObject = jObject;
            return result;
        }

        public int GetNewId(List<T> entities)
        {
            entities.Sort((a, b) => a.Id >= b.Id ? 1 : -1);
            T? entity = entities.LastOrDefault();
            int id = entity == null ? 1 : entity.Id + 1;
            return id;
        }

        private async Task WriteToDB(List<T> entities)
        {
            if (_currentJObject != null)
            {
                JToken jsonProperty = JToken.FromObject(entities);
                _currentJObject[typeof(T).Name] = jsonProperty;
                string data = _currentJObject.ToString();
                await _dbWorker.WriteToDB(data);
            }
        }
    }
}
