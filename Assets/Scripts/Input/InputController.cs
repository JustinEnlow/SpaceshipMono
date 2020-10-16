/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using System;
using UnityEngine;
using Nlo.Spaceship;

public class InputController : MonoBehaviour{
    PlayerInput _input;
    public Ship ship;

    public event Action OnToggleCamera;
    public event Action<float> OnCameraHorizontalChanged;
    public event Action<float> OnCameraVerticalChanged;
    public event Action OnResetCameraRotation;
    public event Action OnRecenterVR;
    public event Action OnInteract;
    public event Action OnInteractAlternate;

    void Awake(){
        _input = new PlayerInput();

        DisableSystemControls();
        DisableUIControls();

        EnablePlayerControls();
        EnableShipControls();
    }

    void OnEnable(){
        _input.Player.ToggleCamera.performed += context => OnToggleCamera?.Invoke();
        _input.Player.CameraHorizontal.performed += context => OnCameraHorizontalChanged?.Invoke(context.ReadValue<float>());
        _input.Player.CameraVertical.performed += context => OnCameraVerticalChanged?.Invoke(context.ReadValue<float>());
        _input.Player.ResetCameraRotation.performed += context => OnResetCameraRotation?.Invoke();
        _input.Player.RecenterVr.performed += context => OnRecenterVR?.Invoke();
        
        _input.Player.InteractOption1.performed += context => OnInteract?.Invoke();
        _input.Player.InteractOption2.performed += context => OnInteractAlternate?.Invoke();

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        _input.Ship.TogglePower.performed += context => ship.eventManager.TogglePower();//OnTogglePower?.Invoke();
        
        _input.Ship.ToggleTranslationAssist.performed += context => ship.eventManager.ToggleTranslationAssist();//OnToggleTranslationAssist?.Invoke();
        _input.Ship.ToggleRotationAssist.performed += context => ship.eventManager.ToggleRotationAssist();//OnToggleRotationAssist?.Invoke();
        
        _input.Ship.LateralMovement.performed += context => ship.eventManager.LateralInput(context.ReadValue<float>());//OnLateralInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.VerticalMovement.performed += context => ship.eventManager.VerticalInput(context.ReadValue<float>());//OnVerticalInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.LongitudinalMovement.performed += context => ship.eventManager.LongitudinalInput(context.ReadValue<float>());//OnLongitudinalInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.Pitch.performed += context => ship.eventManager.PitchInput( - context.ReadValue<float>());//OnPitchInputChanged?.Invoke(-context.ReadValue<float>());
        _input.Ship.Yaw.performed += context => ship.eventManager.YawInput(context.ReadValue<float>());//OnYawInputChanged?.Invoke(context.ReadValue<float>());
        _input.Ship.Roll.performed += context => ship.eventManager.RollInput( - context.ReadValue<float>());//OnRollInputChanged?.Invoke(-context.ReadValue<float>());
        
        _input.Ship.ToggleMasterArm.performed += context => ship.eventManager.ToggleMasterArm();//OnToggleMasterArm?.Invoke();
        
        _input.Ship.PrimaryFireGroup.performed += context => ship.eventManager.FirePrimaryFireGroup();//OnFireWeapons?.Invoke();
        _input.Ship.PrimaryFireGroup.canceled += context => ship.eventManager.StopFiringPrimaryFireGroup();//OnStopFiringWeapons?.Invoke();
        _input.Ship.SecondaryFireGroup.performed += context => ship.eventManager.FireSecondaryFireGroup();
        _input.Ship.SecondaryFireGroup.canceled += context => ship.eventManager.StopFiringSecondaryFireGroup();

        _input.Ship.ToggleFloodLights.performed += context => ship.eventManager.ToggleLights(Nlo.Spaceship.Light.Flood);//OnToggleLights?.Invoke(Light.Flood);
        _input.Ship.TogglePositionLights.performed += context => ship.eventManager.ToggleLights(Nlo.Spaceship.Light.Position);//OnToggleLights?.Invoke(Light.Position);
        _input.Ship.ToggleStrobeLights.performed += context => ship.eventManager.ToggleLights(Nlo.Spaceship.Light.Strobe);//OnToggleLights?.Invoke(Light.Strobe);
        
        _input.Ship.TuningParameterUp.performed += context => ship.eventManager.TuningInteract(TuningPot.Parameter);//OnTuningInteract?.Invoke(TuningPot.Parameter);
        _input.Ship.TuningParameterDown.performed += context => ship.eventManager.TuningInteractAlternate(TuningPot.Parameter);//OnTuningInteractAlternate?.Invoke(TuningPot.Parameter);
        _input.Ship.TuningMainUp.performed += context => ship.eventManager.TuningInteract(TuningPot.Main);//OnTuningInteract?.Invoke(TuningPot.Main);
        _input.Ship.TuningMainDown.performed += context => ship.eventManager.TuningInteractAlternate(TuningPot.Main);//OnTuningInteractAlternate?.Invoke(TuningPot.Main);
        _input.Ship.TuningValueUp.performed += context => ship.eventManager.TuningInteract(TuningPot.Value);//OnTuningInteract?.Invoke(TuningPot.Value);
        _input.Ship.TuningValueDown.performed += context => ship.eventManager.TuningInteractAlternate(TuningPot.Value);//OnTuningInteractAlternate?.Invoke(TuningPot.Value);
        _input.Ship.TuningIncrementUp.performed += context => ship.eventManager.TuningInteract(TuningPot.Increment);//OnTuningInteract?.Invoke(TuningPot.Increment);
        _input.Ship.TuningIncrementDown.performed += context => ship.eventManager.TuningInteractAlternate(TuningPot.Increment);//OnTuningInteractAlternate?.Invoke(TuningPot.Increment);
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