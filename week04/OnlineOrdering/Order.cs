using System.Collections.Generic;

public class Order
{
    public Customer Customer { get; set; }
    private List<Product> Products { get; set; }

    public Order(Customer customer)
    {
        Customer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public string GetPackingLabel()
    {
        return $"Packing Label for {Customer.Name}";
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label for {Customer.Name}, {Customer.Address.Street}, {Customer.Address.City}, {Customer.Address.State}, {Customer.Address.Country}";
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var product in Products)
        {
            total += product.Price * product.Quantity;
        }
        return total;
    }
}