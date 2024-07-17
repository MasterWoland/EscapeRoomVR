using System;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using Pixelplacement;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace AllonVR.Views
{
    public class PushButtonView : MonoBehaviour
    {
        [SerializeField] private Renderer[] _electricityCableRenderers;
        [SerializeField] private Renderer _buttonIndicatorRenderer;
        [SerializeField] private int _buttonIndicatorIndex; // The indicator has 3 material slots, we need to adjust 1 of them
        // private static readonly int BASE_COLOR = Shader.PropertyToID("_BaseColor");
        // private static readonly int EMISSION_COLOR = Shader.PropertyToID("_EmissionColor");
        [SerializeField] private Transform _buttonTransform;
        [SerializeField] private Vector3 _buttonPushedPosition;
        private Vector3 _buttonDefaultPosition;
        private bool _isTweening = false;

        private void Awake()
        {
            _buttonDefaultPosition = _buttonTransform.localPosition;
        }

        public void Init(ElectricityData data)
        {
            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
            }

            _buttonIndicatorRenderer.materials[_buttonIndicatorIndex].SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
            _buttonIndicatorRenderer.materials[_buttonIndicatorIndex].SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
        }

        public void Activate(ElectricityData data)
        {
            // Debug.Log("[ View ] Activate");
            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            }

            _buttonIndicatorRenderer.materials[_buttonIndicatorIndex]
                .SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
        }

        public void HandlePush()
        {
            if (_isTweening) return;
            
            _isTweening = true;
            Tween.LocalPosition(_buttonTransform, _buttonPushedPosition, 0.35f, 0, Tween.EaseInOut, Tween.LoopType.None, null,
                OnPushReverse);
        }

        private void OnPushReverse()
        {
            Tween.LocalPosition(_buttonTransform, _buttonDefaultPosition, 0.2f, 0, Tween.EaseInOut, Tween.LoopType.None, null,
                OnPushFinished);
        }

        private void OnPushFinished()
        {
            _isTweening = false;
        }
    }
}