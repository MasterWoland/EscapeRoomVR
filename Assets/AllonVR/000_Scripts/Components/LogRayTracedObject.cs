using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace AllonVR.Components
{
    /// <summary>
    /// Used for troubleshooting 
    /// </summary>
    public class LogRayTracedObject : MonoBehaviour
    {
        [SerializeField] private XRRayInteractor _xrRayInteractor;

        private void Awake()
        {
            Debug.LogError(this.name+" needs an XRRayInteractor component");
        }

        public void Show()
        {
            if(_xrRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)) Debug.Log("[ hit ] "+hit.transform.name);
            
        }
        private void OnEnable()
        {
        }
    }
}