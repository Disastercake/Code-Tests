using System.Collections.Generic;

namespace MagicalInheritance
{
    public class Wizard : CharacterBase
    {
        protected SpellBook EquippedSpellBook = new SpellBook(new List<string> { "Fire Ball", "Fire Trapezoid" });

        public Wizard()
        {

        }

        public override string ClassName
        {
            get
            {
                return "Wizard";
            }
        }

        public override string Portrait
        {
            get
            {
                return "blue_mage";
            }
        }

        public override List<string> GetSpells()
        {
            return EquippedSpellBook.Spells;
        }

        public override void Rest()
        {
            Health += 5;
            if (Health > HealthMax) Health = HealthMax;

            Mana += 10;
            if (Mana > ManaMax) Mana = ManaMax;
        }
    }
}
