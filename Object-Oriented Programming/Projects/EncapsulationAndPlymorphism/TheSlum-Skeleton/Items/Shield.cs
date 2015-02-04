namespace TheSlum.Items
{
    class Shield : Item
    {
        const int healthEffect = 0;
        const int defenseEffect = 50;
        const int attackEffect = 0;

        public Shield(string id)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {

        }
    }
}