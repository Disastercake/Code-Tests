using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    [DisallowMultipleComponent]
    public class CharacterWidget : MonoBehaviour
    {
        private CharacterBase _currentChar = null;

        [SerializeField]
        private UnityEngine.UI.Image _portrait = null;

        [SerializeField]
        private CharacterWidgetScrollView _scrollview = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _titleText = null;

        public void Set(CharacterBase character)
        {
            _currentChar = character;
            RefreshUI();
        }

        private void RefreshUI()
        {
            if (_currentChar != null)
            {
                _titleText.text = _currentChar.ClassName;
                _scrollview.SetList(_currentChar.GetSpells());
                _portrait.enabled = true;
                
                Sprite s;
                CommonScripts.SpriteDatabase.TryGet(_currentChar.Portrait, out s);
                _portrait.sprite = s;
            }
            else
            {
                _titleText.text = "Empty";
                _scrollview.Clear();
                _portrait.enabled = false;
            }
        }
    }
}
