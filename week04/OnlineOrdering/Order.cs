using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0.0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        total += GetShippingCost();
        return total;
    }

    public double GetShippingCost()
    {
        if (_customer.LivesInUSA())
        {
            return 5.0;
        }
        return 35.0;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"  {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"  {_customer.GetName()}\n";
        string[] addressLines = _customer.GetAddress().GetFullAddress().Split("\n");
        foreach (string line in addressLines)
        {
            label += $"  {line}\n";
        }
        return label.TrimEnd();
    }
}
