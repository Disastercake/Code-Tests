using System;
using System.Collections.Generic;

namespace ExspiravitExMachina
{
    public class GhostMachine
    {
        private List<Ghost> _masterGhostList = new List<Ghost>();

        public delegate void NewGhostsCreatedHandler(List<Ghost> ghosts);
        public event NewGhostsCreatedHandler OnNewGhostsCreated = delegate { };

        public delegate void GhostCountChangedHandler(int count);
        public event GhostCountChangedHandler OnGhostCountChanged = delegate { };

        public GhostMachine()
        {

        }

        public void GenerateGhosts()
        {
            int ghostCount = new Random().Next(1, 4);
            List<Ghost> newlyDeceased = new List<Ghost>();

            for (int g = 0; g < ghostCount; g++)
            {
                newlyDeceased.Add(new Ghost("Fred", new Random().Next(1, 11)));
            }

            _masterGhostList.AddRange(newlyDeceased);

            OnNewGhostsCreated.Invoke(newlyDeceased);
            OnGhostCountChanged.Invoke(_masterGhostList.Count);
        }

        /// <summary>
        /// Creates a new ghost and adds it to the database of all ghosts.
        /// </summary>
        public Ghost Create(string nameInLife, int spookiness)
        {
            var ghost = new Ghost(nameInLife, spookiness);

            _masterGhostList.Add(ghost);

            OnNewGhostsCreated.Invoke(new List<Ghost>() { ghost });
            OnGhostCountChanged.Invoke(_masterGhostList.Count);

            return ghost;
        }

        /// <summary>
        /// Removes the ghost from the database.
        /// </summary>
        public void Destroy(Ghost toDestroy)
        {
            if (!_masterGhostList.Contains(toDestroy)) return;

            _masterGhostList.Remove(toDestroy);

            OnGhostCountChanged.Invoke(_masterGhostList.Count);
        }
    }
}
