using Microsoft.AspNetCore.Mvc;
using ManufacturingExecutionSystem1.GenericRepository;
using ManufacturingExecutionSystem1.entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManufacturingExecutionSystem1.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManufacturingExecutionSystem1.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;

        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await productRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    [HttpOptions("{id}")]
    public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
    {
      try
      {
        var pr = await productRepository.GetById(id);
        if (pr == null) return NotFound();
        return pr;
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
           "Error retrieving data from the database");
      }

    }

    // GET api/<ProductController>/5
    [HttpGet("{code}")]
        public async Task<ActionResult<Product>> GetProductByCode(string code)
        {
            try
            {
                var pr = await productRepository.GetByCode(code);
                if (pr == null) return NotFound();
                return pr;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product model)
        {
            /* string filename = "";
             if (productDTO.Image != null)
             {
                 if (productDTO.Image != null)
                 {
                     String uploadfolder = Path.Combine(hostingEnvironment.EnvironmentName, "images");
                     filename = Guid.NewGuid().ToString() + "_" + productDTO.Image.FileName;
                     String filepath = Path.Combine(uploadfolder, filename);
                     productDTO.Image.CopyTo(new FileStream(filepath, FileMode.Create));
                 }

             }*/
           
            try
            {
                if (model == null)
                { return BadRequest(); }
                var pr = await productRepository.Add(model);
                return CreatedAtAction(nameof(GetProductById), new { id = pr.IDProduct }, pr);
            }
            catch (Exception)
            {
        if (productRepository.DataExist(model.ItemCode))
        {
          return StatusCode(StatusCodes.Status409Conflict, "Product exists ! try to create a new Product please !");
        }
        else
        {
          return StatusCode(StatusCodes.Status500InternalServerError,
          "Error creating new data! Something wrong...");
        }
      }

        }

        // PUT api/<ProductController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<Product>> UpdateProduct(string code, [FromBody] Product model)
        {
            try
            {
                if (code != model.ItemCode)
                    return BadRequest("key mismatch!");
                var pr = await productRepository.GetByCode(code);
                if (pr == null)
                    return NotFound("data not found");
                return await productRepository.Update(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{code}")]
        public async Task DeleteProduct(string code)
        {
            try
            {
                var pr = await productRepository.GetByCode(code);
               
                ModelState.Remove("Process");
                if (pr == null)
                {
                    NotFound("data not found");
                }
        
        await productRepository.Delete(code);
         NoContent();
            }
            catch (Exception)
            {
               StatusCode(StatusCodes.Status500InternalServerError,
               "Error deleting data");
            }
        }
    }
}
