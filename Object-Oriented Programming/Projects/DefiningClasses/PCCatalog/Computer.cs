using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Computer
{
    private string name;
    private List<Component> components;
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
                throw new ArgumentException("Computer name is mandatory");
            }
            else
            {
                this.name = value;
            }
        }
    }
    public List<Component> Components
    {
        get
        {
            return this.components;
        }
        set
        {
            if (value == null) throw new ArgumentException("Components are mandatory");
            else this.components = value;
        }
    }
    public float Price
    {
        get
        {
            return this.price;
        }
        private set
        {
            this.price = value;
        }
    }

    public Computer(string name, List<Component> components)
    {
        this.Name = name;
        this.Components = components;
        this.Price = CalcPrice(components);
    }
    private float CalcPrice(List<Component> components)
    {
        float totalPrice = 0;
        foreach (Component component in components)
        {
            totalPrice += component.Price;
        }

        return totalPrice;
    }
    public override string ToString()
    {
        string output = "";
        output += "Computer name: " + this.name + "\n";
        foreach(Component component in this.components)
        {
            string temp = component.ToString();
            output += temp + "\n";
        }
        string priceString = string.Format("{0:C}", this.price, CultureInfo.CreateSpecificCulture("bg-BG"));
        output += priceString + "\n";
        return string.Format(output);
    }

}