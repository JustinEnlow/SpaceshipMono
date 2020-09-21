using System;
using Nlo.Spaceship.Interfaces;

namespace Nlo.Spaceship{
    public enum TuningPot{Parameter, Main, Value, Increment};
    public enum TuningParameter{PID, Thrust, Velocity};

    public class Tuning{
        public ITune tuning{get; private set;}
        
        ShipEventManager eventManager;
        PowerToggle power;
        ShipStats stats;
        
        PIDTuning pidLogic;
        ThrustTuning thrustLogic;
        VelocityTuning velocityLogic;

        TuningParameter currentParameter = TuningParameter.PID;

        public event Action<string> OnNameChanged;
        public event Action<string> OnValueChanged;
        public event Action<string> OnIncrementChanged;

        public Tuning(ShipEventManager eventManager, PowerToggle power, ShipStats stats){
            this.eventManager = eventManager;
            this.power = power;
            this.stats = stats;
            pidLogic = new PIDTuning(this.stats);
            thrustLogic = new ThrustTuning(this.stats);
            velocityLogic = new VelocityTuning(this.stats);

            UpdateTuningParameter();

            this.eventManager.OnTuningInteract += InteractResponse;
            this.eventManager.OnTuningInteractAlternate += InteractAlternateResponse;
        }

        void InteractResponse(TuningPot tuningPot){
            if(power.Enabled == false) return;

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
        void InteractAlternateResponse(TuningPot tuningPot){
            if(power.Enabled == false) return;

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
        
        // only public in case UpdateTuningParameter call from constructor doesnt work
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
    }
}