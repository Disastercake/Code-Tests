using System.Collections.Generic;

namespace MagicalInheritance
{
	public class SpellBook
	{
		public List<string> Spells = new List<string>();

		public SpellBook(List<string> spells)
		{
			Spells = spells;
		}
	}
}
