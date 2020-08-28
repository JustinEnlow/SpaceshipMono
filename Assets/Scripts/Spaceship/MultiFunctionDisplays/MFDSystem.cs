using System;
using UnityEngine;

public enum MFD{Left, Center, Right};
public enum MFDRow{Top, Left, Right, Bottom};
public enum MFDScreen{Main, Radar, Weapon};

public class MFDSystem : MonoBehaviour{
    PowerToggleSystem _power;
    MFDPotInteract[] _pots;
    MFDButtonInteract[] _buttons;
    MFDScreen _leftMFDCurrentScreen;
    MFDScreen _centerMFDCurrentScreen;
    MFDScreen _rightMFDCurrentScreen;

    public event Action<MFD> OnIncreaseMFDBrightness;
    public event Action<MFD> OnDecreaseMFDBrightness;
    public event Action<MFD> OnActivateMFDMainScreen;
    public event Action<MFD> OnActivateMFDRadarScreen;
    public event Action<MFD> OnActivateMFDWeaponScreen;
    public event Action OnToggleRadarOrthoPersp;
    public event Action OnRadarZoomIn;
    public event Action OnRadarZoomOut;
    public event Action OnRadarTiltUp;
    public event Action OnRadarTiltDown;

    void Awake(){
        _power = GetComponent<PowerToggleSystem>();
        _pots = GetComponentsInChildren<MFDPotInteract>();
        _buttons = GetComponentsInChildren<MFDButtonInteract>();
        
        _leftMFDCurrentScreen = MFDScreen.Main;
        _centerMFDCurrentScreen = MFDScreen.Main;
        _rightMFDCurrentScreen = MFDScreen.Main;
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
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void IncreaseBrightness(MFD mfd){
        if(_power.On){OnIncreaseMFDBrightness?.Invoke(mfd);}
    }
    void DecreaseBrightness(MFD mfd){
        if(_power.On){OnDecreaseMFDBrightness?.Invoke(mfd);}
    }

    void ButtonInteract(MFD mfd, MFDRow row, int button){
        if(_power.On == false) return;
        
        if(row == MFDRow.Top){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Left);
                        _leftMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(_leftMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Center);
                        _centerMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(_centerMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Right);
                        _rightMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(_rightMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
            }
            if(button == 4){}
            if(button == 5){}
        }
        if(row == MFDRow.Left){
            if(button == 1){}
            if(button == 2){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Left);
                        _leftMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Center);
                        _centerMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Right);
                        _rightMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
            }
            if(button == 3){}
            if(button == 4){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
            }
            if(button == 5){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
            }
        }
        if(row == MFDRow.Right){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){}
            if(button == 4){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
            }
            if(button == 5){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
            }
        }
        if(row == MFDRow.Bottom){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){
                if(mfd == MFD.Left){
                    if(_leftMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Left);
                        _leftMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(_leftMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Left);
                        _leftMFDCurrentScreen = MFDScreen.Main;
                    }
                }
                if(mfd == MFD.Center){
                    if(_centerMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Center);
                        _centerMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(_centerMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Center);
                        _centerMFDCurrentScreen = MFDScreen.Main;
                    }
                }
                if(mfd == MFD.Right){
                    if(_rightMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Right);
                        _rightMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(_rightMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Right);
                        _rightMFDCurrentScreen = MFDScreen.Main;
                    }
                }
            }
            if(button == 4){}
            if(button == 5){}
        }
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