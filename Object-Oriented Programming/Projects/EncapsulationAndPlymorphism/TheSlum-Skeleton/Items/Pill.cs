namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        const int healthEffect = 0;
        const int defenseEffect = 0;
        const int attackEffect = 100;
        const int timeout = 1;
        const bool hasTimedout = false;

        public Pill(string id)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = timeout;
            this.Countdown = timeout;
            this.HasTimedOut = hasTimedout;
        }
    }
}
