
using System.Collections.Generic;

public class Car
{
    public long? Id { get; set; }

    public long? Customer_id { get; set; }
    public Customer Customer { get; set; }
    public int Year { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public string Sub_model { get; set; }

    public string Zip_code { get; set; }

    public int? State_id { get; set; }
    public State State { get; set; }

    public ICollection<Offer> Offers { get; set; }


    public long? Buyer_id { get; set; }
    public Buyer Buyer { get; set; }

    public List<State_Chages> History { get; set; }

    public Car() { }
    public Car(CarRequest carRequest)
    {
        Id = carRequest.Id;
        Customer_id = carRequest.Customer_id;
        Year = carRequest.Year;
        Make = carRequest.Make;
        Model = carRequest.Model;
        Sub_model = carRequest.Sub_model;
        Zip_code = carRequest.Zip_code;
        History = new List<State_Chages>();
        if (carRequest.Id == null || carRequest.Id <= 0)
        {
            SetStaus(state.PendingAcceptance, "Owner");
        }


    }



    internal void SetBought(Offer offer)
    {
        Buyer_id = offer.Buyer_id;
        SetStaus(state.Bought, "Owner");
    }


    public void SetRejected(string userName)
    {

        SetStaus(state.Rejected, userName);

    }

    public void CarSetPickUp(string userName)
    {
        //var offer = Offers.First(x => x.Status.Id ==  (int)status.Accepted);
        SetStaus(state.PickedUp, userName);
        //Customer.Amount += offer.Price;
    }

    internal void SetAcepted(string userName)
    {
        SetStaus(state.Accepted, userName);
    }

    private void SetStaus(state est, string userName)
    {
        var state = Commons.Instance.GetStatus(est);

        State_id = state.Id;
        if (History == null)
            this.History = new List<State_Chages>();

        this.History.Add(new State_Chages(this, state, userName));
    }


}
