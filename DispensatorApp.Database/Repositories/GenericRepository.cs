using Newtonsoft.Json;

namespace DispensatorApp.Database.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private string _path { get; set; }
        public GenericRepository()
        {
            _path = @"C:\Users\User\source\repos\DispensatorApp\DispensatorApp.Database\Persistence.json";
        }

        public void Add(T entity)
        {
            string converter = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(_path, converter);
        }

        public T GetEntity()
        {
            try
            {
                string readingJson = File.ReadAllText(_path);
                T entity = JsonConvert.DeserializeObject<T>(readingJson);
                return entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
