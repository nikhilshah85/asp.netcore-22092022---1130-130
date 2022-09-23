using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productsAPI.Model;
namespace productsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //we create crud actions here
        //they need to be based on HTTP Standards
        //Method should have return type as IActionResult
        //it should return Http Statud Code

        Product pObj = new Product(); //this is a crime 
                                      // we should not be creating any object as we are not habbitual to
                                      //destrory the object
                                      //USE DI instead

        #region HTTPGET

        [HttpGet]
        [Route("plist")]
        public IActionResult GetAllProducts()
        {
            return Ok(pObj.GetALlProducts());
        }

        [HttpGet]
        [Route("plist/id")]
        public IActionResult GetProductById(int id)
        {

            try
            {
                return Ok(pObj.GetProductById(id));
            }
            catch(Exception es)
            {
                return NotFound(es.Message);
            }
        }

        [HttpGet]
        [Route("plist/cat")]
        public IActionResult GetProdutByCategory(string cat)
        {
            return Ok(pObj.GetProductByCategory(cat));
        }

        [HttpGet]
        [Route("plist/instock")]
        public IActionResult GetProductByAvability(bool instock)
        {
            return Ok(pObj.GetProductByAvability(instock));
        }
        #endregion

        [HttpPost]
        [Route("plist/add")]
        public IActionResult AddNewProduct(Product newP)
        {
            return Created("",pObj.AddNewProduct(newP));
        }

        [HttpDelete]
        [Route("plist/delete")]
        public IActionResult DeleteProduct(int pid)
        {
            return Accepted(pObj.DeleteProduct(pid));
        }
        [HttpPut]
        [Route("plist/edit")]
        public IActionResult UpdateProduct(Product p)
        {
            return Accepted(pObj.EditProduct(p));
        }

    }
}
