using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManEatingFishProblem
{
    [RequireComponent(typeof(FishListItemFactory))]
    [DisallowMultipleComponent]
    public class FishListUI : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TMP_Dropdown _dropdown = null;

        private FishListItemFactory _listItemFactory = null;

        public enum SortModes
        {
            None, BubbleSort, NoLINQ, LINQ
        }

        private void Awake()
        {
            _listItemFactory = GetComponent<FishListItemFactory>();
            InitializeDropdownGUI();
        }

        private void InitializeDropdownGUI()
        {
            var options = new List<TMPro.TMP_Dropdown.OptionData>();
            var optionNames = System.Enum.GetNames(typeof(SortModes));

            for (int i = 0; i < optionNames.Length; i++)
                options.Add(new TMPro.TMP_Dropdown.OptionData(optionNames[i]));

            _dropdown.options = options;

            _dropdown.onValueChanged.AddListener(OnDropdownChanged);
        }

        private void OnDestroy()
        {
            _dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
        }

        private List<Fish> _originalList = null;

        public void Set(List<Fish> fishies)
        {
            _originalList = fishies;

            RefreshUI();
        }

        private void OnDropdownChanged(int val)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            List<Fish> sortedFish = null;
            SortModes sortMode = SortModes.None;

            if (!System.Enum.TryParse(_dropdown.options[_dropdown.value].text, out sortMode))
                Debug.LogError("Unable to parse SortMode from the dropdown widget.");

            switch (sortMode)
            {
                case SortModes.None:
                    sortedFish = _originalList;
                    break;
                case SortModes.BubbleSort:
                    sortedFish = Fish.FindManEaters(_originalList, Fish.SortingModes.BubbleSort);
                    break;
                case SortModes.NoLINQ:
                    sortedFish = Fish.FindManEaters(_originalList, Fish.SortingModes.NoLINQ);
                    break;
                case SortModes.LINQ:
                    sortedFish = Fish.FindManEaters(_originalList, Fish.SortingModes.LINQ);
                    break;
                default:
                    Debug.LogError("SortMode not implemented: " + sortMode.ToString());
                    sortedFish = _originalList;
                    break;
            }

            _listItemFactory.PoolAll();

            for (int i = 0; i < sortedFish.Count; i++)
            {
                var listItem = _listItemFactory.GetListItem();
                listItem.Set(sortedFish[i]);
                listItem.transform.SetSiblingIndex(i);
            }
        }
    }
}
