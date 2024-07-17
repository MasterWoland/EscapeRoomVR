using System.Collections.Generic;
using AllonVR.Components;
using AllonVR.Data;
using AllonVR.Interfaces;
using AllonVR.ScriptableObjects.Events;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class KeypadController : MonoBehaviour
    {
        [InjectID(Id = ID.E_BUTTON_PRESSED)] protected StringEvent _buttonPressedEvent;
        [InjectID(Id = ID.E_PUZZLE_SOLVED)] protected IntEvent _puzzleSolvedEvent;
        protected IShowable _view;
        [SerializeField] protected KeypadButtonController[] _buttonControllers;

        protected virtual void Awake()
        {
            DIBinder.Injector.InjectID(this);
        }

        protected virtual void Start()
        {
            _buttonControllers = GetComponentsInChildren<KeypadButtonController>();

            _view = GetComponent<IShowable>();
            _view.SetActive(false);
        }
        
        protected void EnableButtonEvents(bool doEnable)
        {
            foreach (var buttonController in _buttonControllers)
            {
                buttonController.EnableEventListening(doEnable);
            }
        }

#region EVENTS
        private void OnEnable()
        {
            _puzzleSolvedEvent.Handler += OnPuzzleSolvedEvent;
            _puzzleSolvedEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            _puzzleSolvedEvent.Handler -= OnPuzzleSolvedEvent;
            _puzzleSolvedEvent.UnregisterListener(this);

            if (_buttonPressedEvent.IsListenerRegistered(this))
            {
                _buttonPressedEvent.Handler -= OnButtonPressed;
                _buttonPressedEvent.UnregisterListener(this);
            }
        }

        protected virtual void OnButtonPressed(string value)
        {
            _view.ShowEntry(value);
        }

        protected virtual void OnPuzzleSolvedEvent(int puzzleNumber)
        {
        }
#endregion
    }
}