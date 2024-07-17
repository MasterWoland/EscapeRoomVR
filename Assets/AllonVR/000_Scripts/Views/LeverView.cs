using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.Views
{
    public class LeverView : MonoBehaviour
    {
        [SerializeField] private Renderer _standLightRenderer;
        [SerializeField] private int[] _standMaterialIndices; // The stand has 5 material slots, we need to adjust 2 of them
        [SerializeField] private Renderer[] _electricityCableRenderers;
        [SerializeField] private Renderer _electricityGeneratorRenderer;

        public void Init(ElectricityData data)
        {
            foreach (var index in _standMaterialIndices)
            {
                _standLightRenderer.materials[index].SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
                _standLightRenderer.materials[index].SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
            }

            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
            }

            _electricityGeneratorRenderer.gameObject.SetActive(false);
        }

        public void Activate(ElectricityData data)
        {
            // // Debug.Log("[ View ] Activate");
            foreach (var index in _standMaterialIndices)
            {
                // _electricityCableRenderers[index].material.SetColor(BASE_COLOR, data.DisabledColor);
                _standLightRenderer.materials[index].SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            }

            _electricityGeneratorRenderer.gameObject.SetActive(true);
            _electricityGeneratorRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            
            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            }
        }
    }
}