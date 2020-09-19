/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;

public class FlightAssistToggle{
    Ship ship;
    
    public bool TranslationAssistEnabled{get; private set;}
    public bool RotationAssistEnabled{get; private set;}

    public event Action OnTranslationAssistToggled;
    public event Action OnRotationAssistToggled;

    public FlightAssistToggle(Ship ship){
        this.ship = ship;

        TranslationAssistEnabled = true;
        RotationAssistEnabled = true;

        this.ship.input.OnToggleTranslationAssist += TranslationAssistToggle;
        this.ship.input.OnToggleRotationAssist += RotationAssistToggle;
    }

    public void TranslationAssistToggle(){
        if(ship.power.Enabled){
            TranslationAssistEnabled = !TranslationAssistEnabled;
            OnTranslationAssistToggled?.Invoke();
        }
    }
    public void RotationAssistToggle(){
        if(ship.power.Enabled){
            RotationAssistEnabled = !RotationAssistEnabled;
            OnRotationAssistToggled?.Invoke();
        }
    }

    ~FlightAssistToggle(){
        ship.input.OnToggleTranslationAssist -= TranslationAssistToggle;
        ship.input.OnToggleRotationAssist -= RotationAssistToggle;
    }
}