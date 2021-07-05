using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicalInheritance
{
    public class CharacterGameManager : MonoBehaviour
    {
        private void Start()
        {
            CharacterCanvas.Set(new CharacterBase[] { new Wizard() , new Sorcerer() });
        }
    }
}
