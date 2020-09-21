using System;
using UnityEngine;
using Nlo.Spaceship;

public class MFDButtonInteract : MonoBehaviour, IInteractable{
    public MFD _mfd;
    public MFDRow _row;
    [Tooltip("1-5. From left to right, or top to bottom")]public int Button;
    Ship ship;
    
    //public event Action<MFD, MFDRow, int> OnInteract;
    void Start(){ship = GetComponentInParent<Ship>();}

    public void Interact(){
        //if(OnInteract != null){OnInteract(_mfd, _row, Button);}
        ship.eventManager.MFDButtonInteract(_mfd, _row, Button);
    }
    public void InteractAlternate(){}
}