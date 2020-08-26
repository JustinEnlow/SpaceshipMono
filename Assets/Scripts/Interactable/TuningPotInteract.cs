using System;
using UnityEngine;

public class TuningPotInteract : MonoBehaviour, IInteractable{
    public TuningPot _tuningPot;

    public event Action<TuningPot> OnInteract;
    public event Action<TuningPot> OnInteractAlternate;

    public void Interact(){
        if(OnInteract != null){OnInteract(_tuningPot);}
    }
    public void InteractAlternate(){
        if(OnInteractAlternate != null){OnInteractAlternate(_tuningPot);}
    }
}