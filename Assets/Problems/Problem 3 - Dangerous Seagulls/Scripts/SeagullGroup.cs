using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DangerousSeagulls
{
    public class SeagullGroup : MonoBehaviour
    {
        void Start()
        {
            var gulls = GetComponentsInChildren<SeagullActor>();

            if (gulls.Length <= 1)
                return;

            for (int i1 = 0; i1 < gulls.Length; i1++)
            {
                var gullA = gulls[i1];

                for (int i2 = i1 + 1; i2 < gulls.Length; i2++)
                {
                    SeagullActor.MakeFriends(gullA, gulls[i2]);
                }
            }
        }
    }
}
