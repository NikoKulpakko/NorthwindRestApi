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
        //perinteinen tapa
        //NorthwindOriginalContext db = new NorthwindOriginalContext();

        //Dependency injektion tapa
        private NorthwindOriginalContext db;

        public CustomersController(NorthwindOriginalContext dbparametri)
        {
            db = dbparametri;
        }



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

        //Asiakkaan poistaminen
        [HttpDelete("{id}")]
        public ActionResult Delete(string id) 
        {
            try
            {
                var asiakas = db.Customers.Find(id);

                if (asiakas != null)
                {// Jos idllä löytyy asiakas
                    db.Customers.Remove(asiakas);
                    db.SaveChanges();
                    return Ok("Asiakas" + asiakas.CompanyName + "Poistettiin");
                }
                return NotFound("Asiakasta id:llä " + id + " ei löytynyt ");
            }
            catch (Exception e){
                return BadRequest(e.InnerException);
            }
        }

        //Asiakkaan muokkaaminen
        [HttpPut("{id}")]
        public ActionResult EditCustomer(string id, [FromBody] Customer customer) 
        {
            var asiakas = db.Customers.Find(id);
            if (asiakas != null){

                asiakas.CompanyName = customer.CompanyName;
                asiakas.ContactName = customer.ContactName;
                asiakas.Address = customer.Address;
                asiakas.City = customer.City;
                asiakas.Region = customer.Region;
                asiakas.PostalCode = customer.PostalCode;
                asiakas.Country = customer.Country;
                asiakas.Phone = customer.Phone;
                asiakas.Fax = customer.Fax;

                db.SaveChanges();
                return Ok("Muokattu asiakastietoja" + asiakas.CompanyName);

            }

                return NotFound("Asiakasta ei löytynyt id:llä" + id);
        }

        //Hakee nimen osalla
        [HttpGet("Companyname/{cname}")]

        public ActionResult GetByName(string cname)
        {
            try
            {
                var cust = db.Customers.Where(c => c.CompanyName.Contains(cname));
                //var cust = from c in db.Customers where c.CompanyName.Contains(cname) select c;


                //var cust = db.Customers.Where(c => c.CompanyNAme == cname); 

                return Ok(cust);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        



    }
}
