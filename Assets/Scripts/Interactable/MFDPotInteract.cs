using System;
using UnityEngine;

public class MFDPotInteract : MonoBehaviour, IInteractable{
    public MFD _mfd;

    public event Action<MFD> OnInteract;
    public event Action<MFD> OnInteractAlternate;

    public void Interact(){
        if(OnInteract != null){OnInteract(_mfd);}
    }

    public void InteractAlternate(){
        if(OnInteract != null){OnInteractAlternate(_mfd);}
    }
}