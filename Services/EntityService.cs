using EntityTrackerAPI.Entities;
using EntityTrackerAPI.Repositories;

namespace EntityTrackerAPI.Services
{
    public class EntityService : IEntityService
    {
        public readonly IEntityRepository entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public List<Entity> GetAll()
        {
            return entityRepository.SelectAllEntities();
        }

        public Entity GetById(int id)
        {
            var entities = entityRepository.SelectAllEntities();
            var entity = entities.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} does not exist.");
            }

            return entity;
        }

        public Entity Create(Entity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var entities = entityRepository.SelectAllEntities();

            entity.Id = entities.Any() ? entities.Max(x => x.Id) + 1 : 0;

            entityRepository.AddEntry(entity);

            return entity;
        }

        public Entity Update(int id, Entity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            var entities = entityRepository.SelectAllEntities();
            var existing = entities.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} does not exist.");
            }

            entity.Id = id;
            entityRepository.UpdateEntry(entity);

            return entity;
        }

        public void Delete(int id)
        {
            var entities = entityRepository.SelectAllEntities();
            var existing = entities.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} does not exist.");
            }

            entityRepository.DeleteEntry(id);
        }

        public void DeleteAll()
        {
            entityRepository.DeleteAll();
        }
    }
}
