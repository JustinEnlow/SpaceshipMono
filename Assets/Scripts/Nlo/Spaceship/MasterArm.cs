using System;

namespace Nlo.Spaceship{
    public class MasterArm{
        ShipEventManager eventManager;

        public bool Enabled{get; private set;}
        
        public event Action OnMasterArmToggled;

        public MasterArm(ShipEventManager eventManager){
            this.eventManager = eventManager;

            this.eventManager.OnToggleMasterArm += ToggleMasterArm;
        }

        void ToggleMasterArm(){
            Enabled = !Enabled;
            OnMasterArmToggled?.Invoke();
        }
    }
}