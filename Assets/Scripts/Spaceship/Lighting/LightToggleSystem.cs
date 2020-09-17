using System;
using UnityEngine;

public enum Light{Flood, Position, Strobe};

public class LightToggleSystem{
    InputController input;
    LightsInteract[] lights;
    
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

    public LightToggleSystem(InputController input, LightsInteract[] lights){
        this.input = input;
        this.lights = lights;

        this.input.OnToggleLights += ToggleLights;
        for(int i = 0; i < this.lights.Length; i++){
            this.lights[i].OnInteract += ToggleLights;
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