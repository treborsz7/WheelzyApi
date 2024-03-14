using Entitis;
using Microsoft.AspNetCore.Mvc;

namespace Wheelzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpPost(Name = "CreateCustomer")]
        public Customer Post(string name)
        {
          
            return new CustomerBusiness().CreateCustomer(name);

        }
    }
}
