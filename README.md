1)
This is a demo NET API conected to SQL usin Entity Framework

*The fir  first  Step is innstall run the SQL scripts "DBCreator.sql"
    this will create the database and populate the tables Users and States
* the secon step is buil and run the aplication
* the next step is create Buyers, Customer and Cars


 the cars need aprobation 
 to complete this step is nesesari login as an admin
*login on http://localhost:5145/login or https://localhost:7253/login
using 
```http
curl --location 'https://localhost:7253/login' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'username=Admin' \
--data-urlencode 'password=Admin'
```

2)
If the data does not change frequently but is used frequently, I would save it in cache or on memory to improve performance and avoid excessive database lookups.

3)
```C#
public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
{
        
  var customerIds = invoices.Select(i => i.CustomerId).Distinct().ToList();
  var customers = dbContext.Customers.Where(c => customerIds.Contains(c.Id)).ToList();

  foreach (var invoice in invoices)
  {

     var customer = customers.SingleOrDefault(c => c.Id == invoice.CustomerId.Value);
     if(customer != null)
     {
         customer.Amount -= invoice.Total;
         dbContext.Entry(customer).State = EntityState.Modified
     }
  }

   db.SaveChanges(); 
}
```

With this change, only the query is made to search for all the customers and a save is made at the end of all

4)
```C#
public async Task<OrderDTO> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
{
    var query = dbContext.Orders.AsQueryable();

    if (dateFrom != DateTime.MinValue)
    {
        query = query.Where(o => o.OrderDate >= dateFrom);
    }

    if (dateTo != DateTime.MinValue)
    {
        query = query.Where(o => o.OrderDate <= dateTo);
    }

    if (customerIds != null && customerIds.Any())
    {
        query = query.Where(o => customerIds.Contains(o.CustomerId));
    }

    if (statusIds != null && statusIds.Any())
    {
        query = query.Where(o => statusIds.Contains(o.StatusId));
    }

    if (isActive.HasValue)
    {
        query = query.Where(o => o.IsActive == isActive);
    }

    var orders = await query.ToListAsync();

    
    var orderDTOs = orders.Select(o => new OrderDTO(0))).ToList();

    return orderDTOs;
}
```
5)
Steps to proceed with fixing the bug in changing status from "Accepted" to "Picked Up":

1) Understand the reported bug and reproduce it locally.
2) Analyze the code related to changing statuses and identify potential issues.
3) Write unit tests to cover the scenarios where the bug occurs.
4) Debug the code to find the root cause of the issue.
5) Implement the necessary code changes to fix the bug.
6) Test the fix locally to ensure the bug is resolved.
7) Push the changes to a feature branch in the repository.
8) Create a pull request (PR) describing the problem, solution, and testing approach.
9) Request code review from team members, especially from QA.
10) Address any feedback or comments from the code review.
11) Once approved, merge the PR into the main branch.
12) Build the main branch
13) Deploid 


