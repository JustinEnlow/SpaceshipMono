using System;
using UnityEngine;
using Nlo.Spaceship;

public class LightsInteract : MonoBehaviour, IInteractable{
    public Nlo.Spaceship.Light _light;
    Ship ship;

    //public event Action<Light> OnInteract;
    void Start(){ship = GetComponentInParent<Ship>();}

    public void Interact(){
        //if(OnInteract != null){OnInteract(_light);}
        ship.eventManager.ToggleLights(_light);
    }
    public void InteractAlternate(){}
}