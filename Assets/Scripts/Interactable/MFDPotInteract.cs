using System;
using UnityEngine;
using Nlo.Spaceship;

public class MFDPotInteract : MonoBehaviour, IInteractable{
    public MFD _mfd;
    Ship ship;

    //public event Action<MFD> OnInteract;
    //public event Action<MFD> OnInteractAlternate;
    void Start(){ship = GetComponentInParent<Ship>();}

    public void Interact(){
        //if(OnInteract != null){OnInteract(_mfd);}
        ship.eventManager.MFDPotInteract(_mfd);
    }

    public void InteractAlternate(){
        //if(OnInteract != null){OnInteractAlternate(_mfd);}
        ship.eventManager.MFDPotInteractAlternate(_mfd);
    }
}