using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExspiravitExMachina
{
    [DisallowMultipleComponent]
    public class GhostGameManager : MonoBehaviour
    {
        public static GhostGameManager Instance { get; private set; } = null;
        public GhostMachine _ghostMachine { get; private set; } = new GhostMachine();

        [SerializeField]
        private SceneActor _actorPrefab = null;

        public int StartingGhosts = 10;
        public int StartingLiving = 5;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            SpawnActors();
        }

        public void SpawnActors()
        {
            for (int i = 0; i < StartingLiving; i++)
            {
                Instantiate(_actorPrefab, GetRandomPosition(), Quaternion.identity);
            }

            for (int i = 0; i < StartingGhosts; i++)
            {
                var actor = Instantiate(_actorPrefab, GetRandomPosition(), Quaternion.identity);
                actor.Kill();
            }
        }

        private static Vector3 GetRandomPosition()
        {
            var pos = new Vector3(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f), 0f);
            pos = Camera.main.ViewportToWorldPoint(pos);
            pos.z = 0f;
            return pos;
        }
    }
}
