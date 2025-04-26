using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class CaractersStartOfShiftValuesController : ControllerBase
    {
        private readonly IRepository<CaractersStartOfShiftValues> repository;
        public CaractersStartOfShiftValuesController(IRepository<CaractersStartOfShiftValues> repository)
        {
            this.repository = repository;
        }
        // GET: api/<CaractersStartOfShiftValuesController>
        [HttpGet]
        public async Task<ActionResult> GetAllStartOfShiftValues()
        {
            try
            {
                return Ok(await repository.GetAll());
            }
            catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database"); }
        }

        // GET api/<CaractersStartOfShiftValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaractersStartOfShiftValues>> GetStartOfShiftValuesByID(int id)
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

        // POST api/<CaractersStartOfShiftValuesController>
        [HttpPost]
        public async Task<ActionResult<CaractersStartOfShiftValues>> CreateStartOfShiftValues([FromBody] CaractersStartOfShiftValues model)
        {
            /* caractersStartOfShiftValuesDTO.Machine = (IEnumerable<SelectListItem>)_context.Machine.Select(m => new SelectListItem()
             {
                 Text = m.Machine_Code,
                 Value = m.IDPlant_Machine.ToString()
             }) ;*/

            ModelState.Remove("Machine");
           
                try
                {
                    if (model == null)
                    { return BadRequest(); }
                    var pr = await repository.Add(model); ;
                    return CreatedAtAction(nameof(GetStartOfShiftValuesByID), new { id = pr.IDCaractersStartOfShiftValues }, pr);
                }
      catch (Exception)
                {
        if (repository.DataExist(model.CodeCaracterStartOFShift))
        {
          return StatusCode(StatusCodes.Status409Conflict, "Caracter exists! try to create a new Caracter please !");
        }
        else
        {
          return StatusCode(StatusCodes.Status500InternalServerError,
          "Error creating new data! Something wrong...");
        }
      }
            
        }
        // PUT api/<CaractersStartOfShiftValuesController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<CaractersStartOfShiftValues>> UpdateStartOfShiftValues(string code, [FromBody] CaractersStartOfShiftValues model)
        {

        ModelState.Remove("Machine");
            
                try
                {
                    if (code != model.CodeCaracterStartOFShift)
                        return BadRequest("key mismatch!");
                    var pr = await repository.GetByCode(code);
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

        // DELETE api/<CaractersStartOfShiftValuesController>/5
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            try
            {
                var pr = await repository.GetByCode(code);
                ModelState.Remove("Machine");
                if (pr == null)
                {
                    NotFound("data not found");
                }
                await repository.Delete(code);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }
        }
    }
}
