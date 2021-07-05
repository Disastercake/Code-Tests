using System;
using System.Collections.Generic;

namespace MagicalInheritance
{
    public class Sorcerer : CharacterBase
    {
        public List<string> MemorizedSpells = new List<string>() { "Chilling Grasp", "Gentle Massage" };

        public Sorcerer()
        {

        }

        public override string ClassName
        {
            get
            {
                return "Sorcerer";
            }
        }

        public override string Portrait
        {
            get
            {
                return "red_mage";
            }
        }

        public override List<string> GetSpells()
        {
            return MemorizedSpells;
        }

        public override void Rest()
        {
            Health = Math.Min(Health + 8, HealthMax);

            Mana = Math.Min(Mana + 8, ManaMax);
        }
    }
}
