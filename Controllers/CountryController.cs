using CountryServiceDinsdag.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryServiceDinsdag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo)
        {
            this.repo = repo;
        }
        //[HttpGet]
        //[HttpHead]
        //public IEnumerable<Country> Get()
        //{
        //    return repo.GetAll();
        //}
        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public ActionResult<Country> Get(int id)
        {
            try
            {
                return repo.GetCountry(id);
            }
            catch(CountryException ex)
            {                
                return NotFound(ex.Message);
            }
        }
        //[HttpGet]
        //public IEnumerable<Country> Getall([FromQuery] string continent)
        //{
        //    if (!string.IsNullOrWhiteSpace(continent))
        //    {
        //        return repo.GetAll(continent);
        //    }
        //    return repo.GetAll();
        //}
        [HttpGet]
        public IEnumerable<Country> Getall([FromQuery] string continent, [FromQuery] string? capital)
        {
            if (!string.IsNullOrWhiteSpace(continent))
            {
                if (!string.IsNullOrWhiteSpace(capital))
                    return repo.GetAll(continent, capital);
                else
                    return repo.GetAll(continent);
            }
            return repo.GetAll();
        }
    }
}
