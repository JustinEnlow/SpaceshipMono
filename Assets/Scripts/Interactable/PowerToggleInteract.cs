using System;
using UnityEngine;

public class PowerToggleInteract : MonoBehaviour, IInteractable{

    //public event Action OnInteract;
    //EventManager eventManager;
    Ship ship;

    //public void Initialize(EventManager eventManager){this.eventManager = eventManager;}
    void Start(){ship = GetComponentInParent<Ship>();}

    public void Interact(){
        //if(OnInteract != null){OnInteract();}
        ship.eventManager.TogglePower();
    }
    public void InteractAlternate(){}
}