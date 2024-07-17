using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AllonVR.Components
{
    public class IgnoreTeleportRayOnGrabbed : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable _xrGrabInteractable;
        private readonly int _defaultLayer = 0; // We can see the integer value in the Layer dropdown
        private readonly int _ignoreRaycastLayer = 2; // We can see the integer value in the Layer dropdown

        private void Awake()
        {
            // If the XRGrabInteractable is not assigned in the Inspector, we must try tyo fetch it
            if (_xrGrabInteractable == null) _xrGrabInteractable = GetComponent<XRGrabInteractable>();

            if (_xrGrabInteractable == null) Debug.LogError("[ Error ] This component needs an XRGrabInteractable");
        }

#region EVENTS
        private void OnEnable()
        {
            _xrGrabInteractable.selectEntered.AddListener(OnSelectEntered);
            _xrGrabInteractable.selectExited.AddListener(OnSelectExited);
        }

        private void OnDisable()
        {
            _xrGrabInteractable.selectEntered.RemoveListener(OnSelectEntered);
            _xrGrabInteractable.selectExited.RemoveListener(OnSelectExited);
        }

        private void OnSelectEntered(SelectEnterEventArgs arg0)
        {
            this.gameObject.layer = _ignoreRaycastLayer;
        }

        private void OnSelectExited(SelectExitEventArgs arg0)
        {
            this.gameObject.layer = _defaultLayer;
        }
#endregion
    }
}