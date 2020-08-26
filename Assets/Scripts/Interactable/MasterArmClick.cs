using System;
using UnityEngine;

public class MasterArmClick : MonoBehaviour, IInteractable{
    public event Action OnInteract;

    public void Interact(){
        if(OnInteract != null){OnInteract();}
    }
    public void InteractAlternate(){}
}