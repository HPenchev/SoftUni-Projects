using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Battery
{
    private string batteryInfo;
    private string batteryLife;
    private float temp;
    private string tempString;

    public string BatteryInfo
    {
        get
        {
            return this.batteryInfo;
        }
        set
        {
           
            this.batteryInfo = value;

        }

    }
    public string BatteryLife
    {
        get
        {
            return this.batteryLife;
        }
        set
        {
            if (string.IsNullOrEmpty(value)) this.batteryLife = null;
            else
            {
                bool isNumber = float.TryParse(value, out temp);
                if (isNumber)
                {
                    if (temp < 0) throw new ArgumentException("Battery life can't be negative");
                    else
                    {
                        tempString = Convert.ToString(temp);
                        tempString += " hours";
                        this.batteryLife = tempString;
                    }
                }
                else
                {
                    throw new ArgumentException("Battery life has invalid value");
                }
            }

        }

    }
    public Battery(string batteryInfo = null, string batteryLife = null)
    {
        this.BatteryInfo = batteryInfo;
        this.BatteryLife = batteryLife;
    }
    public override string ToString()
    {
        string output = "";
        if (!string.IsNullOrEmpty(this.batteryInfo))
        {
            output += "Battery:" + this.batteryInfo + "\n";
        }
        if (!string.IsNullOrEmpty(this.batteryLife))
        {
            output += "Battery Life:" + this.batteryLife + "\n";
        }
        return string.Format(output);
    }
}

