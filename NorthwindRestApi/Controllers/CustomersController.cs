using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindRestApi.Models;

namespace NorthwindRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //alustetaan tietokantayhteys
        NorthwindOriginalContext db = new NorthwindOriginalContext();

        //Metodi joka hakee kaikki asiakkaat
        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            try
            {
                var asiakkaat = db.Customers.ToList();
                return Ok(asiakkaat);
            }
            catch (Exception ex) 
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + ex.InnerException);            
            }
        }

        //Metodi joka hakee asiakkaan
        [HttpGet("{id}")]
        public ActionResult GetOneCustomerById(string id)
        {
            try
            {

                var asiakas = db.Customers.Find();
                if (asiakas != null)
                {
                    return Ok(asiakas);
                }
                else
                {
                    return BadRequest($"Asiakasta id:llä  {id}  ei löydy");
                }
            }
            catch (Exception e) 
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e);
            }
        }

        [HttpPost]
        public ActionResult AddNew([FromBody] Customer cust)
        {
            try 
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return Ok("Lisättiin uusi asiakas" + cust.CompanyName);

            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää:" + e.InnerException);
            }
        }
    }
}
