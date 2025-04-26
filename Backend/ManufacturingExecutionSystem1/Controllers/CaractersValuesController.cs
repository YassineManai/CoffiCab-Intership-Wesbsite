using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class CaractersValuesController : ControllerBase
    {
        private IRepository<CaracterValues> repository;
        public CaractersValuesController(IRepository<CaracterValues> repository)
        {
            this.repository = repository;
        }
        // GET: api/<CaractersValuesController>
        [HttpGet]
        public async Task<ActionResult> GetAllValuesOfCaracters()
        {
            try
            {
                return Ok(await repository.GetAll());
            }catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database"); }
        }

        // GET api/<CaractersValuesController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult<CaracterValues>> GetValuesByID(int id)
        {
            try
            {
                var cv = await repository.GetById(id);
                if (cv == null) return NotFound();
                return cv;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        // POST api/<CaractersValuesController>
        [HttpPost]
        public async Task<ActionResult<Caracters>> CreateValue([FromBody] CaracterValues model)
        {
           
            ModelState.Remove("Caracter");
            try
            {
                if (model == null)
                { return BadRequest(); }
                var pr = await repository.Add(model);
                return CreatedAtAction(nameof(GetValuesByID), new { id = pr.IDCaracterValues }, pr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new data");
            }
        }

        // PUT api/<CaractersValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CaracterValues>> UpdateCaracter(int id, [FromBody] CaracterValues model )
        {
            try
            {
                if (id != model.IDCaracterValues)
                    return BadRequest("key mismatch!");
                var pr = await repository.GetById(id);
                if (pr == null)
                    return NotFound("data not found");
                return await repository.Update(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<CaractersValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try
            {
                var pr = await repository.GetByCode(id);
                ModelState.Remove("Caracter"); ;
                if (pr == null)
                {
                    NotFound("data not found");
                }
                await repository.Delete(id);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }
        }
    }
    }

