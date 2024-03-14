

using System;
using System.Collections.Generic;

public class OfferBusiness
{

    public Offer CreateBuyerOffer(OfferRequest offerrequest)
    {

        new Validations().BuyerOfferValidations(offerrequest);

        var dao= new Dao();
        var buyer = dao.GetBuyerById(offerrequest.Buyer_id);

        if (buyer == null)
            throw new ArgumentException("Buyer is invalid");
        if(buyer.Amount < offerrequest.Price)
            throw new ArgumentException("Amount is invalid");

        var car = dao.GetCarById(offerrequest.Car_id);
        if (car == null)
            throw new ArgumentException("Car is invalid");
        if (car.State_id != (int)state.Accepted)
            throw new ArgumentException("Car is invalid");

        var offer = new Offer(offerrequest);
        
        return new Dao().CreateNewOffer(offer);

    }

    public List<Offer> GetBuyerOffersByBuyer(int buyerId)
    {
        if (buyerId <= 0)
            throw new ArgumentOutOfRangeException("Buyer id is not valid");

        return new Dao().GetBuyerOffersByBuyer(buyerId);

    }

    public List<Offer> GetOffersByCar(int carId)
    {
        if (carId <= 0)
            throw new ArgumentOutOfRangeException("Car id is not valid");

        return new Dao().GetOfferByCar(carId);

    }

    public Offer AcceptBuyerOffer(long offerId)
    {
        if (offerId <= 0)
            throw new ArgumentException("Ofer is invalid");
        var dao = new Dao();

        var offer = dao.FindOffertById(offerId);

        return dao.AceptBuyeroffer(offer);
    }
}

