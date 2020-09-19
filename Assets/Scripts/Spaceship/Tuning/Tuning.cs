/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;
using Nlo.Tuning;

public enum TuningPot{Parameter, Main, Value, Increment};
public enum TuningParameter{PID, Thrust, Velocity};

public class Tuning{
    public ITune tuning{get; private set;}
    
    Ship ship;
    
    PIDTuning pidLogic;
    ThrustTuning thrustLogic;
    VelocityTuning velocityLogic;

    TuningParameter currentParameter = TuningParameter.PID;

    public event Action<string> OnNameChanged;
    public event Action<string> OnValueChanged;
    public event Action<string> OnIncrementChanged;


    /*void Awake(){
        _power = GetComponent<PowerToggle>();
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

    public Tuning(Ship ship){
        this.ship = ship;
        pidLogic = new PIDTuning(this.ship.stats);
        thrustLogic = new ThrustTuning(this.ship.stats);
        velocityLogic = new VelocityTuning(this.ship.stats);

        //UpdateTuningParameter();

        this.ship.input.OnTuningInteract += InteractResponse;
        this.ship.input.OnTuningInteractAlternate += InteractAlternateResponse;
        for(int i = 0; i < this.ship.tuningPots.Length; i++){
            this.ship.tuningPots[i].OnInteract += InteractResponse;
            this.ship.tuningPots[i].OnInteractAlternate += InteractAlternateResponse;
        }
    }

    public void InteractResponse(TuningPot tuningPot){
        if(ship.power.Enabled == false) return;

        if(tuningPot == TuningPot.Parameter){
            if(currentParameter < TuningParameter.Velocity){
                currentParameter = currentParameter + 1;
            }
            UpdateTuningParameter();
        }
        if(tuningPot == TuningPot.Main){
            tuning.MainUp();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Value){
            tuning.ValueUp();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Increment){
            tuning.IncrementUp();
            TriggerUIUpdate();
        }
    }
    public void InteractAlternateResponse(TuningPot tuningPot){
        if(ship.power.Enabled == false) return;

        if(tuningPot == TuningPot.Parameter){
            if(currentParameter > TuningParameter.PID){
                currentParameter = currentParameter - 1;
            }
            UpdateTuningParameter();
        }
        if(tuningPot == TuningPot.Main){
            tuning.MainDown();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Value){
            tuning.ValueDown();
            TriggerUIUpdate();
        }
        if(tuningPot == TuningPot.Increment){
            tuning.IncrementDown();
            TriggerUIUpdate();
        }
    }
    
    public void UpdateTuningParameter(){
        if(currentParameter == TuningParameter.PID){tuning = pidLogic;}
        else if(currentParameter == TuningParameter.Thrust){tuning = thrustLogic;}
        else if(currentParameter == TuningParameter.Velocity){tuning = velocityLogic;}
            
        TriggerUIUpdate();
    }

    void TriggerUIUpdate(){
        OnNameChanged?.Invoke(tuning.Name);
        OnValueChanged?.Invoke(tuning.Value);
        OnIncrementChanged?.Invoke(tuning.Increment);
    }
    
    /*void OnDisable(){
        _input.OnTuningInteract -= InteractResponse;
        _input.OnTuningInteractAlternate -= InteractAlternateResponse;for(int i = 0; i < _pots.Length; i++){
            _pots[i].OnInteract -= InteractResponse;
            _pots[i].OnInteractAlternate -= InteractAlternateResponse;
        }
    }*/
}