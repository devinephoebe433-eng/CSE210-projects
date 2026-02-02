using System;
using System.Collections.Generic;

class Program
{
    public Program()
    {
    }

    static void Main()
    {
        // Order 1: USA
        Address addr1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "L404", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M202", 25.50, 2));

        // Order 2: International
        Address addr2 = new Address("456 Sakura Rd", "Tokyo", "Tokyo", "Japan");
        Customer cust2 = new Customer("Akira Tanaka", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Keyboard", "K303", 75.00, 1));
        order2.AddProduct(new Product("Monitor", "MON9", 150.00, 2));

        // Display results
        List<Order> orders = new List<Order> { order1, order2 };
        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotal():0.00}");
            Console.WriteLine(new string('-', 30));
        }
    }
}
