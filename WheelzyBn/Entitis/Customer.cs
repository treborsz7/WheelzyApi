

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public partial class Customer
{

    [Column(Order = 1)]
    public long Id { get; set; }


    [StringLength(30)]
    public string Name { get; set; }
    public decimal Amount { get; set; }

    //[ForeignKey]
    public IList<Car> Cars { get; set; }
}

