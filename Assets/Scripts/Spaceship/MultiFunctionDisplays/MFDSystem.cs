using System;
using UnityEngine;

public enum MFD{Left, Center, Right};
public enum MFDRow{Top, Left, Right, Bottom};
public enum MFDScreen{Main, Radar, Weapon};

public class MFDSystem : MonoBehaviour{
    PowerToggleSystem _power;
    MFDPotInteract[] _pots;
    MFDButtonInteract[] _buttons;
    MFDLogic LeftMFD;
    MFDLogic CenterMFD;
    MFDLogic RightMFD;
    
    public Camera radarCam;
    public Transform radarCameraTilt;

    public event Action<MFD> OnIncreaseMFDBrightness;
    public event Action<MFD> OnDecreaseMFDBrightness;
    public event Action<MFD> OnActivateMFDMainScreen;
    public event Action<MFD> OnActivateMFDRadarScreen;
    public event Action<MFD> OnActivateMFDWeaponScreen;


    void Awake(){
        _power = GetComponent<PowerToggleSystem>();
        _pots = GetComponentsInChildren<MFDPotInteract>();
        _buttons = GetComponentsInChildren<MFDButtonInteract>();
        LeftMFD = new MFDLogic(this);
        CenterMFD = new MFDLogic(this);
        RightMFD = new MFDLogic(this);
    }
    void OnEnable(){
        // Subscribe to interact events on all MFD Brightness Pots
        for(int i = 0; i < _pots.Length; i++){
            _pots[i].OnInteract += IncreaseBrightness;
            _pots[i].OnInteractAlternate += DecreaseBrightness;
        }
        for(int i = 0; i < _buttons.Length; i++){
            _buttons[i].OnInteract += ButtonInteract;
        }
        LeftMFD.OnActivateMFDMainScreen += ActivateMFDMainScreen;
        LeftMFD.OnActivateMFDRadarScreen += ActivateMFDRadarScreen;
        LeftMFD.OnActivateMFDWeaponScreen += ActivateMFDWeaponScreen;
        CenterMFD.OnActivateMFDMainScreen += ActivateMFDMainScreen;
        CenterMFD.OnActivateMFDRadarScreen += ActivateMFDRadarScreen;
        CenterMFD.OnActivateMFDWeaponScreen += ActivateMFDWeaponScreen;
        RightMFD.OnActivateMFDMainScreen += ActivateMFDMainScreen;
        RightMFD.OnActivateMFDRadarScreen += ActivateMFDRadarScreen;
        RightMFD.OnActivateMFDWeaponScreen += ActivateMFDWeaponScreen;
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void IncreaseBrightness(MFD mfd){
        if(_power.On){
            if(mfd == MFD.Left) OnIncreaseMFDBrightness?.Invoke(MFD.Left);
            if(mfd == MFD.Center) OnIncreaseMFDBrightness?.Invoke(MFD.Center);
            if(mfd == MFD.Right) OnIncreaseMFDBrightness?.Invoke(MFD.Right);
        }
    }
    void DecreaseBrightness(MFD mfd){
        if(_power.On){
            if(mfd == MFD.Left) OnDecreaseMFDBrightness?.Invoke(MFD.Left);
            if(mfd == MFD.Center) OnDecreaseMFDBrightness?.Invoke(MFD.Center);
            if(mfd == MFD.Right) OnDecreaseMFDBrightness?.Invoke(MFD.Right);
        }
    }

    void ButtonInteract(MFD mfd, MFDRow row, int button){
        if(_power.On == false) return;
        
        if(mfd == MFD.Left){
            if(row == MFDRow.Top){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){LeftMFD.TopRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
            if(row == MFDRow.Left){
                if(button == 1){}
                if(button == 2){LeftMFD.LeftRowButton2();}
                if(button == 3){}
                if(button == 4){LeftMFD.LeftRowButton4();}
                if(button == 5){LeftMFD.LeftRowButton5();}
            }
            if(row == MFDRow.Right){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){}
                if(button == 4){LeftMFD.RightRowButton4();}
                if(button == 5){LeftMFD.RightRowButton5();}
            }
            if(row == MFDRow.Bottom){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){LeftMFD.BottomRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
        }
        
        if(mfd == MFD.Center){
            if(row == MFDRow.Top){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){CenterMFD.TopRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
            if(row == MFDRow.Left){
                if(button == 1){}
                if(button == 2){CenterMFD.LeftRowButton2();}
                if(button == 3){}
                if(button == 4){CenterMFD.LeftRowButton4();}
                if(button == 5){CenterMFD.LeftRowButton5();}
            }
            if(row == MFDRow.Right){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){}
                if(button == 4){CenterMFD.RightRowButton4();}
                if(button == 5){CenterMFD.RightRowButton5();}
            }
            if(row == MFDRow.Bottom){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){CenterMFD.BottomRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
        }
        
        if(mfd == MFD.Right){
            if(row == MFDRow.Top){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){RightMFD.TopRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
            if(row == MFDRow.Left){
                if(button == 1){}
                if(button == 2){RightMFD.LeftRowButton2();}
                if(button == 3){}
                if(button == 4){RightMFD.LeftRowButton4();}
                if(button == 5){RightMFD.LeftRowButton5();}
            }
            if(row == MFDRow.Right){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){}
                if(button == 4){RightMFD.RightRowButton4();}
                if(button == 5){RightMFD.RightRowButton5();}
            }
            if(row == MFDRow.Bottom){
                if(button == 1){}
                if(button == 2){}
                if(button == 3){RightMFD.BottomRowButton3();}
                if(button == 4){}
                if(button == 5){}
            }
        }
    }
    
    void ActivateMFDMainScreen(MFDLogic mfd){
        if(mfd == LeftMFD) OnActivateMFDMainScreen?.Invoke(MFD.Left);
        if(mfd == CenterMFD) OnActivateMFDMainScreen?.Invoke(MFD.Center);
        if(mfd == RightMFD) OnActivateMFDMainScreen?.Invoke(MFD.Right);
    }
    void ActivateMFDRadarScreen(MFDLogic mfd){
        if(mfd == LeftMFD) OnActivateMFDRadarScreen?.Invoke(MFD.Left);
        if(mfd == CenterMFD) OnActivateMFDRadarScreen?.Invoke(MFD.Center);
        if(mfd == RightMFD) OnActivateMFDRadarScreen?.Invoke(MFD.Right);
    }
    void ActivateMFDWeaponScreen(MFDLogic mfd){
        if(mfd == LeftMFD) OnActivateMFDWeaponScreen?.Invoke(MFD.Left);
        if(mfd == CenterMFD) OnActivateMFDWeaponScreen?.Invoke(MFD.Center);
        if(mfd == RightMFD) OnActivateMFDWeaponScreen?.Invoke(MFD.Right);
    }
    
    void OnDisable(){for(int i = 0; i < _pots.Length; i++){
            _pots[i].OnInteract -= IncreaseBrightness;
            _pots[i].OnInteractAlternate -= DecreaseBrightness;
        }
        for(int i = 0; i < _buttons.Length; i++){
            _buttons[i].OnInteract -= ButtonInteract;
        }
    }
}