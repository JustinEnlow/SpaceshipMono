using System;

namespace Nlo.Spaceship{
    public class FlightAssistToggle{
        ShipEventManager eventManager;
        PowerToggle power;

        public bool TranslationAssistEnabled{get; private set;}
        public bool RotationAssistEnabled{get; private set;}

        public event Action OnTranslationAssistToggled;
        public event Action OnRotationAssistToggled;

        public FlightAssistToggle(ShipEventManager eventManager, PowerToggle power){
            this.eventManager = eventManager;
            this.power = power;

            TranslationAssistEnabled = true;
            RotationAssistEnabled = true;

            this.eventManager.OnToggleTranslationAssist += TranslationAssistToggle;
            this.eventManager.OnToggleRotationAssist += RotationAssistToggle;
        }

        void TranslationAssistToggle(){
            if(power.Enabled){
                TranslationAssistEnabled = !TranslationAssistEnabled;
                OnTranslationAssistToggled?.Invoke();
            }
        }
        void RotationAssistToggle(){
            if(power.Enabled){
                RotationAssistEnabled = !RotationAssistEnabled;
                OnRotationAssistToggled?.Invoke();
            }
        }

        ~FlightAssistToggle(){
            eventManager.OnToggleTranslationAssist -= TranslationAssistToggle;
            eventManager.OnToggleRotationAssist -= RotationAssistToggle;
        }
    }
}