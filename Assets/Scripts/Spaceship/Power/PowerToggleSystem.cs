using System;
using UnityEngine;

public class PowerToggleSystem : MonoBehaviour{
    InputController _input;
    PowerToggleClick _powerToggleInteract;

    public bool On{get; private set;}
    
    public event Action OnPowerToggled;

    void Awake(){
        _input = GetComponentInChildren<InputController>();
        _powerToggleInteract = GetComponentInChildren<PowerToggleClick>();
    }
    void OnEnable(){
        _input.OnTogglePower += TogglePower;
        _powerToggleInteract.OnInteract += TogglePower;
    }

    public void TogglePower(){
        On = !On;
        OnPowerToggled?.Invoke();
    }
    
    void OnDisable(){
        _input.OnTogglePower -= TogglePower;
        _powerToggleInteract.OnInteract -= TogglePower;
    }
}