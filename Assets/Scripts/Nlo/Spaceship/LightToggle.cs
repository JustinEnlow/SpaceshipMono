using System;

namespace Nlo.Spaceship{
    public enum Light{Flood, Position, Strobe};

    public class LightToggle{
        ShipEventManager eventManager;

        public bool FloodLightsOn{get; private set;}
        public bool PositionLightsOn{get; private set;}
        public bool StrobeLightsOn{get; private set;}

        public event Action OnFloodLightsToggled;
        public event Action OnPositionLightsToggled;
        public event Action OnStrobeLightsToggled;

        public LightToggle(ShipEventManager eventManager){
            this.eventManager = eventManager;

            this.eventManager.OnToggleLights += ToggleLights;
        }

        void ToggleLights(Light light){
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
    }
}