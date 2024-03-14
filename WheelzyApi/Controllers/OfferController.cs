using Microsoft.AspNetCore.Mvc;

namespace Wheelzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        [Route("CreateBuyerOffer")]
        [HttpPost]
        public Offer CreateBuyerOffer(OfferRequest offer)
        {
            return new OfferBusiness().CreateBuyerOffer(offer);

        }

        [Route("GetBuyerOffersByBuyer")]
        [HttpGet]
        public List<Offer> GetBuyerOffersByBuyer(int buyerId)
        {
            
            return new OfferBusiness().GetBuyerOffersByBuyer(buyerId);

        }
        [Route("GetBuyerOffersByCar")]
        [HttpGet]
        public List<Offer> GetBuyerOffersByCar(int id)
        {
            
            return new OfferBusiness().GetOffersByCar(id);

        }


        [Route("AcceptBuyerOffer")]
        [HttpPut]

        public Offer AcceptBuyerOffer(long offerId)
        {

            return new OfferBusiness().AcceptBuyerOffer(offerId);

        }

      

    }
}
