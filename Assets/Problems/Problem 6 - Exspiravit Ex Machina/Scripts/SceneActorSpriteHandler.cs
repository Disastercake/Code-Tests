using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExspiravitExMachina
{
    [DisallowMultipleComponent]
    public class SceneActorSpriteHandler : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer = null;

        [SerializeField]
        private SceneActorSpriteData[] _spriteDataArray = new SceneActorSpriteData[] { };

        private Dictionary<string, SceneActorSpriteData> _database = new Dictionary<string, SceneActorSpriteData>();

        private void Awake()
        {
            InitializeDatabase();
            _renderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void InitializeDatabase()
        {
            if (_database.Count > 0)
                _database.Clear();

            for (int i = 0; i < _spriteDataArray.Length; i++)
            {
                if (_spriteDataArray[i] != null)
                {
                    try
                    {
                        _database.Add(_spriteDataArray[i].ID, _spriteDataArray[i]);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
        }

        public void SetSprite(string id)
        {
            SceneActorSpriteData data;

            if (_database.TryGetValue(id, out data))
            {
                _renderer.sprite = data.SpriteAsset;
                _renderer.transform.localPosition = data.Offset;
            }
            else
            {
                Debug.LogError($"Sprite ID was not found: {id}");
            }
        }
    }
}
