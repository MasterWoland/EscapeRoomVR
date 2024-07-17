using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "PuzzleValues", menuName = "Data/PuzzleValues")]
    public class PuzzleValues : ScriptableObject, IInjectable
    {
        public float PUSH_BUTTON_MINIMAL_VELOCITY = 20f; // MRA: to GlobalData?
        // public int[] KEYPAD_CODE = new[] {0, 9, 8, 5};
    }
}