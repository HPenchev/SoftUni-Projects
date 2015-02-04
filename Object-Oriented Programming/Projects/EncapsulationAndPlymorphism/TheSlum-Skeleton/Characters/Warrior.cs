using System;
using System.Collections.Generic;
using TheSlum.Interfaces;
using System.Linq;

namespace TheSlum.Characters
{
    class Warrior : Character, IAttack
    {
        const int defaultHealthPoints = 200;
        const int defaultDefencePoints = 100;
        const int defaultRangePoints = 2;
        const int defaultAtackPoints = 150;

        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, defaultHealthPoints, defaultDefencePoints, team, defaultRangePoints)
        {
            this.AttackPoints = defaultAtackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targets =
            from target in targetsList
            where target.IsAlive
            where target.Team != this.Team
            select target;

            if (!targets.Any())
            {
                return null;
            }
            else
            {
                return targets.First();
            }
        }

        public override void AddToInventory(Item item)
        {
            Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += " Atack: " + this.AttackPoints;
            return output;
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }
    }
}
