using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.Controllers
{
    public class EmissiveTileController : MonoBehaviour
    {
        [SerializeField] private Renderer _tileRenderer;
        private EmissiveTileModel _model;

        public void AssignModel(EmissiveTileModel model)
        {
            _model = model;
            SetDefaultEmission();
        }

        // MRA: move this to view!
        private void SetDefaultEmission()
        {
            _tileRenderer.material.SetColor(GlobalData.BASE_COLOR, _model.DefaultColor);
            // Debug.Log("[] setting default color: "+this.name);
            _tileRenderer.material.SetColor(GlobalData.EMISSION_COLOR, _model.DefaultColor * 0f);
        }

        public int GetPuzzleIndex()
        {
            return _model.PuzzleIndex;
        }

        public void Activate()
        {
            _tileRenderer.material.SetColor(GlobalData.BASE_COLOR, _model.ActivatedColor);
            _tileRenderer.material.SetColor(GlobalData.EMISSION_COLOR, _model.ActivatedColor * _model.EmissionIntensity);
            _tileRenderer.material.SetColor("Color", _model.ActivatedColor * _model.EmissionIntensity);
        }
    }
}