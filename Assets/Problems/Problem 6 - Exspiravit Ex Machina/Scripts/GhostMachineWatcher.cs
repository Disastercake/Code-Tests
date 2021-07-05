using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExspiravitExMachina
{
    [DisallowMultipleComponent]
    public class GhostMachineWatcher : MonoBehaviour
    {
        private static GhostMachineWatcher Instance = null;

        [SerializeField]
        private TMPro.TextMeshProUGUI _ghostCount = null;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GhostGameManager.Instance._ghostMachine.OnGhostCountChanged += OnGhostCountChanged;
            GhostGameManager.Instance._ghostMachine.OnNewGhostsCreated += OnNewGhostsCreated;
        }

        private void OnDestroy()
        {
            GhostGameManager.Instance._ghostMachine.OnGhostCountChanged -= OnGhostCountChanged;
            GhostGameManager.Instance._ghostMachine.OnNewGhostsCreated -= OnNewGhostsCreated;
        }

        private void OnNewGhostsCreated(List<Ghost> ghosts)
        {

        }

        private void OnGhostCountChanged(int count)
        {
            _ghostCount.text = count.ToString();
        }
    }
}
