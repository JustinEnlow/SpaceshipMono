using System;
using UnityEngine;

public class LightsInteract : MonoBehaviour, IInteractable{
    public Light _light;

    public event Action<Light> OnInteract;

    public void Interact(){
        if(OnInteract != null){OnInteract(_light);}
    }
    public void InteractAlternate(){}
}