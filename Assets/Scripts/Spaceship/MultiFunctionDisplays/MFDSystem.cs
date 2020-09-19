using System;
using UnityEngine;

public enum MFD{Left, Center, Right};
public enum MFDRow{Top, Left, Right, Bottom};
public enum MFDScreen{Main, Radar, Weapon};

public class MFDSystem{
    Ship ship;
    MFDScreen leftMFDCurrentScreen;
    MFDScreen centerMFDCurrentScreen;
    MFDScreen rightMFDCurrentScreen;

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

    /*void Awake(){
        ship.power = GetComponent<PowerToggle>();
        _pots = GetComponentsInChildren<MFDPotInteract>();
        _buttons = GetComponentsInChildren<MFDButtonInteract>();
        
        leftMFDCurrentScreen = MFDScreen.Main;
        centerMFDCurrentScreen = MFDScreen.Main;
        rightMFDCurrentScreen = MFDScreen.Main;
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
    }*/

    public MFDSystem(Ship ship){
        this.ship = ship;

        leftMFDCurrentScreen = MFDScreen.Main;
        centerMFDCurrentScreen = MFDScreen.Main;
        rightMFDCurrentScreen = MFDScreen.Main;

        for(int i = 0; i < this.ship.mfdPots.Length; i++){
            this.ship.mfdPots[i].OnInteract += IncreaseBrightness;
            this.ship.mfdPots[i].OnInteractAlternate += DecreaseBrightness;
        }
        for(int i = 0; i < this.ship.mfdButtons.Length; i++){
            this.ship.mfdButtons[i].OnInteract += ButtonInteract;
        }
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void IncreaseBrightness(MFD mfd){
        if(ship.power.Enabled){OnIncreaseMFDBrightness?.Invoke(mfd);}
    }
    void DecreaseBrightness(MFD mfd){
        if(ship.power.Enabled){OnDecreaseMFDBrightness?.Invoke(mfd);}
    }

    void ButtonInteract(MFD mfd, MFDRow row, int button){
        if(ship.power.Enabled == false) return;
        
        if(row == MFDRow.Top){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Left);
                        leftMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(leftMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Center);
                        centerMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(centerMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDRadarScreen?.Invoke(MFD.Right);
                        rightMFDCurrentScreen = MFDScreen.Radar;
                    }
                    else if(rightMFDCurrentScreen == MFDScreen.Radar){OnToggleRadarOrthoPersp?.Invoke();}
                }
            }
            if(button == 4){}
            if(button == 5){}
        }
        if(row == MFDRow.Left){
            if(button == 1){}
            if(button == 2){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Left);
                        leftMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Center);
                        centerMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Main){
                        OnActivateMFDWeaponScreen?.Invoke(MFD.Right);
                        rightMFDCurrentScreen = MFDScreen.Weapon;
                    }
                }
            }
            if(button == 3){}
            if(button == 4){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltUp?.Invoke();}
                }
            }
            if(button == 5){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Radar){OnRadarTiltDown?.Invoke();}
                }
            }
        }
        if(row == MFDRow.Right){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){}
            if(button == 4){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomIn?.Invoke();}
                }
            }
            if(button == 5){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
                else if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
                else if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Radar){OnRadarZoomOut?.Invoke();}
                }
            }
        }
        if(row == MFDRow.Bottom){
            if(button == 1){}
            if(button == 2){}
            if(button == 3){
                if(mfd == MFD.Left){
                    if(leftMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Left);
                        leftMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(leftMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Left);
                        leftMFDCurrentScreen = MFDScreen.Main;
                    }
                }
                if(mfd == MFD.Center){
                    if(centerMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Center);
                        centerMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(centerMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Center);
                        centerMFDCurrentScreen = MFDScreen.Main;
                    }
                }
                if(mfd == MFD.Right){
                    if(rightMFDCurrentScreen == MFDScreen.Radar){
                        OnActivateMFDMainScreen?.Invoke(MFD.Right);
                        rightMFDCurrentScreen = MFDScreen.Main;
                    }
                    else if(rightMFDCurrentScreen == MFDScreen.Weapon){
                        OnActivateMFDMainScreen?.Invoke(MFD.Right);
                        rightMFDCurrentScreen = MFDScreen.Main;
                    }
                }
            }
            if(button == 4){}
            if(button == 5){}
        }
    }
    
    /*void OnDisable(){for(int i = 0; i < ship.mfdPots.Length; i++){
            ship.mfdPots[i].OnInteract -= IncreaseBrightness;
            ship.mfdPots[i].OnInteractAlternate -= DecreaseBrightness;
        }
        for(int i = 0; i < ship.mfdButtons.Length; i++){
            ship.mfdButtons[i].OnInteract -= ButtonInteract;
        }
    }*/
}