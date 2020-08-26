/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;

public class InputController : MonoBehaviour{
    PlayerInput _input;

    public event Action OnToggleCamera;
    public event Action<float> OnCameraHorizontalChanged;
    public event Action<float> OnCameraVerticalChanged;
    public event Action OnResetCameraRotation;
    public event Action OnRecenterVR;
    public event Action OnInteract;
    public event Action OnInteractAlternate;

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
    
    void Start(){
        _input = new PlayerInput();

        DisableSystemControls();
        DisableUIControls();

        EnablePlayerControls();
        EnableShipControls();

        _input.Player.ToggleCamera.performed += context => OnToggleCamera?.Invoke();
        _input.Player.CameraHorizontal.performed += context => OnCameraHorizontalChanged?.Invoke(context.ReadValue<float>());
        _input.Player.CameraVertical.performed += context => OnCameraVerticalChanged?.Invoke(context.ReadValue<float>());
        _input.Player.ResetCameraRotation.performed += context => OnResetCameraRotation?.Invoke();
        _input.Player.RecenterVr.performed += context => OnRecenterVR?.Invoke();
        
        _input.Player.InteractOption1.performed += context => OnInteract?.Invoke();
        _input.Player.InteractOption2.performed += context => OnInteractAlternate?.Invoke();
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        _input.Ship.TogglePower.performed += context => OnTogglePower?.Invoke();
        
        _input.Ship.ToggleTranslationAssist.performed += context => OnToggleTranslationAssist?.Invoke();
        _input.Ship.ToggleRotationAssist.performed += context => OnToggleRotationAssist?.Invoke();
        
        _input.Ship.LateralMovement.performed += context => OnLateralInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.VerticalMovement.performed += context => OnVerticalInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.LongitudinalMovement.performed += context => OnLongitudinalInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.Pitch.performed += context => OnPitchInputChanged?.Invoke(-context.ReadValue<float>());
        _input.Ship.Yaw.performed += context => OnYawInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.Roll.performed += context => OnRollInputChanged?.Invoke(-context.ReadValue<float>());
        
        _input.Ship.ToggleMasterArm.performed += context => OnToggleMasterArm?.Invoke();
        
        _input.Ship.FireShipWeapon.performed += context => OnFireWeapons?.Invoke();
        _input.Ship.FireShipWeapon.canceled += context => OnStopFiringWeapons?.Invoke();
        
        _input.Ship.ToggleFloodLights.performed += context => OnToggleLights?.Invoke(Light.Flood);
        _input.Ship.TogglePositionLights.performed += context => OnToggleLights?.Invoke(Light.Position);
        _input.Ship.ToggleStrobeLights.performed += context => OnToggleLights?.Invoke(Light.Strobe);
        
        _input.Ship.TuningParameterUp.performed += context => OnTuningInteract?.Invoke(TuningPot.Parameter);
        _input.Ship.TuningParameterDown.performed += context => OnTuningInteractAlternate?.Invoke(TuningPot.Parameter);
        _input.Ship.TuningMainUp.performed += context => OnTuningInteract?.Invoke(TuningPot.Main);
        _input.Ship.TuningMainDown.performed += context => OnTuningInteractAlternate?.Invoke(TuningPot.Main);
        _input.Ship.TuningValueUp.performed += context => OnTuningInteract?.Invoke(TuningPot.Value);
        _input.Ship.TuningValueDown.performed += context => OnTuningInteractAlternate?.Invoke(TuningPot.Value);
        _input.Ship.TuningIncrementUp.performed += context => OnTuningInteract?.Invoke(TuningPot.Increment);
        _input.Ship.TuningIncrementDown.performed += context => OnTuningInteractAlternate?.Invoke(TuningPot.Increment);
        /*
        _input.Ship.CenterMFDBottomRowButton3.performed += context => OnMFDButtonInteract?.Invoke(MFD.Center, MFDRow.Bottom, 3);
        */
    }
    public void EnableSystemControls(){_input.System.Enable();}
    public void EnablePlayerControls(){_input.Player.Enable();}
    public void EnableShipControls(){_input.Ship.Enable();}
    public void EnableUIControls(){_input.UI.Enable();}
    public void DisableSystemControls(){_input.System.Disable();}
    public void DisablePlayerControls(){_input.Player.Disable();}
    public void DisableShipControls(){_input.Ship.Disable();}
    public void DisableUIControls(){_input.UI.Disable();}
}