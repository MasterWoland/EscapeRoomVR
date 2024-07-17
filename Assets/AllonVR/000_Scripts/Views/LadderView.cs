 using System;
 using Pixelplacement;
using UnityEngine;


namespace AllonVR.Views
{
    public class LadderView : MonoBehaviour
    {
        public event Action OnLadderUp; 
        [SerializeField] private Transform _transform;
        [SerializeField] private float _endPosY;
        private Vector3 _startPos;
        private Vector3 _endPos;

        private void Awake()
        {
            _startPos = _transform.localPosition;
            _endPos = _startPos;
            _endPos.y = _endPosY;
        }

        public void Activate(bool doActivate)
        {
            if (doActivate)
            {
                Tween.LocalPosition(_transform, _endPos, 2f, 0, null, Tween.LoopType.None, null, OnUpwardsComplete);

                // MRA in the future we may want to cancel and restart a tween
                // var tween = 
                // if (tween.Status == Tween.TweenStatus.Running)
                // {
                //     Debug.Log("[ LADDER ] tween is running");
                // }
            }
            else
            {
                Tween.LocalPosition(_transform, _startPos, 2f, 0, null, Tween.LoopType.None, null, OnDownwardsComplete);
            }
        }

        private void OnUpwardsComplete()
        {
            OnLadderUp?.Invoke();
        }

        private void OnDownwardsComplete()
        {
            // Debug.Log("[ LADDER ] upwards complete ");
        }
    }
}