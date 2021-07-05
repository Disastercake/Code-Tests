using System.Collections;
using System.Collections.Generic;

namespace MagicalInheritance
{
    public abstract class CharacterBase
    {
        public int Health = 15;
        public int Mana = 15;

        public readonly int HealthMax = 15;
        public readonly int ManaMax = 15;

        public virtual string ClassName
        {
            get
            {
                return string.Empty;
            }
        }

        public virtual string Portrait
        {
            get
            {
                return string.Empty;
            }
        }

        public virtual List<string> GetSpells()
        {
            return new List<string>();
        }

        public virtual void Rest()
        {

        }
    }
}

/*

Given these 2 classes, Sorcerer and Wizard, create an abstract base class that they both inherit
from, and refactor them as you see fit.

● Start with classes Sorcerer.cs and Wizards.cs found in folder Problem 5 - Magical Inheritance

● You will be submitting the new base class that you have created as well as your updated versions of Sorcerer.cs and Wizard.cs


Can make a hero sheet creation.

*/