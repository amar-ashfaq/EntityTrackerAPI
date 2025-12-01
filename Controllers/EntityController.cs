using EntityTrackerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EntityTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        public IEntityDAL entityDAL;

        public EntityController(IEntityDAL entityDAL)
        {
            this.entityDAL = entityDAL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entity>> GetEntities()
        {
            var entities = entityDAL.SelectAllEntities();
            if (entities.Count == 0)
            {
                return NotFound();
            }

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<Entity> GetEntity(int id)
        {
            var entities = entityDAL.SelectAllEntities();
            var entity = entities.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<Entity> CreateEntity(Entity entity) {

            if (entity == null)
            {
                return BadRequest();
            }

            var entities = entityDAL.SelectAllEntities();

            entity.Id = entities.Any() ? entities.Max(x => x.Id) + 1: 0;
           
            entityDAL.AddEntry(entity);

            return CreatedAtAction(nameof(GetEntity), new { id = entity.Id}, entity);
        }

        [HttpPut("{id}")]
        public ActionResult<Entity> UpdateEntity(int id, Entity entity) {

            if (entity == null)
            {
                return BadRequest(); 
            }

            var entities = entityDAL.SelectAllEntities();
            var existing = entities.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound();
            }
            
            entity.Id = id;
            entityDAL.UpdateEntry(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEntity(int id)
        {
            var entities = entityDAL.SelectAllEntities();
            var existing = entities.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound();
            }

            entityDAL.DeleteEntry(id);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteEntities()
        {
            var entities = entityDAL.SelectAllEntities();

            if (!entities.Any())
            {
                return NoContent();
            }

            entityDAL.DeleteAll();
            return NoContent();
        }

    }
}
