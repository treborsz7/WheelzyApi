

using System;


public partial class Offer
{
    public Offer() { }
    public Offer(OfferRequest offer)
    {
        Id = offer.Id;
        Buyer_id = offer.Buyer_id;
        Car_id = offer.Car_id;
        Price = offer.Price;

        if (Id <= 0)
        {
            Date = DateTime.Now;
        }
    }

    public long Id { get; set; }

    public long? Buyer_id { get; set; }

    public Buyer Buyer { get; set; }

    public long? Car_id { get; set; }

    public Car Car { get; set; }

    public decimal Price { get; set; }

    public DateTime Date { get; set; }

    public bool Acepted { get; set; }

    public void Rejected()
    {
        Buyer.Amount += Price;
    }

    public void Acept()
    {

        Car.SetBought(this);
        Acepted = true;


    }

}
