using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Shop's owner input --->");

        Console.WriteLine("Enter shop name: ");
        string inputShopName = Console.ReadLine();

        Console.WriteLine("Enter product name: ");
        string productName = Console.ReadLine();

        Console.WriteLine("Enter product price: ");
        int productPrice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter product amount: ");
        int productAmount = int.Parse(Console.ReadLine());

        Console.WriteLine("Buyer's input --->");

        Console.WriteLine("Enter product name: ");
        string nameToCheck = Console.ReadLine();

        Console.WriteLine("Enter product quantity (Available " + productAmount + "): ");
        int productQuantity = int.Parse(Console.ReadLine());

        if (productName == nameToCheck && productQuantity <= productAmount)
        {
            Console.WriteLine("Enter buyer name: ");
            string buyerName = Console.ReadLine();

            Console.WriteLine("Enter buyer email: ");
            string buyerEmail = Console.ReadLine();

            Console.WriteLine("Enter buyer address: ");
            string buyerAddress = Console.ReadLine();

            Shop shop = new Shop(inputShopName);
            Product product = new Product(productName, productAmount, productPrice);
            Buyer buyer = new Buyer(buyerName, buyerEmail, buyerAddress);

            Receipt receipt = new Receipt(shop, product, buyer, productQuantity);
            receipt.PrintReceipt();
        }
        else
        {
            Console.WriteLine("No product called " + nameToCheck + " or there is no needed amount");
        }
    }
}

class Shop
{
    public string Name { get; private set; }

    public Shop(string shopName)
    {
        Name = shopName;
    }
}

class Product
{
    public string Name { get; private set; }
    public int Available { get; private set; }
    public int Price { get; private set; }

    public Product(string name, int amount, int price)
    {
        Name = name;
        Available = amount;
        Price = price;
    }
}

class Buyer
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }

    public Buyer(string name, string email, string address)
    {
        Name = name;
        Email = email;
        Address = address;
    }
}

class Receipt
{
    public Shop Shop { get; private set; }
    public Product Product { get; private set; }
    public Buyer Buyer { get; private set; }
    public int Quantity { get; private set; }

    public Receipt(Shop shop, Product product, Buyer buyer, int quantity)
    {
        Shop = shop;
        Product = product;
        Buyer = buyer;
        Quantity = quantity;
    }

    public void PrintReceipt()
    {
        int totalPrice = Quantity * Product.Price;
        Console.WriteLine("\n\n\n     RECEIPT");
        Console.WriteLine($"Shop: {Shop.Name}");
        Console.WriteLine($"Buyer: {Buyer.Name}");
        Console.WriteLine($"Email: {Buyer.Email}");
        Console.WriteLine($"Address: {Buyer.Address}");
        Console.WriteLine($"Product: {Product.Name}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Price per unit: ${Product.Price}");
        Console.WriteLine($"Total Price: ${totalPrice}");
    }
}
