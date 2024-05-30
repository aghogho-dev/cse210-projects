using System;
using System.Text;

namespace Foundation2.Assets;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void OrderProduct(Product product)
    {
        _products.Add(product);
    }

    public double TotalPrice()
    {
        return _products.Sum(product => product.TotalCost()) + ShippingCost();
    }

    public string PackingLabel()
    {
        StringBuilder label = new StringBuilder();

        _products.ForEach(p => label.Append($"\n\t{p.GetName()}-{p.GetProductID()}"));
        
        return label.ToString();
    }

    public string ShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().AddressString()}";
    }

    private double ShippingCost()
    {
        return (_customer.IsUSA()) ? (double)5 : (double)35;
    }






}