using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private  IRepository<Process> processRepository;
    
        public ProcessesController(IRepository<Process> processRepository)
        {
            this.processRepository= processRepository;
        }
        // GET: api/<ProcessesController>
        [HttpGet]
        public async Task<ActionResult> GetAllProcesses()
        {
            try
            {
                return Ok(await processRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }

        }

        // GET api/<ProcessesController>/5
        [HttpOptions("{id}")]
        public async Task<ActionResult<Process>> GetProcessById([FromRoute] int id)
        {
            try
            {
                var pr = await processRepository.GetById(id);
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
    public async Task<ActionResult<Process>> GetProcessByCode([FromRoute] string code)
    {
      try
      {
        var pr = await processRepository.GetByCode(code);
        if (pr == null) return NotFound();
        return pr;
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
           "Error retrieving data from the database");
      }

    }

    // POST api/<ProcessesController>
    [HttpPost]
        public async Task<ActionResult> CreateProcess(Process model)
        {
     /* var processExist = processRepository.GetByCode(model.CodeProcess);
    if (processExist != null) { return BadRequest("Process already exists, try to create a new Process !"); }
      else
      {*/
        try
        {

         
          if (model == null)
          { return BadRequest(); }
       var pr =  await processRepository.Add(model);
        return CreatedAtAction(nameof(GetProcessById), new { id = pr.IDPorcess }, pr);

      }
        catch (Exception)
        {
        if (processRepository.DataExist(model.CodeProcess))
        {
          return StatusCode(StatusCodes.Status409Conflict, "Process exist ! try to create a new Process please !");
        }
        else { 
          return StatusCode(StatusCodes.Status500InternalServerError,
          "Error creating new data! Something wrong...");
        }
      }
     //}
            
        }

        // PUT api/<ProcessesController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<Process>> UpdateProcess([FromRoute] string code, [FromBody] Process model)
        {
            try
            {
                ModelState.Remove("Machines"); ModelState.Remove("Products"); ModelState.Remove("Caracters"); ModelState.Remove("process_ProfilUsers");

                if (code != model.CodeProcess)
                    return BadRequest("key mismatch!");
                var pr = await processRepository.GetByCode(code);
                if (pr == null)
                    return NotFound("data not found");
                return await processRepository.Update(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Error updating data");
            }
            
        }

        // DELETE api/<ProcessesController>/5
        [HttpDelete("{code}")]
        public async Task DeleteProcess([FromRoute] string code)
        {
            try
            {
                var pr = await processRepository.GetByCode(code);
                if (pr == null)
                {
                    NotFound("data not found");
                }
                await processRepository.Delete(code);
            }
            catch(Exception ) {
                StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }

           
        }
    }
}
