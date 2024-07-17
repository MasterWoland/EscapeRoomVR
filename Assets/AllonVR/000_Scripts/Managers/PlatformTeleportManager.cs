using System;
using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Managers
{
    public class PlatformTeleportManager : MonoBehaviour
    {
        [InjectID(Id = ID.E_LADDER_ACTIVATED)] private PuzzleModelEvent _ladderActivatedEvent;
        [SerializeField] private GameObject _teleportArea;
        // [SerializeField] private Renderer _triggerVolume;
        private bool _isLadderActivated = false;

        private void Awake()
        {
            DIBinder.Injector.InjectID(this);
            // _triggerVolume.enabled = false;
        }

#region EVENTS
        private void OnTriggerEnter(Collider other)
        {
            if (_isLadderActivated) _teleportArea.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            _teleportArea.SetActive(false);
        }

        private void OnEnable()
        {
            _ladderActivatedEvent.Handler += OnLadderActivated;
            _ladderActivatedEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _ladderActivatedEvent.Handler -= OnLadderActivated;
            _ladderActivatedEvent.UnregisterListener(this);
        }

        private void OnLadderActivated(PuzzleModel model)
        {
            _isLadderActivated = true;
        }
#endregion
    }
}