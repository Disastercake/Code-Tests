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
