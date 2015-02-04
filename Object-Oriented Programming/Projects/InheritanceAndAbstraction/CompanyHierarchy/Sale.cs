using System;


public class Sale : ISale
{
    private string productName;
    private decimal price;
    
    public Sale(string productName, DateTime date, decimal price)
    {
        this.ProductName = productName;
        this.Date = date;
        this.Price = price;
    }

    public string ProductName
    {
        get
        {
            return this.productName;
        }
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Product name is mandatory");
            }
            this.productName = value;
        }
    }
    public DateTime Date { get; set; }
    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Price can't be less than 0");
            this.price = value;
        }
    }
    public override string ToString()
    {
        string result = "Product name: " + this.ProductName + "\nDate: " + this.Date + "\nPrice: " + this.Price;
        return result;
    }
}

