using System;
using UnityEngine;
using Nlo.Spaceship;

public class TuningPotInteract : MonoBehaviour, IInteractable{
    public TuningPot _tuningPot;
    //EventManager eventManager;
    Ship ship;

    //public void Initialize(EventManager eventManager){this.eventManager = eventManager;}
    void Start(){ship = GetComponentInParent<Ship>();}

    //public event Action<TuningPot> OnInteract;
    //public event Action<TuningPot> OnInteractAlternate;

    public void Interact(){
        //if(OnInteract != null){OnInteract(_tuningPot);}
        ship.eventManager.TuningInteract(_tuningPot);
    }
    public void InteractAlternate(){
        //if(OnInteractAlternate != null){OnInteractAlternate(_tuningPot);}
        ship.eventManager.TuningInteractAlternate(_tuningPot);
    }
}