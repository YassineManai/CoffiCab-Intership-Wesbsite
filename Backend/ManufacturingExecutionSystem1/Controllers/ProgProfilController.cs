using ManufacturingExecutionSystem1.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProgProfilController : ControllerBase
    {
        private readonly IProgProfil progProfilRepository;
        public ProgProfilController(IProgProfil progProfil)
        {
            this.progProfilRepository = progProfil;
        }
        // GET: api/<ProgProfilController>
        [HttpGet]
        public async Task<ActionResult> GetProgProfils()
        {
            try
            {
                return Ok(await progProfilRepository.GetProgProfils());
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
            
        }

        // GET api/<ProgProfilController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgProfil>> GetProgProfil(int id)
        {
            try
            {
                var pr = await progProfilRepository.GetProgProfil(id);
                if (pr == null) return NotFound();
                return pr;
            }catch(Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        // POST api/<ProgProfilController>
        [HttpPost]
        public async Task<ActionResult<ProgProfil>> CreateProgProfil([FromBody] ProgProfil model)
        {
            try
            {
                if (model == null)
                { return BadRequest(); }
                var pr = await progProfilRepository.AddProgProfil(model);
                return CreatedAtAction(nameof(GetProgProfil), new { id = pr.IDProgProfil }, pr);
            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new data");
            }
        }

        // PUT api/<ProgProfilController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProgProfil>> UpdateProgProfil(int id, [FromBody] ProgProfil model)
        {
            try
            {
                if (id != model.IDProgProfil)
                    return BadRequest("key mismatch!");
                var pr = await progProfilRepository.GetProgProfil(id);
                if(pr == null) 
                    return NotFound("data not found");
                return await progProfilRepository.UpdateProgProfil(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<ProgProfilController>/5
        [HttpDelete("{id}")]
        public async Task DeleteProgProfil(int id)
        {
            try
            {
                var pr = await progProfilRepository.GetProgProfil(id);
                if( pr == null)
                {
                     NotFound("data not found");
                }
                await progProfilRepository.DeleteProgProfil(id);
            }
            catch (Exception)
            {
                 StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }
        }
    }
}
