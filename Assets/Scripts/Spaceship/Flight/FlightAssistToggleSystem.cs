/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;

public class FlightAssistToggleSystem : MonoBehaviour{
    PowerToggleSystem _power;
    InputController _input;
    
    public bool TranslationAssistEnabled{get; private set;}
    public bool RotationAssistEnabled{get; private set;}

    public event Action OnTranslationAssistToggled;
    public event Action OnRotationAssistToggled;

    void Awake(){
        _power = GetComponent<PowerToggleSystem>();
        _input = GetComponentInChildren<InputController>();
        TranslationAssistEnabled = true;
        RotationAssistEnabled = true;
    }
    void OnEnable(){
        _input.OnToggleTranslationAssist += TranslationAssistToggle;
        _input.OnToggleRotationAssist += RotationAssistToggle;
    }

    public void TranslationAssistToggle(){
        if(_power.On){
            TranslationAssistEnabled = !TranslationAssistEnabled;
            OnTranslationAssistToggled?.Invoke();
        }
    }
    public void RotationAssistToggle(){
        if(_power.On){
            RotationAssistEnabled = !RotationAssistEnabled;
            OnRotationAssistToggled?.Invoke();
        }
    }

    void OnDisable(){
        _input.OnToggleTranslationAssist -= TranslationAssistToggle;
        _input.OnToggleRotationAssist -= RotationAssistToggle;
    }
}