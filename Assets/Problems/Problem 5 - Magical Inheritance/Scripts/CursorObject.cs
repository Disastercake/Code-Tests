using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    [DisallowMultipleComponent]
    public class CursorObject : MonoBehaviour
    {
        private static CursorObject _instance = null;
        private RectTransform _rt = null;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _rt = GetComponent<RectTransform>();
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("There was more than one CursorObject in the scene.  There can only be one!  Destroying the weakest now...");
                Destroy(gameObject);
            }
        }

        public static void Show(Vector3 worldPos)
        {
            _instance._rt.position = worldPos;
            _instance.gameObject.SetActive(true);
        }

        public static void Hide()
        {
            _instance.gameObject.SetActive(false);
        }
    }
}
