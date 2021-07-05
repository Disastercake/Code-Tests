using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    [DisallowMultipleComponent]
    public class CharacterCanvas : MonoBehaviour
    {
        private static CharacterCanvas Instance = null;

        //public CharacterWidget[] Widgets { get { return _widgets; } }
        [SerializeField]
        private CharacterWidget[] _widgets = new CharacterWidget[] { };

        private void Awake()
        {
            Instance = this;
        }

        public static void Set(CharacterBase[] characters)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (Instance._widgets.Length > i)
                    Instance._widgets[i].Set(characters[i]);
                else
                    break;
            }
        }
    }
}
