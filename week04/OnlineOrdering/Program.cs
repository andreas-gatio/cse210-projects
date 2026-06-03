using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Boise", "ID", "USA");
        Customer customer1 = new Customer("Sarah Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P-1001", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "P-1042", 8.50, 3));
        order1.AddProduct(new Product("Notebook", "P-2100", 4.25, 5));

        Address address2 = new Address("47 Vesterbrogade", "Copenhagen", "Capital Region", "Denmark");
        Customer customer2 = new Customer("Mikkel Sorensen", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "P-3300", 89.00, 1));
        order2.AddProduct(new Product("Desk Lamp", "P-3315", 32.75, 2));

        Order[] orders = new Order[] { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}
