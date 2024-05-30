using System;

namespace Foundation2.Assets;

public class Product
{
    private string _name;
    private int _productID;
    private double _price = 0;
    private int _quantity = 0;

    public Product(string name, int productID, double price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    public double TotalCost()
    {
        if (_price <= 0 || _quantity <= 0) return 0;
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetProductID()
    {
        return _productID;
    }

    public void SetProductID(int productID)
    {
        _productID = productID;
    }

    public double GetPrice()
    {
        return _price;
    }

    public void SetPrice(double price)
    {
        _price = price;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

}