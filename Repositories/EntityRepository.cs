using EntityTrackerAPI.Entities;

namespace EntityTrackerAPI.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly List<Entity> entities =
        [
            new Entity { Id = 0, Description = "This is the first entity", Name = "EntityOne" },
            new Entity { Id = 1, Description = "This is the second entity", Name = "EntityTwo" },
            new Entity { Id = 2, Description = "This is the third entity", Name = "EntityThree" }
        ];

        public List<Entity> SelectAllEntities()
        {
            return entities;
        }

        public void AddEntry(Entity entity)
        {
            entities.Add(entity);
        }

        public void UpdateEntry(Entity entity) {

            int index = entities.FindIndex(x => x.Id == entity.Id);

            if (index != -1)
            {
                entities[index] = entity;
            }
        }

        public void DeleteEntry(int id)
        {
            var entity = entities.FirstOrDefault(x => x.Id == id);

            if (entity != null) {
                entities.Remove(entity);
            }
        }

        public void DeleteAll()
        {
            entities.Clear();
        }
    }
}
