using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wheelzy.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        [Route("CreateNewCar")]
        [HttpPost]
        public Car Post(CarRequest car)
        {
            return new CarBusiness().CreateCar(car);

        }

        [Route("GetActiveCars")]
        [HttpGet]
       
        public IEnumerable<Car> GetActiveCars()
        {
            
            List<Car> cars = new CarBusiness().GetActiveCars();
            return cars;

        }

        [Route("GetCarByCostumer")]
        [HttpGet]
        public IEnumerable<Car> GetCarByCostumer(int customerId)
        {

            List<Car> cars = new CarBusiness().GetCarByCustumer(customerId);
            return cars;

        }

        [Route("GetCarByZipCode")]
        [HttpGet]
        public IEnumerable<Car> GetCarByZipCode(string zipCode)
        {

            List<Car> cars = new CarBusiness().GetCarByZipCode(zipCode);
            return cars;

        }

        [Route("Acep")]
        [HttpPut]
        [Authorize]
        public Car Acep(long carId)
        {
            
            string userName = User.Claims.First(x => x.Type == "name").Value;

            return new CarBusiness().ChangeCarStateTo(carId, userName);

        }

        
    }
}
