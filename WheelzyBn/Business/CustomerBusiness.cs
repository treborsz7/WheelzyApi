using System;

public class CustomerBusiness
{
    public Customer CreateCustomer(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("name is required");

        Customer customer = new Customer() {Name = name };
            return new Dao().CreateNewCustomer(customer);
  
    }
}

