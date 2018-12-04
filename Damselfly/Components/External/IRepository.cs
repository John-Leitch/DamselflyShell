namespace Components
{
    public interface IRepository<TEntities>
    {
        TEntities Load();
        void Save(TEntities entities);
    }
}
