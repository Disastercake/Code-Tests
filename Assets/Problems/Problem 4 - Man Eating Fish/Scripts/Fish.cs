using System.Collections.Generic;
using System.Linq;
using System;

namespace ManEatingFishProblem
{
    public class Fish
    {
        public float Weight = 0;
        public int HumansEaten = 0;

        public enum SortingModes
        {
            BubbleSort, NoLINQ, LINQ
        }

        public Fish(float weight, int humansEaten)
        {
            Weight = weight;
            HumansEaten = humansEaten;
        }

        /// <summary>
        /// Looks through passed list and returns all man eaters, ordered from heaviest to lightest.
        /// </summary>
        public static List<Fish> FindManEaters(List<Fish> fishies, SortingModes sortMode)
        {
            switch (sortMode)
            {
                case SortingModes.LINQ:
                    return GetManEaters_LINQ(fishies);

                case SortingModes.NoLINQ:
                    return GetManEaters_NoLINQ(fishies);

                case SortingModes.BubbleSort:
                    return GetManEaters_BubbleSort(fishies);

                default:
                    UnityEngine.Debug.LogError("Sorting mode not implementeD: " + sortMode.ToString());
                    return null;
            }
        }

        /// <summary>
        /// Returns all fish that have eaten a human.
        /// </summary>
        private static List<Fish> GetManEaters_LINQ(List<Fish> fishies)
        {
            if (fishies == null) return new List<Fish>();
            
            // Where() will pick out maneaters, then OrderByDescending() orders it as stated.
            return fishies.Where(f => f.HumansEaten > 0).OrderByDescending(f => f.Weight).ToList();
        }

        /// <summary>
        /// Returns all fish that have eaten a human.
        /// </summary>
        private static List<Fish> GetManEaters_NoLINQ(List<Fish> fishies)
        {
            if (fishies == null) return new List<Fish>();

            // Fresh list so original isn't edited.
            List<Fish> maneaters = new List<Fish>(fishies);

            // Remove non-maneaters.
            for (int i = maneaters.Count-1; i >= 0; i--)
            {
                if (maneaters[i].HumansEaten < 1)
                    maneaters.RemoveAt(i);
            }

            // Sort in descending.
            maneaters.Sort((a, b) => b.Weight.CompareTo(a.Weight));

            return maneaters;
        }

        /// <summary>
        /// Returns all fish that have eaten a human.
        /// </summary>
        private static List<Fish> GetManEaters_BubbleSort(List<Fish> fishies)
        {
            if (fishies == null) return new List<Fish>();

            // Fresh list so original isn't edited.
            List<Fish> maneaters = new List<Fish>(fishies);

            // Filter only maneaters.
            for (int i = maneaters.Count - 1; i >= 0; i--)
            {
                if (maneaters[i].HumansEaten < 1)
                    maneaters.RemoveAt(i);
            }

            // Order them descending based on weight.
            // BubbleSort and others:
            //   https://stackoverflow.com/questions/35653986/i-want-an-efficient-sorting-algorithm-to-sort-an-array/35654326#35654326
            Fish temp;
            for (int i = 0; i < maneaters.Count - 1; i++)
            {
                for (int j = 0; j < maneaters.Count - 1 - i; j++)
                {
                    if (maneaters[j].Weight < maneaters[j + 1].Weight)
                    {
                        temp = maneaters[j];
                        maneaters[j] = maneaters[j + 1];
                        maneaters[j + 1] = temp;
                    }
                }
            }

            return maneaters;
        }
    }
}
