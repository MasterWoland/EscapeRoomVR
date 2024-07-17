using AllonVR.Components;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using simpleDI.Injection.Allon;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class MagnetCardController : MonoBehaviour
    {
        [InjectID(Id = ID.MAGNET_CARD_PUZZLE_MODEL)] private PuzzleModel _model;

        private void Awake()
        {
            DIBinder.Injector.InjectID(this);
            this.gameObject.tag = _model.Tag;
        }
    }
}