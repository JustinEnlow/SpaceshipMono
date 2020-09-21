using System;

namespace Nlo.Spaceship{
    public class PowerToggle{
        ShipEventManager eventManager;

        public bool Enabled{get; private set;}

        public event Action OnPowerToggled;

        public PowerToggle(ShipEventManager eventManager){
            this.eventManager = eventManager;

            this.eventManager.OnTogglePower += TogglePower;
        }

        void TogglePower(){
            Enabled = !Enabled;
            OnPowerToggled?.Invoke();
        }

        ~PowerToggle(){eventManager.OnTogglePower -= TogglePower;}
    }
}