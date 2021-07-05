using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DangerousSeagulls
{
    public class SeagullCanvas : MonoBehaviour
    {
        #region Static

        private static SeagullCanvas Instance = null;

        public static SeagullActor SelectedActor { get; private set; } = null;
        public static void SelectActor(SeagullActor actor)
        {
            if (SelectedActor == actor) return;

            if (SelectedActor != null)
                SelectedActor.OnDeselect();

            SelectedActor = actor;

            if (SelectedActor != null)
                SelectedActor.OnSelect();

            Instance.UpdateGUI();
        }

        #endregion

        #region References

        [SerializeField]
        private RectTransform _widget_main = null;
        [SerializeField]
        private RectTransform _widget_selectsomething = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _label_name = null;

        [SerializeField]
        private TMPro.TMP_InputField _field_baseDanger = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _label_friends = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _label_totalDanger = null;

        #endregion

        private void Awake()
        {
            Instance = this;
            _field_baseDanger.onValueChanged.AddListener(OnBaseDangerFieldChange);
            UpdateGUI();
        }

        private void OnDestroy()
        {
            _field_baseDanger.onValueChanged.RemoveListener(OnBaseDangerFieldChange);
        }

        private void UpdateGUI()
        {
            if (SelectedActor != null)
            {
                _widget_main.gameObject.SetActive(true);
                _widget_selectsomething.gameObject.SetActive(false);

                _label_name.text = SelectedActor.SeagullName;
                _field_baseDanger.text = SelectedActor.BaseDanger.ToString();
                _label_totalDanger.text = SelectedActor.TotalDanger.ToString();


                var friendStr = new System.Text.StringBuilder();

                var friendsArray = SelectedActor.Friends;

                for (int i = 0; i < friendsArray.Length; i++)
                {
                    friendStr.AppendLine(string.Format("{0}: {1} danger", friendsArray[i].SeagullName, friendsArray[i].BaseDanger.ToString()));
                }

                _label_friends.text = friendStr.ToString();
            }
            else
            {
                _widget_main.gameObject.SetActive(false);
                _widget_selectsomething.gameObject.SetActive(true);
            }
        }

        private void OnBaseDangerFieldChange(string val)
        {
            int newVal = 0;

            if (int.TryParse(val, out newVal))
                SelectedActor.GetSeagullData().BaseDanger = newVal;
        }

        public void IncreaseBaseDanger()
        {
            if (SelectedActor == null) return;

            int cur = SelectedActor.GetSeagullData().BaseDanger;
            int newVal = Mathf.Clamp(cur + 1, 1, 100);
            SelectedActor.GetSeagullData().BaseDanger = newVal;

            UpdateGUI();
        }

        public void DecreaseBaseDanger()
        {
            if (SelectedActor == null) return;

            int cur = SelectedActor.GetSeagullData().BaseDanger;
            int newVal = Mathf.Clamp(cur - 1, 1, 100);
            SelectedActor.GetSeagullData().BaseDanger = newVal;

            UpdateGUI();
        }

    }
}
