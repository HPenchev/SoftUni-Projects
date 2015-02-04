namespace TheSlum.Items
{
    class Axe : Item
    {
        const int healthEffect = 0;
        const int defenseEffect = 0;
        const int attackEffect = 75;

        public Axe(string id)
            :base(id, healthEffect, defenseEffect, attackEffect )
        {

        }
    }
}