using System;
using UnityEngine;

public class MFDLogic : IMFD{
    MFDScreen _currentScreen;
    MFDSystem _mfdData;

    public event Action<MFDLogic> OnActivateMFDMainScreen;
    public event Action<MFDLogic> OnActivateMFDRadarScreen;
    public event Action<MFDLogic> OnActivateMFDWeaponScreen;

    public MFDLogic(MFDSystem mfdData){
        _mfdData = mfdData;
        ActivateMainScreen();
    }

    public void TopRowButton1(){
    }
    public void TopRowButton2(){
    }
    public void TopRowButton3(){
        if(_currentScreen == MFDScreen.Main){ActivateRadarScreen();}
        else if(_currentScreen == MFDScreen.Radar){ToggleOrthoPersp();}
    }
    public void TopRowButton4(){
    }
    public void TopRowButton5(){
    }
    public void LeftRowButton1(){
    }
    public void LeftRowButton2(){
        if(_currentScreen == MFDScreen.Main){ActivateWeaponScreen();}
    }
    public void LeftRowButton3(){
    }
    public void LeftRowButton4(){
        if(_currentScreen == MFDScreen.Radar){TiltUp();}
    }
    public void LeftRowButton5(){
        if(_currentScreen == MFDScreen.Radar){TiltDown();}
    }
    public void RightRowButton1(){
    }
    public void RightRowButton2(){
    }
    public void RightRowButton3(){
    }
    public void RightRowButton4(){
        if(_currentScreen == MFDScreen.Radar){ZoomIn();}
    }
    public void RightRowButton5(){
        if(_currentScreen == MFDScreen.Radar){ZoomOut();}
    }
    public void BottomRowButton1(){
    }
    public void BottomRowButton2(){
    }
    public void BottomRowButton3(){
        if(_currentScreen == MFDScreen.Radar){ActivateMainScreen();}
        else if(_currentScreen == MFDScreen.Weapon){ActivateMainScreen();}
    }
    public void BottomRowButton4(){
    }
    public void BottomRowButton5(){
    }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ActivateMainScreen(){
        OnActivateMFDMainScreen?.Invoke(this);
        _currentScreen = MFDScreen.Main;
    }
    public void ActivateRadarScreen(){
        OnActivateMFDRadarScreen?.Invoke(this);
        _currentScreen = MFDScreen.Radar;
    }
    public void ActivateWeaponScreen(){
        OnActivateMFDWeaponScreen?.Invoke(this);
        _currentScreen = MFDScreen.Weapon;
    }
//////////////////////////////// RADAR LOGIC ////////////////////////////////////////////////////////////////////////////////////
    void ToggleOrthoPersp(){_mfdData.radarCam.orthographic = !_mfdData.radarCam.orthographic;}
    void ZoomOut(){
        _mfdData.radarCam.orthographicSize += 5.0f;
        _mfdData.radarCam.fieldOfView += 2.5f;
    }
    void ZoomIn(){
        _mfdData.radarCam.orthographicSize -= 5.0f;
        _mfdData.radarCam.fieldOfView -= 2.5f;
    }
    void TiltDown(){_mfdData.radarCameraTilt.Rotate(Vector3.right * -2);}
    void TiltUp(){_mfdData.radarCameraTilt.Rotate(Vector3.right * 2);}
}