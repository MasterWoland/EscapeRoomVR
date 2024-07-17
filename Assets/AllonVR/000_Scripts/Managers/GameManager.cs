using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Managers
{
    public class GameManager : MonoBehaviour
    {
        // private enum GameState
        // {
        //     PreGame = 0,
        //     Playing = 1,
        //     Finished = 2
        // }
        //
        // private GameState _currentGameState = GameState.PreGame;

        [InjectID(Id = ID.E_ALL_PUZZLES_SOLVED)] private NoParamEvent _allPuzzlesSolvedEvent;
        [SerializeField] private GameObject _level2Holder;

        private void Awake()
        {
            DIBinder.Injector.InjectID(this);
        }

        private void Start()
        {
            _level2Holder.SetActive(false);
        }

#region EVENTS
        private void OnEnable()
        {
            _allPuzzlesSolvedEvent.Handler += OnAllPuzzlesSolved;
        }
        private void OnDisable()
        {
            _allPuzzlesSolvedEvent.Handler -= OnAllPuzzlesSolved;
        }

        private void OnAllPuzzlesSolved()
        {
            _level2Holder.SetActive(true);
        }
#endregion
    }
}