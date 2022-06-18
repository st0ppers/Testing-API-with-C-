using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RapperController : ControllerBase
    {
        
        private static List<Rappers> RappersList = new List<Rappers>
        {
                new Rappers
                {
                    ID =  1,
                    Name = "J Cole" ,
                    Age = 37,
                    RealName = "Jermaine Lamarr Cole" ,
                    BirthPlace = "Frankfurt, West Germany"
                },
                new Rappers
                {
                    ID =  2,
                    Name = "Kendrick Lamar",
                    Age = 35,
                    RealName = "Kendrick Lamar Duckworth" ,
                    BirthPlace = "California, USA"
                }
        };


        [HttpGet]
        public async Task<ActionResult<List<Rappers>>> GetList()
        {
            //return status 200 
            //means everything went OK
            return  Ok(RappersList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Rappers>> Get(int id)
        {
            var rapper = RappersList.Find(r => r.ID == id);
            if (rapper == null)
            {
                return BadRequest("Rapper not found :(");
            }
            return Ok(rapper);
        }


        [HttpPost]
        public async Task<ActionResult<List<Rappers>>> Add(Rappers raper)
        {
            RappersList.Add(raper);
            return Ok(RappersList);
        }


        [HttpPut]
        public async Task<ActionResult<List<Rappers>>> Update(Rappers req)
        {
            var rapper = RappersList.Find(r => r.ID == req.ID);
            if (rapper == null)
            {
                return BadRequest("Rapper not found :(");
            }
            rapper.Name = req.Name;
            rapper.Age = req.Age;
            rapper.RealName = req.RealName;
            rapper.BirthPlace = req.BirthPlace;

            return Ok(RappersList);
        }


        [HttpDelete]
        public async Task<ActionResult<List<Rappers>>> Delete (int id)
        {
            var rapper = RappersList.Find(r => r.ID == id);
            if (rapper  == null)
            {
                return BadRequest("Rapper not found :(");
            }
            RappersList.Remove(rapper);
            return Ok(RappersList);
        }
    }
}
