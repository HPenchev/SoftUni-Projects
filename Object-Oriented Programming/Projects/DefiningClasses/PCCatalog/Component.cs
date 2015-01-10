using System;
using System.Globalization;



class Component
{
    private string name;
    private string details;
    private float price;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Component name can't be empty");
            }
            else
            {
                this.name = value;
            }
        }

    }
    public string Details
    {
        get
        {
            return this.details;
        }
        set
        {

            this.details = value;

        }
    }
    public float Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value==null) throw new ArgumentException("Price is mandatory");
            else if (value < 0) throw new ArgumentException("Price can not be negative");
            else this.price = value;
        }
    }
    public Component(string name, float price, string details = null)
    {
        this.Name = name;
        this.Price = price;
        this.Details = details;
    }
    public override string ToString()
    {
        string output = "";
        output += "     Component name: " + this.name + "\n";        
        if (!string.IsNullOrEmpty(this.details))
        {
            output += "     Component details:" + this.details + "\n";
        }
        string priceString = string.Format("{0:C}", this.price, CultureInfo.CreateSpecificCulture("bg-BG"));
        output += "     Component price: " +  priceString + "\n";
        return string.Format(output);
    }
}

