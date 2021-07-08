using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemoryOptimizationProblem
{
    [DisallowMultipleComponent]
    public class VictoryCanvas : MonoBehaviour
    {
        private static readonly WaitForSeconds _wait = new WaitForSeconds(2f);

        [SerializeField]
        private TMPro.TextMeshProUGUI _text = null;
        [SerializeField]
        private TMPro.TextMeshProUGUI _textDropShadow = null;

        private void Start()
        {
            StartCoroutine(Cycle());
        }

        private IEnumerator Cycle()
        {
            // Cache the inventory so no outside code can edit it while cycling.
            var inv = PlayerData.Instance.Inventory.ToArray();

            do
            {

                for (int i = 0; i < inv.Length; i++)
                {
                    string t = string.Format("You found {0}!", inv[i]);
                    _text.text = t;
                    _textDropShadow.text = t;
                    yield return _wait;
                }

            } while (true);
        }
    }
}
