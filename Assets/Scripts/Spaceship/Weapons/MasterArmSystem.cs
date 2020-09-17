using System;
using UnityEngine;

public class MasterArmSystem{
    InputController input;
    MasterArmClick masterArmInteract;

    public bool Armed{get; private set;}
    
    public event Action OnMasterArmToggled;

    public MasterArmSystem(InputController input, MasterArmClick masterArmInteract){
        this.input = input;
        this.masterArmInteract = masterArmInteract;

        input.OnToggleMasterArm += ToggleMasterArm;
        masterArmInteract.OnInteract += ToggleMasterArm;
    }

    public void ToggleMasterArm(){
        Armed = !Armed;
        OnMasterArmToggled?.Invoke();
    }
}