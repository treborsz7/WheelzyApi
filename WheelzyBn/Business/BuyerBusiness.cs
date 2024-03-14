
public class BuyerBusiness
{
    public Buyer CreateBuyer(string name, decimal amount)
    {
        new Validations().BuyerValidations(name, amount);

        var buyer = new Buyer() { Name = name, Amount = amount };
        return new Dao().CreateNewBuyer(buyer);


    }
}


