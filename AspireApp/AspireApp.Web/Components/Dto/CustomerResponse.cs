using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Customer 
{ 
    public string CustomerID { get; set; } 
    public string FirstName { get; set; } 
    public DateTime Birth { get; set; } 
    public string Document { get; set; } 
}

public class CustomersData 
{ 
    public List<Customer> Items { get; set; } 
}

public class Data 
{ 
    public CustomersData Customers { get; set; } 
}

