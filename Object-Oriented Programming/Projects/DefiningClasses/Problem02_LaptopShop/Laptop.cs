using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Laptop
{
    string model = null;
    string manufacturer = null;
    string processor = null;
    string ram = null;
    string graphicsCard = null;
    string hdd = null;
    string screen = null;
    Battery battery = null;
    string price = null;
    float temp;
    string tempString;

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid model");
            this.model = value;
        }
    }
    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.manufacturer = null;
            this.manufacturer = value;
        }
    }
    public string Processor
    {
        get
        {
            return this.processor;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.manufacturer = null;
            this.processor = value;
        }
    }
    public string Ram
    {
        get
        {
            return this.ram;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.ram = null;
            else
            {
                bool isNumber = float.TryParse(value, out temp);
                if (isNumber)
                {
                    if (temp < 0) throw new ArgumentException("RAM can't be negative");
                    else
                    {
                        tempString = Convert.ToString(temp);
                        tempString += " GB";
                        this.ram = tempString;
                    }
                }
                else
                {
                    throw new ArgumentException("RAM has invalid value");
                }
            }

        }

    }
    public string GraphicsCard
    {
        get
        {
            return this.graphicsCard;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.graphicsCard = null;
            this.graphicsCard = value;
        }
    }
    public string Hdd
    {
        get
        {
            return this.hdd;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.hdd = null;
            this.hdd = value;
        }
    }
    public string Screen
    {
        get
        {
            return this.screen;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.screen = null;
            this.screen = value;
        }
    }
    public Battery Battery
    {
        get
        {
            return this.battery;
        }
        set
        {
            this.battery = value;
        }
    }
    public string Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid price");
            else
            {
                bool isNumber = float.TryParse(value, out temp);
                if (isNumber)
                {
                    if (temp < 0) throw new ArgumentException("Price can't be negative");
                    else
                    {
                        tempString = Convert.ToString(temp);
                        tempString += " leva";
                        this.price = tempString;
                    }
                }
                else
                {
                    throw new ArgumentException("Price has invalid value");
                }
            }
        }
    }

    public Laptop(string model, string price, string manufacturer = null, string processor = null, string ram = null, string graphicsCard = null, string hdd = null, string screen = null, Battery battery = null)
    {
        this.Model = model;
        this.Price = price;
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.Screen = screen;
        this.Battery = battery;
    }

    public override string ToString()
    {
        string output = "";
        
        if(!string.IsNullOrEmpty(this.model))
        {
            output += "Model: " + this.model + "\n";
        }
        if(!string.IsNullOrEmpty(this.manufacturer))
        {
            output += "Manufacturer: " + this.manufacturer + "\n";
        }
        if (!string.IsNullOrEmpty(this.processor))
        {
            output += "Processor: " + this.processor + "\n";
        }
        if (!string.IsNullOrEmpty(this.ram))
        {
            output += "RAM: " + this.ram + "\n";
        }
        if (!string.IsNullOrEmpty(this.graphicsCard))
        {
            output += "Graphics Card: " + this.graphicsCard + "\n";
        }
        if (!string.IsNullOrEmpty(this.hdd))
        {
            output += "HDD: " + this.hdd + "\n";
        }
        if (!string.IsNullOrEmpty(this.screen))
        {
            output += "Screen: " + this.screen + "\n";
        }
        if (!(this.battery==null))
        {
            tempString = this.battery.ToString();
            if (!string.IsNullOrEmpty(tempString))
            {
                output += tempString;
            }
        }
        if (!string.IsNullOrEmpty(this.price))
        {
            output += "Price: " + this.price + "\n";
        }
        return string.Format(output);
    }
}

