using System;

public enum Planet
{
    Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
}

    struct Location
    {
        private double latitude;
        private double longtitude;
        private Planet planet;
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }
        public double Longtitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }
        public Planet Planet
        {
            get
            {
                return this.planet;
            }
            set
            {
                this.planet = value;
            }
        }
        public Location(double latitude, double longtitude, Planet planet):this()
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.Planet = planet;
        }
        public override string ToString()
        {
            string output = this.Latitude + ", " + this.Longtitude + " - " + this.Planet;
            return string.Format(output);

        }
    }

