public class Product
{
    public string Name { get; }
    public string Id { get; }
    public double Price { get; }
    public int Quantity { get; }

    public Product(string name, string id, double price, int quantity)
    {
        Name = name;
        Id = id;
        Price = price;
        Quantity = quantity;
    }
}
