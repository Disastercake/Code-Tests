using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    [DisallowMultipleComponent]
    public class FishUI : MonoBehaviour
    {
        private const int NUM_FISH = 50;
        private const float MANEATER_RATIO = 0.5f;

        [SerializeField]
        private FishListUI _listUI = null;

        private void Start()
        {
            // Generate fish.
            var fishies = FishGenerator.GetRandomList(NUM_FISH, MANEATER_RATIO);

            // Send fish to Fish List UI.
            _listUI.Set(fishies);
        }
    }
}
