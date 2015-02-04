using System;
using System.Collections.Generic;
using TheSlum.Interfaces;
using System.Linq;

namespace TheSlum.Characters
{
    class Mage : Character, IAttack
    {
        const int defaultHealtPoints = 150;
        const int defaultDefencePoints = 50;
        const int defaultRangePoints = 5;
        const int defaultAtackPoints = 300;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, defaultHealtPoints, defaultDefencePoints, team, defaultRangePoints)
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
                return targets.Last();
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

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        public override string ToString()
        {
            string output = base.ToString();
            output += " Atack: " + this.AttackPoints;
            return output;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }
    }
}
