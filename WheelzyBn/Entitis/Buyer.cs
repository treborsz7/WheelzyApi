

using System.Collections.Generic;

public partial class Buyer
{

    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Amount { get; set; }
    public List<Offer> Offers { get; set; }

    public IList<Car> Cars { get; set; }

}

