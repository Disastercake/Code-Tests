using System.Text;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MemoryOptimizationProblem
{
    /// <summary>
    /// You can attach this to a Unity game object for testing.
    /// </summary>
    [DisallowMultipleComponent]
    public class Optimize : MonoBehaviour
    {
        /// <summary>
        /// This doesn't seem to need to change, so make it a constant.
        /// </summary>
        private const float delay = 1;

        /// <summary>
        /// Prints entire inventory to a single debug log.
        /// </summary>
        public void PrintInventory()
        {
            var str = new StringBuilder();
            var inv = PlayerData.Instance.Inventory;

            for (int i = 0; i < inv.Count; i++)
            {
                str.AppendLine(inv[i]);
            }

            Debug.Log(str.ToString());
        }

        /// <summary>
        /// Slowly prints the inventory to the console.
        /// </summary>
        public void StartSlowLog()
        {
            StopSlowLog(); // Stop anything currently running.
            StartCoroutine(SlowPrintRoutine());
        }

        /// <summary>
        /// Stop the printing to console.
        /// </summary>
        public void StopSlowLog()
        {
            StopAllCoroutines();
        }

        private IEnumerator SlowPrintRoutine()
        {
            // Cache the inventory so no outside code can edit it while cycling.
            var inv = PlayerData.Instance.Inventory.ToArray();

            for (int i = 0; i < inv.Length; i++)
            {
                Debug.Log(inv[i]);
                yield return CommonScripts.Yielders.WaitScaled(delay);
            }

            yield break;
        }

        private void Start()
        {
            PrintInventory();
            StartSlowLog();
        }
    }
}
