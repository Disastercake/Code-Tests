using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExspiravitExMachina
{
    [CreateAssetMenu(fileName = "SceneActor Sprite Data", menuName = "ScriptableObjects/SceneActor Sprite Data", order = 1)]
    public class SceneActorSpriteData : ScriptableObject
    {
        [SerializeField]
        private string _id;
        public string ID { get { return _id; } }

        [SerializeField]
        private Sprite _sprite = null;
        public Sprite SpriteAsset { get { return _sprite; } }

        [SerializeField]
        private Vector3 _offset = Vector3.zero;
        public Vector3 Offset { get { return _offset; } }

        [SerializeField]
        private Vector3 _scale = Vector3.one;
        public Vector3 Scale { get { return _scale; } }
    }
}
