using System.Collections.Generic;
using System.Linq;

public class Order
{
    public Customer Customer { get; }
    private List<Product> products = new List<Product>();

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", products.Select(p => $"{p.Name} - {p.Id}"));
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }

    public double CalculateTotalCost()
    {
        double subtotal = products.Sum(p => p.Price * p.Quantity);
        double shipping = Customer.Address.IsInUSA() ? 5.0 : 35.0;
        return subtotal + shipping;
    }
}
