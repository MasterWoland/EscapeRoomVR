using System.Collections.Generic;
using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class EmissiveFloorController : MonoBehaviour
    {
        [Inject] private ColorAnswersModel _model;
        [InjectID(Id = ID.E_PUZZLE_SOLVED)] private IntEvent _puzzleSolvedEvent;
        [SerializeField] private EmissiveTileController[] _emissiveTileControllers;
        private List<EmissiveTileController> _puzzleTiles = new List<EmissiveTileController>();

        private void Awake()
        {
            DIBinder.Injector.Inject(this);
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            ResetPuzzleTiles();

            for (int i = 0; i < _emissiveTileControllers.Length; i++)
            {
                _emissiveTileControllers[i].AssignModel(_model.TileModelArray[i]);

                if (_model.TileModelArray[i].Tile == EmissiveTileModel.TileState.Puzzle)
                {
                    _puzzleTiles.Add(_emissiveTileControllers[i]);
                }
            }
        }

#region EVENTS
        private void OnEnable()
        {
            _puzzleSolvedEvent.Handler += OnPuzzleSolved;
            _puzzleSolvedEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            _puzzleSolvedEvent.Handler -= OnPuzzleSolved;
            _puzzleSolvedEvent.UnregisterListener(this);
        }
        
        // MRA: The last puzzle will not activate a tile
        private void OnPuzzleSolved(int puzzleIndex)
        {
            foreach (var tile in _puzzleTiles)
            {
                if (tile.GetPuzzleIndex() != puzzleIndex) continue;
                
                tile.Activate();
                return;
            }
        }
#endregion

#region HELPER METHODS
        private void ResetPuzzleTiles()
        {
            if (_puzzleTiles.Count > 0) _puzzleTiles.Clear();

            _puzzleTiles = new List<EmissiveTileController>();
        }
#endregion
    }
}