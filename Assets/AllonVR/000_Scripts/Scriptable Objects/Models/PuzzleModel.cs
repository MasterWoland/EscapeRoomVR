using System;
using simpleDI.Injection;
using UnityEngine;

namespace AllonVR.ScriptableObjects.Models
{
    [CreateAssetMenu(fileName = "PuzzleModel", menuName = "Models/PuzzleModel")]
    public class PuzzleModel : ScriptableObject, IInjectable
    {
        private enum PuzzleNames
        {
            None = 0,
            MagnetCard = 1,
            PushButton = 2,
            NumberKeypad = 3,
            LadderActivated = 4,
            ColorKeypad = 5
        }

        [SerializeField] private PuzzleNames _puzzleName;
        [SerializeField] private int _index = -1;
        [SerializeField] private string _tag = String.Empty;
        public string Tag { get => _tag; }
        public int PuzzleIndex { get => _index; }
        private bool _isSolved = false;
        public bool IsSolved { get => _isSolved; }

        public void Reset()
        {
            _isSolved = false;
        }

        public bool TrySetPuzzleSolved()
        {
            if (_isSolved) return false; // This Puzzle cannot be set to Solved, it already was solved
            
            _isSolved = true;
            return _isSolved;
        }
    }
}