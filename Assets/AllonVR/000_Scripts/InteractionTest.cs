using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionTest : MonoBehaviour
{
    public void OnDirectInteractorSelect(SelectEnterEvent selectEnterEvent)
    {
        Debug.Log("____ Select ____ ");
    }
}
