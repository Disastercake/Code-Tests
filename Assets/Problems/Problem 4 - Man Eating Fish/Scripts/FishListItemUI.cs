using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    [DisallowMultipleComponent]
    public class FishListItemUI : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI _label_weight = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _label_kills = null;

        public Fish _fish { get; private set; } = null;

        public void Set(Fish fish)
        {
            _fish = fish;
            RefreshGUI();
        }

        private void RefreshGUI()
        {
            if (_fish != null)
            {
                gameObject.SetActive(true);
                _label_weight.text = _fish.Weight.ToString(".#");
                _label_kills.text = _fish.HumansEaten.ToString();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
