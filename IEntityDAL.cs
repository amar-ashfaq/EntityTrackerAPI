using EntityTrackerAPI.Entities;

namespace EntityTrackerAPI
{
    public interface IEntityDAL
    {
        List<Entity> SelectAllEntities();
        void AddEntry(Entity entity);
        void UpdateEntry(Entity entity);
        void DeleteEntry(int id);
        void DeleteAll();
    }
}
