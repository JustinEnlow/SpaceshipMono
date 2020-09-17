using System;
using UnityEngine;

public class PowerToggleSystem{
    InputController input;
    PowerToggleClick powerToggleInteract;

    public bool On{get; private set;}
    
    public event Action OnPowerToggled;

    public PowerToggleSystem(InputController input, PowerToggleClick powerToggleInteract){
        this.input = input;
        this.powerToggleInteract = powerToggleInteract;

        input.OnTogglePower += TogglePower;
        powerToggleInteract.OnInteract += TogglePower;
    }

    public void TogglePower(){
        On = !On;
        OnPowerToggled?.Invoke();
    }
    
    ~PowerToggleSystem(){
        input.OnTogglePower -= TogglePower;
        powerToggleInteract.OnInteract -= TogglePower;
    }
}