using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IRepository<Machine> machineRepository;
        public MachineController(IRepository<Machine> machineRepository)
        {
            this.machineRepository = machineRepository;
        }
        // GET: api/<MachineController>
        [HttpGet]
        public async Task<ActionResult> GetAllMachines()
        {
            try
            {
                return Ok(await machineRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<MachineController>/5
        [HttpOptions("{id}")]
        public async Task<ActionResult<Machine>> GetMachineByID(int id)
        {
            try
            {
                var pr = await machineRepository.GetById(id);
                if (pr == null) return NotFound();
                return pr;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }
    [HttpGet("{code}")]
    public async Task<ActionResult<Machine>> GetMachineByCode(string code)
    {
      try
      {
        var pr = await machineRepository.GetByCode(code);
        if (pr == null) return NotFound();
        return pr;
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
           "Error retrieving data from the database");
      }
    }

    // POST api/<MachineController>
    [HttpPost]
    public async Task<ActionResult<Machine>> CreateMachine([FromBody] Machine model)
    {
      
        try
        {
          if (model == null)
          { return BadRequest(); }
          var pr = await machineRepository.Add(model);
          return CreatedAtAction(nameof(GetMachineByID), new { id = pr.IDPlant_Machine }, pr);
        }
        catch (Exception)
        {
          if (machineRepository.DataExist(model.Machine_Code))
          {
            return StatusCode(StatusCodes.Status409Conflict, "Machine exists ! try to create a new Machine please !");
          }
          else
          {
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error creating new data! Something wrong...");
          }
        }
      }
      
        // PUT api/<MachineController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<Machine>> UpdateMachine(string code, [FromBody] Machine model)
        {
            try
            {
                if (code != model.Machine_Code)
                    return BadRequest("key mismatch!");
                var pr = await machineRepository.GetByCode(code);
                if (pr == null)
                    return NotFound("data not found");
                return await machineRepository.Update(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<MachineController>/5
        [HttpDelete("{code}")]
        public async Task DeleteMachine(string code)
        {
            try
            {
                var pr = await machineRepository.GetByCode(code);
                ModelState.Remove("CodeProcess");
                ModelState.Remove("Process");
                if (pr == null)
                {
                    NotFound("data not found");
                }
                await machineRepository.Delete(code);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }
        }
    }
}
