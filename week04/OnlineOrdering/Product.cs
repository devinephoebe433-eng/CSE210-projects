public class Product
{
    public string Name { get; set; }
    public string Code { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string code, double price, int quantity)
    {
        Name = name;
        Code = code;
        Price = price;
        Quantity = quantity;
    }
}