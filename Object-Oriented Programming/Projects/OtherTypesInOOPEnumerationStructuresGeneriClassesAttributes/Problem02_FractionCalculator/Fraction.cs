using System;



class Fraction
{
    private long numerator;
    private long denominator;
    public long Numerator
    {
        get
        {
            return this.numerator;
        }
        set
        {
            this.numerator = value;
        }
    }
    public long Denominator
    {
        get
        {
            return this.denominator;
        }
        set
        {
            if (value == 0) throw new DivideByZeroException("Denominator can't be 0");
            this.denominator = value;
        }
    }
    public Fraction(long numerator, long denominator)
    {
         for (long i = Math.Min(Math.Abs(numerator), Math.Abs(denominator)); i > 0; i--)
        {
            if(numerator%i==0&&denominator%i==0)
            {
                numerator = numerator / i;
                denominator = denominator / i;
                break;
            }
            
        }
        this.Numerator = numerator;
        this.Denominator = denominator;
    }
   
    public static Fraction operator +(Fraction Fraction1, Fraction Fraction2)
    {
        long numerator = Fraction1.Numerator * Fraction2.Denominator + Fraction2.Numerator*Fraction1.Denominator;
        long denominator = Fraction1.Denominator * Fraction2.Denominator;
        Fraction fraction = new Fraction(numerator, denominator);
        return fraction;
    }
    public static Fraction operator -(Fraction Fraction1, Fraction Fraction2)
    {
        long numerator = Fraction1.Numerator * Fraction2.Denominator - Fraction2.Numerator*Fraction1.Denominator;
        long denominator = Fraction1.Denominator * Fraction2.Denominator;
        Fraction fraction = new Fraction(numerator, denominator);
        return fraction;
    }
    public override string ToString()
    {
        
        string output = ((double)this.Numerator/(double)this.Denominator).ToString();
        return string.Format(output);
    }
}

