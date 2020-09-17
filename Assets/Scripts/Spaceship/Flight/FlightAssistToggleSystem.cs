/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;

public class FlightAssistToggleSystem{
    PowerToggleSystem power;
    InputController input;
    
    public bool TranslationAssistEnabled{get; private set;}
    public bool RotationAssistEnabled{get; private set;}

    public event Action OnTranslationAssistToggled;
    public event Action OnRotationAssistToggled;

    public FlightAssistToggleSystem(PowerToggleSystem power, InputController input){
        this.power = power;
        this.input = input;
        TranslationAssistEnabled = true;
        RotationAssistEnabled = true;

        input.OnToggleTranslationAssist += TranslationAssistToggle;
        input.OnToggleRotationAssist += RotationAssistToggle;
    }

    public void TranslationAssistToggle(){
        if(power.On){
            TranslationAssistEnabled = !TranslationAssistEnabled;
            OnTranslationAssistToggled?.Invoke();
        }
    }
    public void RotationAssistToggle(){
        if(power.On){
            RotationAssistEnabled = !RotationAssistEnabled;
            OnRotationAssistToggled?.Invoke();
        }
    }

    ~FlightAssistToggleSystem(){
        input.OnToggleTranslationAssist -= TranslationAssistToggle;
        input.OnToggleRotationAssist -= RotationAssistToggle;
    }
}