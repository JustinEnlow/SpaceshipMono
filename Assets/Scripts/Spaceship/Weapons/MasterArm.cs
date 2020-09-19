using System;
using UnityEngine;

public class MasterArm{
    Ship ship;

    public bool Enabled{get; private set;}
    
    public event Action OnMasterArmToggled;

    public MasterArm(Ship ship){
        this.ship = ship;

        this.ship.input.OnToggleMasterArm += ToggleMasterArm;
        this.ship.masterArmInteract.OnInteract += ToggleMasterArm;
    }

    public void ToggleMasterArm(){
        Enabled = !Enabled;
        OnMasterArmToggled?.Invoke();
    }
}