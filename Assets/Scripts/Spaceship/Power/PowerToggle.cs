using System;
using UnityEngine;

public class PowerToggle{
    Ship ship;

    public bool Enabled{get; private set;}
    
    public event Action OnPowerToggled;

    public PowerToggle(Ship ship){
        this.ship = ship;

        this.ship.input.OnTogglePower += TogglePower;
        this.ship.powerToggleInteract.OnInteract += TogglePower;
    }

    public void TogglePower(){
        Enabled = !Enabled;
        OnPowerToggled?.Invoke();
    }
    
    ~PowerToggle(){
        ship.input.OnTogglePower -= TogglePower;
        ship.powerToggleInteract.OnInteract -= TogglePower;
    }
}