using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coureservices.Data;

namespace coureservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
       
        private readonly ILogger<HomeController> _logger;
        private IServices Repo;

        public HomeController(ILogger<HomeController> logger, IServices _repo)
        {
            _logger = logger;
            this.Repo = _repo;
        }

        [HttpGet]
        [Route("getcountryDetails/{phone}")]
        public async Task<IActionResult>  GetCountry( string phone)
        {

             string countryCode =   phone.Substring(0, 3);

            var c_code =  await Repo.FindCountrycode(countryCode);

            if (c_code == null) { return NotFound( new { message = " Country Code Not Found" }); }
            else
            {

                var res =  await Repo.GetCotuntry(countryCode, phone);



                return Ok(res);

            }
        }
      
    }
}
