using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Order 1 (USA)
        Address addr1 = new Address("123 Llama Lane", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Gaming Mouse", "M77", 45.99, 1));
        order1.AddProduct(new Product("Mechanical Keyboard", "K12", 89.00, 1));
        order1.AddProduct(new Product("USB-C Cable", "C09", 12.50, 2));

        // Create Order 2 (International)
        Address addr2 = new Address("456 Maple Blvd", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Jane Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Noise Cancelling Headphones", "H500", 199.99, 1));
        order2.AddProduct(new Product("Laptop Stand", "S22", 34.50, 1));

        // Display Results
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
        Console.WriteLine(new string('=', 30));
        Console.WriteLine();
    }
}