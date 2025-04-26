
using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;
using ManufacturingExecutionSystem1.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class CaractersController : ControllerBase
    {
        private IRepository<Caracters> caracterRepository;

        public CaractersController(IRepository<Caracters> caracterRepository)
        {
            this.caracterRepository = caracterRepository;

        }

        // GET: api/<CaractersController>
        [HttpGet]
        public  async Task<ActionResult> GetAllCaracters()
        {
            try
            {
                return Ok( await caracterRepository.GetAll());
            }catch (Exception) { return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database"); }
        }

        // GET api/<CaractersController>/5
        [HttpOptions("{id}")]
        public async Task<ActionResult<Caracters>> GetCaracterByID(int id)
        {
            try
            {
                var pr = await caracterRepository.GetById(id);
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
    public async Task<ActionResult<Caracters>> GetCaracterByCode([FromRoute] string code)
    {
      try
      {
        var pr = await caracterRepository.GetByCode(code);
        if (pr == null) return NotFound();
        return pr;
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
           "Error retrieving data from the database");
      }

    }
    // POST api/<CaractersController>
    [HttpPost]
    public async Task<ActionResult<Caracters>> CreateCaracter([FromBody] Caracters model)
    {
      /* string filename = "";
       if(caracterDTO.Image_Caracters != null)
       {
           String uploadfolder = Path.Combine(hostingEnvironment.EnvironmentName, "images");
           filename = Guid.NewGuid().ToString() + "_" + caracterDTO.Image_Caracters.FileName;
           String filepath = Path.Combine(uploadfolder, filename);
           caracterDTO.Image_Caracters.CopyTo(new FileStream(filepath, FileMode.Create));
       }
       caracterDTO.Process = (IEnumerable<SelectListItem>)_context.Process.Select(p => new SelectListItem()
       {
           Text=p.CodeProcess,
           Value = p.IDPorcess.ToString()
       });*/

      try
      {
        if (model == null)
        { return BadRequest(); }
        var pr = await caracterRepository.Add(model);
        return CreatedAtAction(nameof(GetCaracterByID), new { id = pr.IDCaracters }, pr);
      }
      catch (Exception)
      {
        if (caracterRepository.DataExist(model.CodeCaracter))
        {
          return StatusCode(StatusCodes.Status409Conflict, "Caracter exist ! try to create a new Caracter please !");
        }
        else
        {
          return StatusCode(StatusCodes.Status500InternalServerError,
          "Error creating new data! Something wrong...");
        }

      }
    }
        // PUT api/<CaractersController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<Caracters>> UpdateCaracter(string code, [FromBody] Caracters model)
        {
            try
            {
                if (code != model.CodeCaracter)
                    return BadRequest("key mismatch!");
                var pr = await caracterRepository.GetByCode(code);
                if (pr == null)
                    return NotFound("data not found");
                return await caracterRepository.Update(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<CaractersController>/5
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            try
            {
                var pr = await caracterRepository.GetByCode(code);
                
                if (pr == null)
                {
                    NotFound("data not found");
                }
                await caracterRepository.Delete(code);
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }
        }
    }
}
