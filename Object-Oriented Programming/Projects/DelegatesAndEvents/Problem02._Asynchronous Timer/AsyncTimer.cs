using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


class AsyncTimer
{
    private Action f;
    private int ticks;
    private double t;
    private int counter;
    private Timer aTimer;

    public Action F
    {
        get
        {
            return this.f;
        }
        set
        {
            this.f = value;
        }
    }
    public int Ticks
    {
        get
        {
            return this.ticks;
        }
        set
        {
            if(value<0) throw new ArgumentOutOfRangeException("Ticks can't be less than 0");
            this.ticks = value;
        }
    }
    public double T
    {
        get
        {
            return this.t;
        }
        set
        {
            if(value<0) throw new ArgumentOutOfRangeException("Miliseconds can't be less than 0");
            this.t= value;
        }
    }
    public AsyncTimer(Action f, int ticks, double t)
    {
        this.F = f;
        this.Ticks = ticks;
        this.T = t;
        this.counter = ticks;
        this.aTimer = new System.Timers.Timer(this.t);
    }
    public void Run()
    {

        
        aTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
        
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
       
        
            
        
      
    }
    private void OnTimeEvent(object source, ElapsedEventArgs e)
    {
        this.F();
        if(this.counter<=1)
        {
            aTimer.AutoReset = false;
            aTimer.Enabled = false;
        }
        this.counter--;

    }

}

