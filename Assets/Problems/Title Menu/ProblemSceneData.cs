using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleMenuScripts
{
    [CreateAssetMenu(fileName = "Problem Scene Data", menuName = "ScriptableObjects/Problem Scene Data", order = 1)]
    public class ProblemSceneData : ScriptableObject
    {
        [SerializeField]
        private int _index;
        public int Index { get { return _index; } }

        [SerializeField]
        private string _title;
        public string Title { get { return _title; } }
    }
}
