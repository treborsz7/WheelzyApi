using Entitis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;

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
