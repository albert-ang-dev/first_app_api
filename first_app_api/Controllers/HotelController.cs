using first_app_api.data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace first_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {


        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Hotel A", Address = "123 Main St", Rating = 4.5 },
            new Hotel { Id = 2, Name = "Hotel B", Address = "456 Main St", Rating = 8.5 },
        };

        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel>  Get(int id)
        {
            Hotel theHotel = hotels.FirstOrDefault(h => h.Id == id);
            if(theHotel == null)
            {
                return NotFound();
            }

            return Ok(theHotel);
        }

        // POST api/<HotelController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel userHotel)
        {
            if (hotels.Any(h => h.Id == userHotel.Id))
            {
                return BadRequest("A hotel with the same ID already exists.");
            };

            hotels.Add(userHotel);
            return CreatedAtAction(nameof(Get), new { id = userHotel.Id }, userHotel);
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
        {
            var existingHotel = hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel == null)
            {
                return NotFound("Hotel not found.");
            }

            existingHotel.Id = id;
            existingHotel.Name = updatedHotel.Name;
            existingHotel.Address = updatedHotel.Address;
            existingHotel.Rating = updatedHotel.Rating;

            return NoContent();
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotelToDelete = hotels.FirstOrDefault(h => h.Id == id);
            if (hotelToDelete == null)
            {
                return NotFound("Hotel not found.");
            }

            hotels.Remove(hotelToDelete);
            return Ok("Hotel deleted successfully.");
        }
    }
}
