using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    public class FishTest : MonoBehaviour
    {
        private const int NUM_FISH = 50;
        private const float MANEATER_RATIO = 0.5f;

        private void Start()
        {
            var builder = new System.Text.StringBuilder();
            System.TimeSpan origTime;
            System.TimeSpan bsTime;
            System.TimeSpan linqTime;
            System.TimeSpan nolinqTime;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var orig = FishGenerator.GetRandomList(NUM_FISH, MANEATER_RATIO);
            watch.Stop();
            origTime = watch.Elapsed;

            watch.Restart();
            var bs = Fish.FindManEaters(orig, Fish.SortingModes.BubbleSort);
            watch.Stop();
            bsTime = watch.Elapsed;

            watch.Restart();
            var nolinq = Fish.FindManEaters(orig, Fish.SortingModes.NoLINQ);
            watch.Stop();
            nolinqTime = watch.Elapsed;

            watch.Restart();
            var linq = Fish.FindManEaters(orig, Fish.SortingModes.LINQ);
            watch.Stop();
            linqTime = watch.Elapsed;

            // Fish Generator Stats
            builder.AppendLine(string.Format("Fish Generated in {0}", origTime.TotalMilliseconds));
            for (int i = 0; i < orig.Count; i++)
            {
                builder.AppendLine(string.Format("Fish {0}; Weight {1}; Humans Eaten: {2}", i, orig[i].Weight, orig[i].HumansEaten));
            }
            Debug.Log(builder.ToString());
            builder.Clear();

            // BubbleSort Stats
            builder.AppendLine(string.Format("BubbleSort in {0}", bsTime.TotalMilliseconds));
            for (int i = 0; i < bs.Count; i++)
            {
                builder.AppendLine(string.Format("Fish {0}; Weight {1}; Humans Eaten: {2}", i, bs[i].Weight, bs[i].HumansEaten));
            }
            Debug.Log(builder.ToString());
            builder.Clear();

            // NoLINQ Stats
            builder.AppendLine(string.Format("No-LINQ in {0}", nolinqTime.TotalMilliseconds));
            for (int i = 0; i < nolinq.Count; i++)
            {
                builder.AppendLine(string.Format("Fish {0}; Weight {1}; Humans Eaten: {2}", i, nolinq[i].Weight, nolinq[i].HumansEaten));
            }
            Debug.Log(builder.ToString());
            builder.Clear();

            // LINQ Stats
            builder.AppendLine(string.Format("LINQ in {0}", linqTime.TotalMilliseconds));
            for (int i = 0; i < linq.Count; i++)
            {
                builder.AppendLine(string.Format("Fish {0}; Weight {1}; Humans Eaten: {2}", i, linq[i].Weight, linq[i].HumansEaten));
            }
            Debug.Log(builder.ToString());
            builder.Clear();
        }
    }
}
