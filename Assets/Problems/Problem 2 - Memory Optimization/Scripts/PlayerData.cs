using System.Collections.Generic;

namespace MemoryOptimizationProblem
{
    /// <summary>
    /// Class to represent the concept of playerdata existing.
    /// Wouldn't normally encapsulate this inside a debug component, of course.
    /// </summary>
    public class PlayerData
    {
        public static PlayerData Instance { get; } = new PlayerData();

        /// <summary>
        /// Player's inventory.
        /// </summary>
        public List<string> Inventory { get; } = new List<string>()
        { "Potion", "Hi-Potion", "Phoenix Down", "Soft", "Ether", "Hi-Ether", "Longsword", "Ultima Weapon", "Wooden Buckler", "Buster Sword", "Muramasa"};
    }
}
