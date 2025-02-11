using Microsoft.AspNetCore.Mvc;
using CarWebApplication.Models;
using CarWebApplication.Services;
using Microsoft.AspNetCore.Authorization;

namespace CarWebApplication.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("[controller]")]
        public ActionResult<IEnumerable<Car>> SendCars()
        {
            return Ok(CarsDataBase.GetCars());
        }

        [HttpGet]
        [Authorize]
        [Route("[controller]/LastInsert")]
        public ActionResult<IEnumerable<Car>> SendLastCar()
        {
            Car? car = CarsDataBase.LastCar();
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpGet]
        [Authorize]
        [Route("[controller]/FindById")]
        public ActionResult<Car> FindById([FromQuery] int CarId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid Id" }); 
            }

            Car? car = CarsDataBase.FindById(CarId);
            if (car == null)
            {
                return NotFound(new { Message = "Car not found" });
            }

            return Ok(car);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[controller]/AddCar")]
        public IActionResult AddCar([FromBody] CreateCar car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Car");
            }

            int newCarId = CarsDataBase.AddCar(car);
            
            return CreatedAtAction(nameof(FindById), new { Id = newCarId }, car);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[controller]/DeleteCar")]
        public IActionResult DeleteCar([FromQuery] int CarId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid Id" });
            }

            bool Isdeleted = CarsDataBase.DeleteCar(CarId);
            if (!Isdeleted)
            {
                return NotFound(new { Message = "Car not found" });
            }
            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[controller]/UpdateCar")]
        public IActionResult UpdateCar([FromQuery] int CarId, [FromBody] CreateCar car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid Data" });
            }
            bool IsUpdated = CarsDataBase.UpdateCar(CarId, car);
            if (!IsUpdated)
            {
                return NotFound(new { Message = "Car not found" });
            }
            return NoContent();
        }
    }
}
