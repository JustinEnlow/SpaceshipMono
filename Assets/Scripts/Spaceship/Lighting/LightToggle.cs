using System;
using UnityEngine;

public enum Light{Flood, Position, Strobe};

public class LightToggle{
    Ship ship;
    
    public bool FloodLightsOn{get; private set;}
    public bool PositionLightsOn{get; private set;}
    public bool StrobeLightsOn{get; private set;}
    
    public event Action OnFloodLightsToggled;
    public event Action OnPositionLightsToggled;
    public event Action OnStrobeLightsToggled;

    /*void Awake(){
        _input = GetComponentInChildren<InputController>();
        _lights = GetComponentsInChildren<LightsInteract>();
        }
    void OnEnable(){
        _input.OnToggleLights += ToggleLights;
        for(int i = 0; i < _lights.Length; i++){
            _lights[i].OnInteract += ToggleLights;
        }
    }*/

    public LightToggle(Ship ship){
        this.ship = ship;

        this.ship.input.OnToggleLights += ToggleLights;
        for(int i = 0; i < this.ship.lights.Length; i++){
            this.ship.lights[i].OnInteract += ToggleLights;
        }
    }
    
    public void ToggleLights(Light light){
        if(light == Light.Flood){
            FloodLightsOn = !FloodLightsOn;
            OnFloodLightsToggled?.Invoke();
        }
        if(light == Light.Position){
            PositionLightsOn = !PositionLightsOn;
            OnPositionLightsToggled?.Invoke();
        }
        if(light == Light.Strobe){
            StrobeLightsOn = !StrobeLightsOn;
            OnStrobeLightsToggled?.Invoke();
        }
    }

    /*void OnDisable(){
        _input.OnToggleLights -= ToggleLights;
        for(int i = 0; i < _lights.Length; i++){
            _lights[i].OnInteract -= ToggleLights;
        }
    }*/
}