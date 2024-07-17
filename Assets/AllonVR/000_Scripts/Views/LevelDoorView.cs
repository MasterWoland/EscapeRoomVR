using Pixelplacement;
using UnityEngine;

namespace AllonVR.Views
{
    public class LevelDoorView : MonoBehaviour
    {
        [SerializeField] private Transform _leftDoor;
        [SerializeField] private Transform _rightDoor;
        [SerializeField] private float _leftDoorEndPosZ;
        [SerializeField] private float _rightDoorEndPosZ;
        [SerializeField] private AnimationCurve _animCurve;
        
        public void Open()
        {
            // Play Sound, delay open for 1 second

            Vector3 leftDoorEndPos = new Vector3(_leftDoor.localPosition.x, _leftDoor.localPosition.y, _leftDoorEndPosZ);
            Tween.LocalPosition(_leftDoor, leftDoorEndPos, 2f, 1f, _animCurve);
           
            Vector3 rightDoorEndPos = new Vector3(_rightDoor.localPosition.x, _rightDoor.localPosition.y, _rightDoorEndPosZ);
            Tween.LocalPosition(_rightDoor, rightDoorEndPos, 2f, 1f, _animCurve);
        }
    }
}