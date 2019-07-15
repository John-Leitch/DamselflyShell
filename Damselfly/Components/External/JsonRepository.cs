using Utf8Json;

namespace Components
{
    public static class JsonRepository
    {
        public static TEntities Load<TEntities>() =>
            new JsonRepository<TEntities>().Load();

        public static void Load<TEntities>(out TEntities entities) =>
            entities = new JsonRepository<TEntities>().Load();

        public static void LoadOrCreate<TEntities>(out TEntities entities)
            where TEntities : class, new() =>
            entities = new JsonRepository<TEntities>().Load() ?? new TEntities();

        public static void Save<TEntities>(TEntities entities) =>
            new JsonRepository<TEntities>().Save(entities);

        
    }
}
