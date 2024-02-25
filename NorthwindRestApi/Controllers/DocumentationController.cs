using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;


namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        NorthwindOriginalContext db = new NorthwindOriginalContext();


        [HttpGet]
        public ActionResult GetAllDocumentation()
        {
            try
            {
                var documentation = db.Customers.ToList();
                return Ok(documentation);
            }
            catch (Exception ex)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + ex.InnerException);
            }
        }

        
    }
}



