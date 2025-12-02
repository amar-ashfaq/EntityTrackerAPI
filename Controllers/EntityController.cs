using EntityTrackerAPI.Entities;
using EntityTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        public IEntityService entityService;

        public EntityController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entity>> GetEntities()
        {
            var entities = entityService.GetAll();
            return Ok(entities);       
        }

        [HttpGet("{id}")]
        public ActionResult<Entity> GetEntity(int id)
        {
            try
            {
                var entity = entityService.GetById(id);
                return Ok(entity);
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }          
        }

        [HttpPost]
        public ActionResult<Entity> CreateEntity(Entity entity) {

            try
            {
                var created = entityService.Create(entity);
                return CreatedAtAction(nameof(GetEntity), new { id = created.Id }, created);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid entity.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntity(int id, Entity entity) {

            try
            {
                entityService.Update(id, entity);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid entity.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntity(int id)
        {
            try
            {
                entityService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteEntities()
        {
            entityService.DeleteAll();
            return NoContent();
        }
    }
}
