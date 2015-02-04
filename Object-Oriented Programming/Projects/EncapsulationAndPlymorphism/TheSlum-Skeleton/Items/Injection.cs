namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        const int healthEffect = 200;
        const int defenseEffect = 0;
        const int attackEffect = 0;
        const int timeout = 3;
        const bool hasTimedout = false;

        public Injection(string id)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = timeout;
            this.Countdown = timeout;
            this.HasTimedOut = hasTimedout;
        }
    }
}
