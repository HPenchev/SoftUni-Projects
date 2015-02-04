using System;
using System.Collections.Generic;
using TheSlum.Interfaces;
using System.Linq;

namespace TheSlum.Characters
{
    class Healer : Character, IHeal
    {
        const int defaultHealtPoints = 75;
        const int defaultDefencePoints = 50;
        const int defaultRangePoints = 6;
        const int defaultHealingPoints = 60;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, defaultDefencePoints, defaultDefencePoints, team, defaultRangePoints)
        {
            this.HealingPoints = defaultHealingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targets =
            from target in targetsList
            where target.IsAlive
            where target.Team == this.Team
            where target.Id != this.Id
            orderby target.HealthPoints
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
            output += " Healing: " + this.HealingPoints;
            return output;
        }
    }
}
