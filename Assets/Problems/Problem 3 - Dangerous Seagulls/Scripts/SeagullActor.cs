using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DangerousSeagulls
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SeagullActor : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
    {
        #region Public Interface

        public int BaseDanger { get { return _SeagullData.BaseDanger; } }

        public string SeagullName
        {
            get
            {
                return _SeagullData.Name;
            }
        }
        public Seagull GetSeagullData()
        {
            return _SeagullData;
        }
        public SeagullActor[] Friends
        {
            get
            {
                if (_friends == null)
                    _friends = new List<SeagullActor>();

                return _friends.ToArray();
            }
        }

        public static void MakeFriends(SeagullActor gullA, SeagullActor gullB)
        {
            if (gullA == null || gullB == null) return;
            gullA.AddFriend(gullB);
            gullB.AddFriend(gullA);
        }

        /// <summary>
        /// All friends' Base danger summed.
        /// </summary>
        public int FriendDangerSum
        {
            get
            {
                int danger = 0;

                for (int i = _friends.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        danger += Friends[i].BaseDanger;
                    }
                    catch
                    {
                        _friends.RemoveAt(i);
                    }
                }

                return danger;
            }
        }

        /// <summary>
        /// Base danger + all friends' Base danger.
        /// </summary>
        public int TotalDanger
        {
            get
            {
                return BaseDanger + FriendDangerSum;
            }
        }

        public void ToggleDangerColor(bool on)
        {
            if (_dangerColorOn == on) return;

            _dangerColorOn = on;

            _sr.color = _dangerColorOn ? Color.red : Color.white;
        }

        #endregion

        #region Private Members

        private bool _dangerColorOn = false;

        private SpriteRenderer _sr = null;

        private Seagull _SeagullData = new Seagull(0);

        [SerializeField]
        private List<SeagullActor> _friends = new List<SeagullActor>();

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds a friend to the list.  This needs to be private so that the static method MakeFriends can ensure a mutual connection.
        /// </summary>
        private void AddFriend(SeagullActor friend)
        {
            if (!_friends.Contains(friend))
                _friends.Add(friend);
        }

        private void Awake()
        {
            GenerateStartingDanger();
            _sr = GetComponent<SpriteRenderer>();
            SeagullManager.AddSeagull(this);
            UpdateBaseDanger();
        }

        private void Start()
        {
            GenerateName();
        }

        private void GenerateName()
        {
            _SeagullData.Name = SeagullManager.NAME_GENERATOR.GetName();
            gameObject.name = _SeagullData.Name;
        }

        private void GenerateStartingDanger()
        {
            _SeagullData.BaseDanger = UnityEngine.Random.Range(1, 10);
        }

        private void Update()
        {
            UpdateBaseDanger();
        }

        private void UpdateBaseDanger()
        {
            _SeagullData.BaseDanger = BaseDanger;
        }

        public void OnSelect()
        {
            _sr.color = Color.yellow;
        }

        public void OnDeselect()
        {
            _sr.color = _dangerColorOn ? Color.red : Color.white;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            SeagullCanvas.SelectActor(this);
        }

        #endregion
    }
}
