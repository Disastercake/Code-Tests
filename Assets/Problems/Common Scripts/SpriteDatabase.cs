using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonScripts
{
    [DisallowMultipleComponent]
    public class SpriteDatabase : MonoBehaviour
    {
        private static SpriteDatabase _instance = null;

        [SerializeField]
        private Sprite[] _sprites = null;

        private Dictionary<string, Sprite> _database = new Dictionary<string, Sprite>();

        private void Awake()
        {
            _instance = this;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _database.Clear();
            if (_sprites == null) return;

            for (int i = 0; i < _sprites.Length; i++)
            {
                var s = _sprites[i];

                if (s != null)
                {
                    if (_database.ContainsKey(s.name) == false)
                        _database.Add(s.name, s);
                }
            }
        }

        public static bool TryGet(string name, out Sprite sprite)
        {
            sprite = null;
            if (_instance == null) return false;
            return _instance._database.TryGetValue(name, out sprite);
        }
    }
}
