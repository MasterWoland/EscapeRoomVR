using AllonVR.Interfaces;
using Pixelplacement;
using UnityEngine;

namespace AllonVR.Views
{
    public class NumKeypadButtonView : MonoBehaviour, IPressable
    {
        [SerializeField] private SpriteRenderer _outerSprite;
        [SerializeField] private SpriteRenderer _innerSprite;
        [SerializeField] private AnimationCurve _tweenCurve = null;
        private Color _transparentColor;
        private Color _opaqueColor;
        private const float DURATION = 0.4f;
        private Transform _innerTransform;
        private Vector3 _innerDefaultScale;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _opaqueColor = _outerSprite.color;
            _transparentColor = _opaqueColor;
            _transparentColor.a = 0;

            _innerTransform = _innerSprite.transform;
            _innerDefaultScale = _innerTransform.localScale;
        }

        public void Press()
        {
            Activate(true);
            Animate();
        }

        private void Activate(bool doActivate)
        {
            _outerSprite.gameObject.SetActive(doActivate);
            _innerSprite.gameObject.SetActive(doActivate);
        }

        private void Animate()
        {
            Tween.Color(_outerSprite, _opaqueColor, _transparentColor, DURATION, 0f, _tweenCurve, Tween.LoopType.None, null,
                Reset);
            Tween.LocalScale(_innerSprite.transform, _innerDefaultScale, Vector3.zero, DURATION, 0, _tweenCurve);
        }

        private void Reset()
        {
            Activate(false);
            _outerSprite.color = _opaqueColor;
            _innerTransform.localScale = _innerDefaultScale;
        }
    }
}