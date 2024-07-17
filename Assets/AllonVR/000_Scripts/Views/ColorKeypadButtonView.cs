using AllonVR.Interfaces;
using Pixelplacement;
using UnityEngine;

namespace AllonVR.Views
{
    public class ColorKeypadButtonView : MonoBehaviour, IPressable
    {
        [SerializeField] private float _pressedPositionZ;
        [SerializeField] private AnimationCurve _tweenCurve;
        private Transform _transform;
        private const float DURATION = 0.1f;
        private Vector3 _defaultPosition;
        private Vector3 _pressedPosition;
        
        private void Awake()
        {
            _transform = transform;
            _defaultPosition = _pressedPosition = _transform.localPosition;
            _pressedPosition.z = _pressedPositionZ;
        }

        public void Press()
        {
            Tween.LocalPosition(_transform, _pressedPosition, DURATION, 0f, _tweenCurve, Tween.LoopType.None, null, OnPressComplete);
        }

        private void OnPressComplete()
        {
            Tween.LocalPosition(_transform, _defaultPosition, DURATION, 0f, null, Tween.LoopType.None, null, OnComplete);
        }

        private void OnComplete()
        {
            // Debug.Log("___ *** complete *** ___");
        }
    }
}