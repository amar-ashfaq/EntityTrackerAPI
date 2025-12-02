using EntityTrackerAPI.Entities;

namespace EntityTrackerAPI.Services
{
    public interface IEntityService
    {
        List<Entity> GetAll();
        Entity GetById(int id);
        Entity Create(Entity entity);
        Entity Update(int id, Entity entity);
        void Delete(int id);
        void DeleteAll();
    }
}
