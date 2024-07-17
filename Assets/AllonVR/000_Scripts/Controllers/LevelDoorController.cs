using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Events;
using AllonVR.Views;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class LevelDoorController : MonoBehaviour
    {
        [InjectID(Id = ID.E_ALL_PUZZLES_SOLVED)] private NoParamEvent _allPuzzlesSolvedEvent;
        [SerializeField] private LevelDoorView _view;

        private void Awake()
        {
            DIBinder.Injector.InjectID(this);
        }

#region EVENTS
        private void OnEnable()
        {
            _allPuzzlesSolvedEvent.Handler += OnAllPuzzlesSolved;
            _allPuzzlesSolvedEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            _allPuzzlesSolvedEvent.Handler -= OnAllPuzzlesSolved;
            _allPuzzlesSolvedEvent.UnregisterListener(this);
        }

        private void OnAllPuzzlesSolved()
        {
            Debug.Log("[ LDC ] All Puzzles solved: open door!   -----------");
            _view.Open();
        }
#endregion
    }
}