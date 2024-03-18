
using System;

public class Validations
{

    public void CarValidations(CarRequest car)
    {

        if (string.IsNullOrEmpty(car.Model))
            throw new ArgumentNullException("car model is required");

        if (string.IsNullOrEmpty(car.Make))
            throw new ArgumentNullException("car maker is requided");

        if (car.Year <= 1880 || car.Year > DateTime.Now.Year)
            throw new ArgumentNullException("car year is not valid ");

        if (car.Customer_id <= 0)
            throw new ArgumentNullException("costumer  is requided");

    }

    public void BuyerValidations(string name, decimal amount)
    {

        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("buyer name is required");

        if (amount <= 0)
            throw new ArgumentNullException("buyer Amount is required");

    }

    public void BuyerOfferValidations(OfferRequest offer)
    {
        if (offer.Buyer_id <= 0)
            throw new ArgumentNullException("Buyer is not valid");

        if (offer.Car_id <= 0)
            throw new ArgumentNullException("Car is not valid");


        if (offer.Price <= 0)
            throw new ArgumentException("Amount is not valid");
    }
}

