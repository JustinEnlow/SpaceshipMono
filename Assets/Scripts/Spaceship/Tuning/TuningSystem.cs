/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;
using Nlo.Tuning;

public enum TuningPot{Parameter, Main, Value, Increment};
public enum TuningParameter{PID, Thrust, Velocity};

public class TuningSystem{
    public ITune Tuning{get; private set;}
    
    PowerToggleSystem power;
    InputController input;
    TuningPotInteract[] pots;
    ShipStats stats;
    
    PIDTuning pidLogic;
    ThrustTuning thrustLogic;
    VelocityTuning velocityLogic;

    TuningParameter currentParameter = TuningParameter.PID;

    public event Action<string> OnNameChanged;
    public event Action<string> OnValueChanged;
    public event Action<string> OnIncrementChanged;


    /*void Awake(){
        _power = GetComponent<PowerToggleSystem>();
        _input = GetComponentInChildren<InputController>();
        _pots = GetComponentsInChildren<TuningPotInteract>();
        var _stats = GetComponent<ShipStats>();
        _pidLogic = new PIDTuning(_stats);
        _thrustLogic = new ThrustTuning(_stats);
        _velocityLogic = new VelocityTuning(_stats);
    }
    void Start(){UpdateTuningParameter();}
    void OnEnable(){
        _input.OnTuningInteract += InteractResponse;
        _input.OnTuningInteractAlternate += InteractAlternateResponse;
        for(int i = 0; i < _pots.Length; i++){
            _pots[i].OnInteract += InteractResponse;
            _pots[i].OnInteractAlternate += InteractAlternateResponse;
        }
    }*/

    public TuningSystem(PowerToggleSystem power, InputController input, TuningPotInteract[] pots, ShipStats stats){
        this.power = power;
        this.input = input;
        this.pots = pots;
        this.stats = stats;
        pidLogic = new PIDTuning(this.stats);
        thrustLogic = new ThrustTuning(this.stats);
        velocityLogic = new VelocityTuning(this.stats);

        UpdateTuningParameter();

        this.input.OnTuningInteract += InteractResponse;
        this.input.OnTuningInteractAlternate += InteractAlternateResponse;
        for(int i = 0; i < this.pots.Length; i++){
            this.pots[i].OnInteract += InteractResponse;
            this.pots[i].OnInteractAlternate += InteractAlternateResponse;
        }
    }

    public void InteractResponse(TuningPot tuningPot){
        if(power.On == false) return;

        if(tuningPot == TuningPot.Parameter){
            if(currentParameter < TuningParameter.Velocity){
                currentParameter = currentParameter + 1;
            }
            UpdateTuningParameter();
        }
        if(tuningPot == TuningPot.Main){
            Tuning.MainUp();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Value){
            Tuning.ValueUp();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Increment){
            Tuning.IncrementUp();
            TriggerUIUpdate();
        }
    }
    public void InteractAlternateResponse(TuningPot tuningPot){
        if(power.On == false) return;

        if(tuningPot == TuningPot.Parameter){
            if(currentParameter > TuningParameter.PID){
                currentParameter = currentParameter - 1;
            }
            UpdateTuningParameter();
        }
        if(tuningPot == TuningPot.Main){
            Tuning.MainDown();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Value){
            Tuning.ValueDown();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Increment){
            Tuning.IncrementDown();
            TriggerUIUpdate();
        }
    }
    
    void UpdateTuningParameter(){
        if(currentParameter == TuningParameter.PID){Tuning = pidLogic;}
        else if(currentParameter == TuningParameter.Thrust){Tuning = thrustLogic;}
        else if(currentParameter == TuningParameter.Velocity){Tuning = velocityLogic;}
            
        TriggerUIUpdate();
    }

    void TriggerUIUpdate(){
        OnNameChanged?.Invoke(Tuning.Name);
        OnValueChanged?.Invoke(Tuning.Value);
        OnIncrementChanged?.Invoke(Tuning.Increment);
    }
    
    /*void OnDisable(){
        _input.OnTuningInteract -= InteractResponse;
        _input.OnTuningInteractAlternate -= InteractAlternateResponse;for(int i = 0; i < _pots.Length; i++){
            _pots[i].OnInteract -= InteractResponse;
            _pots[i].OnInteractAlternate -= InteractAlternateResponse;
        }
    }*/
}