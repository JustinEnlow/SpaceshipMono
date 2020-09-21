using System;

namespace Nlo.Spaceship{
    public enum MFD{Left, Center, Right};
    public enum MFDRow{Top, Left, Right, Bottom};
    public enum MFDScreen{Main, Radar, Weapon};

    public class MFDSystem{
        ShipEventManager eventManager;
        PowerToggle power;
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

        public MFDSystem(ShipEventManager eventManager, PowerToggle power){
            this.eventManager = eventManager;
            this.power = power;

            leftMFDCurrentScreen = MFDScreen.Main;
            centerMFDCurrentScreen = MFDScreen.Main;
            rightMFDCurrentScreen = MFDScreen.Main;

            this.eventManager.OnMFDButtonInteract += ButtonInteract;
            this.eventManager.OnMFDPotInteract += IncreaseBrightness;
            this.eventManager.OnMFDPotInteractAlternate += DecreaseBrightness;
        }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void IncreaseBrightness(MFD mfd){
            if(power.Enabled){OnIncreaseMFDBrightness?.Invoke(mfd);}
        }
        void DecreaseBrightness(MFD mfd){
            if(power.Enabled){OnDecreaseMFDBrightness?.Invoke(mfd);}
        }

        void ButtonInteract(MFD mfd, MFDRow row, int button){
            if(power.Enabled == false) return;
            
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
    }
}