using System;
using UnityEngine;

public class MFDButtonInteract : MonoBehaviour, IInteractable{
    public MFD _mfd;
    public MFDRow _row;
    [Tooltip("1-5. From left to right, or top to bottom")]public int Button;
    
    public event Action<MFD, MFDRow, int> OnInteract;

    public void Interact(){
        if(OnInteract != null){OnInteract(_mfd, _row, Button);}
    }
    public void InteractAlternate(){}
}