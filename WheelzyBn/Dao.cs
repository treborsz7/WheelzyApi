using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using WheelzyBn;

public class Dao
{
    internal Offer CreateNewOffer(Offer offer)
    {

        using (var db = new WheelzyEntities())
        {

            db.Offers.Add(offer);
            db.Buyers.FirstOrDefault(x => x.Id == offer.Buyer_id).Amount -= offer.Price;
            db.SaveChanges();
        }
        return offer;
    }

    internal Offer FindOffertById(long id)
    {
        var offer = new Offer();
        using (var db = new WheelzyEntities())
        {
            offer = db.Offers.FirstOrDefault(x => x.Id == offer.Id);

        }
        return offer;
    }

    internal Offer AceptBuyeroffer(Offer offer)
    {
        using (var db = new WheelzyEntities())
        {
            //offer = db.Offers.First(x => x.Id == offer.Id);
            var otherOffers = GetOfferByCar(offer.Car_id.Value);

            foreach (var otherOffer in otherOffers)
            {
                if (otherOffer.Id != offer.Id)
                {
                    otherOffer.Buyer.Amount += otherOffer.Price;
                    db.Entry(otherOffer).State = EntityState.Modified;
                }

            }


            db.Customers.First(x => x.Id == offer.Car.Customer_id).Amount += offer.Price;

            offer.Acept();
            db.SaveChanges();
        }
        return offer;
    }



    internal List<Offer> GetBuyerOffersByBuyer(int buyerId)
    {
        var offers = new List<Offer>();
        using (var db = new WheelzyEntities())
        {
            offers = db.Offers
                .Include("Car")
                .Include("Buyer")
                .Where(x => x.Buyer_id == buyerId).ToList();


        }
        return offers;
    }

    internal List<Offer> GetOfferByCar(long id)
    {
        var offers = new List<Offer>();
        using (var db = new WheelzyEntities())
        {
            offers = db.Offers
                     .Include("Car")
                     .Include("Buyer")
                     .Where(x => x.Car_id == id).ToList();
        }
        return offers;
    }

    internal Buyer CreateNewBuyer(Buyer buyer)
    {
        using (var db = new WheelzyEntities())
        {
            db.Buyers.Add(buyer);
            db.SaveChanges();
        }
        return buyer;
    }

    internal Buyer GetBuyerById(long? buyer_id)
    {
        var buyer = new Buyer();
        using (var db = new WheelzyEntities())
        {
            buyer = db.Buyers.FirstOrDefault(x => x.Id == buyer_id);

        }
        return buyer;
    }
    internal Car CreateNewCar(Car car)
    {

        using (var db = new WheelzyEntities())
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
        return car;
    }


    internal Car AcepteCar(Car car)
    {

        using (var db = new WheelzyEntities())
        {

            //db.State_Chages.Add(car.History.Last());
            db.Entry(car).State = EntityState.Modified;
            db.State_Chages.Add(car.History.Last());
            db.SaveChanges();
        }
        return car;
    }

    internal Car GetCarById(long carId)
    {
        var car = new Car();
        using (var db = new WheelzyEntities())
        {
            car = db.Cars.Include("History").FirstOrDefault(x => x.Id == carId);

        }
        return car;
    }

    internal List<Car> GetActiveCars()
    {
        var cars = new List<Car>();
        using (var db = new WheelzyEntities())
        {
            cars = db.Cars.Include("State")
                     .Include("Buyer")
                     .Include("Customer")
                     .Include("Offers")
                     .Where(x => x.State_id == (int)state.Accepted)
                     .ToList();
        }
        return cars;
    }
    internal List<Car> GetCarByZipCode(string zipCode)
    {
        var cars = new List<Car>();
        using (var db = new WheelzyEntities())
        {
            cars = db.Cars.Include("State")
                     .Include("Buyer")
                     .Include("Customer")
                     .Include("Offers")
                     .Where(x => x.Zip_code == zipCode)
                     .ToList();
        }
        return cars;
    }

    internal List<Car> GetCarByCostumer(int customerId)
    {
        var cars = new List<Car>();
        using (var db = new WheelzyEntities())
        {
            cars = db.Cars.Include("State")
                     .Include("Buyer")
                     .Include("Customer")
                     .Include("Offers")
                     .Where(x => x.Customer.Id == customerId)
                     .ToList();
        }
        return cars;
    }

    internal User GetUser(string userName, string password)
    {
        var curentUser = new User();
        using (var db = new WheelzyEntities())
        {
            curentUser = db.Users.FirstOrDefault(
                x => x.Username == userName &&
                x.Password == password);
        }
        return curentUser;
    }



    internal Customer CreateNewCustomer(Customer customer)
    {

        using (var db = new WheelzyEntities())
        {

            db.Customers.Add(customer);
            db.SaveChanges();
        }
        return customer;
    }


    //public class Invoice
    //{
    //    public long? CustomerId;
    //    public decimal Total;
    //}

    //public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
    //{
    //    using (var db = new WheelzyEntities())
    //    {
    //        var customerIds = invoices.Select(i => i.CustomerId).Distinct().ToList();
    //        var customers = db.Customers.Where(c => customerIds.Contains(c.Id)).ToList();

    //        foreach (var invoice in invoices)
    //        {

    //            var customer = db.Customers.SingleOrDefault(c => c.Id == invoice.CustomerId.Value);
    //            if(customer != null)
    //            {
    //                customer.Amount -= invoice.Total;
    //            }
    //        }

    //        db.SaveChanges();
    //    }
    //}
}


