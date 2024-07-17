using System.Collections;
using System.Collections.Generic;
using AllonVR.Data;
using AllonVR.ScriptableObjects.Models;
using UnityEngine;

namespace AllonVR.Views
{
    public class CardActivatorView : MonoBehaviour
    {
        [SerializeField] private Renderer _standLightRenderer;
        [SerializeField] private Renderer[] _electricityCableRenderers;
        [SerializeField] private int[] _standMaterialIndices; // The stand has 5 material slots, we need to adjust 2 of them
        // private static readonly int BASE_COLOR = Shader.PropertyToID("_BaseColor");
        // private static readonly int EMISSION_COLOR = Shader.PropertyToID("_EmissionColor");

        public void Init(ElectricityData data)
        {
            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
            }

            foreach (var index in _standMaterialIndices)
            {
                _standLightRenderer.materials[index].SetColor(GlobalData.BASE_COLOR, data.DisabledColor);
                _standLightRenderer.materials[index].SetColor(GlobalData.EMISSION_COLOR, data.DisabledColor * 0);
            } 
        }

        public void Activate(ElectricityData data)
        {
            // Debug.Log("[ View ] Activate");
            foreach (var electricityCableRenderer in _electricityCableRenderers)
            {
                electricityCableRenderer.material.SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            }
            
            foreach (var index in _standMaterialIndices)
            {
                // _electricityCableRenderers[index].material.SetColor(BASE_COLOR, data.DisabledColor);
                _standLightRenderer.materials[index].SetColor(GlobalData.EMISSION_COLOR, data.EnabledColor * data.EnabledIntensity);
            } 
        }
    }
}