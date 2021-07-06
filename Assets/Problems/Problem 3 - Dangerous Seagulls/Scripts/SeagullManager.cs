using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DangerousSeagulls
{
    [DisallowMultipleComponent]
    public class SeagullManager : MonoBehaviour
    {
        #region Static Abstraction

        private static SeagullManager Instance = null;
        private static List<SeagullActor> _seagulls = new List<SeagullActor>();

        private static void ToggleSeagullDangerColors(int highestDanger)
        {
            for (int i = 0; i < _seagulls.Count; i++)
            {
                _seagulls[i].ToggleDangerColor(_seagulls[i].TotalDanger >= highestDanger);
            }
        }

        #endregion

        #region Static Interface

        public static void AddSeagull(SeagullActor seagull)
        {
            if (_seagulls.Contains(seagull) == false)
                _seagulls.Add(seagull);
        }

        /// <summary>
        /// Gets the first Seagull matching the specified danger level.  Returns false if none matched.
        /// </summary>
        public static bool TryFindSeagullWithDanger(int danger, out Seagull s)
        {
            s = null;
            SeagullActor sa;

            if (TryFindSeagullWithDanger(danger, out sa))
                s = sa.GetSeagullData();

            return s != null;
        }

        /// <summary>
        /// Gets the first SeagullActor matching the specified danger level.  Returns false if none matched.
        /// </summary>
        public static bool TryFindSeagullWithDanger(int danger, out SeagullActor s)
        {
            s = null;

            for (int i = 0; i < _seagulls.Count; i++)
            {
                if (_seagulls[i].TotalDanger == danger)
                {
                    s = _seagulls[i];
                    break;
                }
            }

            return s != null;
        }

        /// <summary>
        /// Try to get the SeagullActor with the highest danger.  Returns false if no seagulls exist.
        /// </summary>
        private static bool TryGetMostDangerousSeagull(out Seagull s)
        {
            int highestDanger = GetHighestTotalDanger();

            s = null;

            return TryFindSeagullWithDanger(highestDanger, out s);
        }

        /// <summary>
        /// Try to get the SeagullActor with the highest danger.  Returns false if no seagulls exist.
        /// </summary>
        private static bool TryGetMostDangerousSeagull(out SeagullActor s)
        {
            int highestDanger = GetHighestTotalDanger();

            s = null;

            return TryFindSeagullWithDanger(highestDanger, out s);
        }

        /// <summary>
        /// Get the highest total danger a seagul has.
        /// </summary>
        public static int GetHighestTotalDanger()
        {
            if (_seagulls == null) return 0;

            int highest = 0;

            for (int i = 0; i < _seagulls.Count; i++)
            {
                var t = _seagulls[i].TotalDanger;

                if (highest < t)
                    highest = t;
            }

            return highest;
        }

        public static CommonScripts.NameGenerator NAME_GENERATOR
        {
            get
            {
                return Instance._nameGenerator;
            }
        }

        #endregion

        #region Instance Members and Methods

        private CommonScripts.NameGenerator _nameGenerator { get; } = new CommonScripts.NameGenerator();

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            _seagulls.RemoveAll(item => item == null);
            int highestDanger = GetHighestTotalDanger();
            ToggleSeagullDangerColors(highestDanger);
        }

        #endregion
    }
}
