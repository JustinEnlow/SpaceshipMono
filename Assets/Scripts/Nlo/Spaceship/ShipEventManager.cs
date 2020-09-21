using System;

namespace Nlo.Spaceship{
    public class ShipEventManager{
        public event Action OnTogglePower;
        public event Action OnToggleTranslationAssist;
        public event Action OnToggleRotationAssist;
        public event Action<float> OnLateralInputChanged;
        public event Action<float> OnVerticalInputChanged;
        public event Action<float> OnLongitudinalInputChanged;
        public event Action<float> OnPitchInputChanged;
        public event Action<float> OnYawInputChanged;
        public event Action<float> OnRollInputChanged;
        public event Action OnToggleMasterArm;
        public event Action OnFireWeapons;
        public event Action OnStopFiringWeapons;
        public event Action<Light> OnToggleLights;
        public event Action<TuningPot> OnTuningInteract;
        public event Action<TuningPot> OnTuningInteractAlternate;
        public event Action<MFD, MFDRow, int> OnMFDButtonInteract;
        public event Action<MFD> OnMFDPotInteract;
        public event Action<MFD> OnMFDPotInteractAlternate;



        public void TogglePower(){OnTogglePower?.Invoke();}
        public void ToggleTranslationAssist(){OnToggleTranslationAssist?.Invoke();}
        public void ToggleRotationAssist(){OnToggleRotationAssist?.Invoke();}
        public void LateralInput(float value){OnLateralInputChanged?.Invoke(value);}
        public void VerticalInput(float value){OnVerticalInputChanged?.Invoke(value);}
        public void LongitudinalInput(float value){OnLongitudinalInputChanged?.Invoke(value);}
        public void PitchInput(float value){OnPitchInputChanged?.Invoke(value);}
        public void YawInput(float value){OnYawInputChanged?.Invoke(value);}
        public void RollInput(float value){OnRollInputChanged?.Invoke(value);}
        public void ToggleMasterArm(){OnToggleMasterArm?.Invoke();}
        public void FireWeapons(){OnFireWeapons?.Invoke();}
        public void StopFiringWeapons(){OnStopFiringWeapons?.Invoke();}
        public void ToggleLights(Light light){OnToggleLights?.Invoke(light);}
        public void TuningInteract(TuningPot tuningPot){OnTuningInteract?.Invoke(tuningPot);}
        public void TuningInteractAlternate(TuningPot tuningPot){OnTuningInteractAlternate?.Invoke(tuningPot);}

        public void MFDButtonInteract(MFD mfd, MFDRow mfdRow, int button){OnMFDButtonInteract?.Invoke(mfd, mfdRow, button);}
        public void MFDPotInteract(MFD mfd){OnMFDPotInteract?.Invoke(mfd);}
        public void MFDPotInteractAlternate(MFD mfd){OnMFDPotInteractAlternate?.Invoke(mfd);}
    }
}