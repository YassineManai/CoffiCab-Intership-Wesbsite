using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProfileUserController : ControllerBase
    {
        private IRepository<ProfilUser> repository;
        public ProfileUserController(IRepository<ProfilUser> repository)
        {
            this.repository = repository; 
        }
        // GET: api/<ProfileUserController>
        [HttpGet]
        public async Task<ActionResult> GetAllProfile()
        {
            try
            {
                return Ok(await repository.GetAll());
            }
            catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database"); }

        }

        // GET api/<ProfileUserController>/5
        [HttpOptions("{id}")]
        public async Task<ActionResult<ProfilUser>> GetProfilByID(int id)
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
    [HttpGet("{code}")]
    public async Task<ActionResult<ProfilUser>> GetProfilByCode(string code)
    {
      try
      {
        var cv = await repository.GetByCode(code);
        if (cv == null) return NotFound();
        return cv;
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
           "Error retrieving data from the database");
      }
    }

    // POST api/<ProfileUserController>
    [HttpPost]
        public async Task<ActionResult<ProfilUser>> CreateProfil([FromBody] ProfilUser model)
        { 
            ModelState.Remove("Process_ProfilUsers");
            try
            {
                if (model == null)
                { return BadRequest(); }
                var pr = await repository.Add(model);
                return CreatedAtAction(nameof(GetProfilByID), new { id = pr.IDProfiUser }, pr);
            }
      catch (Exception)
            {
        if (repository.DataExist(model.Id_Profil))
        {
          return StatusCode(StatusCodes.Status409Conflict, "Profil exists ! try to create a new please !");
        }
        else
        {
          return StatusCode(StatusCodes.Status500InternalServerError,
          "Error creating new data! Something wrong...");
        }
      }
        }

        // PUT api/<ProfileUserController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<ProfilUser>> UpdateProfil(string code, [FromBody] ProfilUser model)
        {
            try
            {
                ModelState.Remove("Process_ProfilUsers");
                if (code != model.Id_Profil)
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

        // DELETE api/<ProfileUserController>/5
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            ModelState.Remove("Process_ProfilUsers");
            try
            {
                var pr = await repository.GetByCode(code);
                ModelState.Remove("Caracter"); ;
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
