using Microsoft.AspNetCore.Mvc;

namespace Wheelzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : Controller
    {
        [HttpPost(Name = "CreateBuyer")]
        public Buyer Post(string name, decimal amount)
        {
            
            return new BuyerBusiness().CreateBuyer(name, amount);

        }


    }
}
