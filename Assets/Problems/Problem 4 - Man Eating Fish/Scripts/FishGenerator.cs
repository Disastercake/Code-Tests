using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    public static class FishGenerator
    {
        private const int MANEATER_MAX = 99;
        private const float WEIGHT_MIN = 0.1f;
        private const float WEIGHT_MAX = 100f;

        /// <summary>
        /// Generates a list of fish with random weights and humans eaten count.
        /// </summary>
        /// <param name="quantity">The amount of fish to generate.</param>
        /// <param name="maneaterRatio">The percentage of fish that should be maneaters.  0.0f - 1.0f.</param>
        /// <returns>List of random fish.</returns>
        public static List<Fish> GetRandomList(int quantity, float maneaterRatio)
        {
            List<Fish> fishies = new List<Fish>();
            maneaterRatio = Mathf.Clamp01(maneaterRatio);

            int maneaterCount = Mathf.FloorToInt(((float)quantity) * maneaterRatio);

            for (int i = 0; i < quantity; i++)
            {
                var f = new Fish(
                    Random.Range(WEIGHT_MIN, WEIGHT_MAX),
                    maneaterCount > i ? Random.Range(1, MANEATER_MAX) : 0);

                fishies.Add(f);
            }

            return fishies;
        }
    }
}
