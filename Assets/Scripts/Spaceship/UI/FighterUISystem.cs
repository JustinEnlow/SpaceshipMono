using UnityEngine;
using TMPro;
using Nlo.Tuning;

public class FighterUISystem : MonoBehaviour{
    FlightAssistToggleSystem _flight;
    PowerToggleSystem _power;
    MFDSystem _mfd;
    TuningSystem _tuning;
    
    [SerializeField]GameObject FighterUI;
    [SerializeField]GameObject TranslationAssistWarning;
    [SerializeField]GameObject RotationAssistWarning;
    [SerializeField]TextMeshProUGUI TuningName;
    [SerializeField]TextMeshProUGUI TuningValue;
    [SerializeField]TextMeshProUGUI TuningIncrement;
    [SerializeField]CanvasGroup LeftMFDCanvas;
    [SerializeField]CanvasGroup CenterMFDCanvas;
    [SerializeField]CanvasGroup RightMFDCanvas;
    [SerializeField]GameObject LeftMFDMainScreen;
    [SerializeField]GameObject LeftMFDRadarScreen;
    [SerializeField]GameObject LeftMFDWeaponScreen;
    [SerializeField]GameObject CenterMFDMainScreen;
    [SerializeField]GameObject CenterMFDRadarScreen;
    [SerializeField]GameObject CenterMFDWeaponScreen;
    [SerializeField]GameObject RightMFDMainScreen;
    [SerializeField]GameObject RightMFDRadarScreen;
    [SerializeField]GameObject RightMFDWeaponScreen;

    void Awake(){
        _flight = GetComponent<FlightAssistToggleSystem>();
        _power = GetComponent<PowerToggleSystem>();
        _mfd = GetComponent<MFDSystem>();
        _tuning = GetComponent<TuningSystem>();
    }
    void OnEnable(){
        _power.OnPowerToggled += UpdatePowerStatus;
        _flight.OnTranslationAssistToggled += UpdateTranslationAssist;
        _flight.OnRotationAssistToggled += UpdateRotationAssist;
        _tuning.OnNameChanged += UpdateTuningName;
        _tuning.OnValueChanged += UpdateTuningValue;
        _tuning.OnIncrementChanged += UpdateTuningIncrement;
        _mfd.OnIncreaseMFDBrightness += IncreaseMFDBrightness;
        _mfd.OnDecreaseMFDBrightness += DecreaseMFDBrightness;
        _mfd.OnActivateMFDMainScreen += ActivateMFDMainScreen;
        _mfd.OnActivateMFDRadarScreen += ActivateMFDRadarScreen;
        _mfd.OnActivateMFDWeaponScreen += ActivateMFDWeaponScreen;
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateTranslationAssistWarning(){
        TranslationAssistWarning.SetActive(_flight.TranslationAssistEnabled == false && _power.On);
    }
    void UpdateRotationAssistWarning(){
        RotationAssistWarning.SetActive(_flight.RotationAssistEnabled == false && _power.On);
    }

    void UpdatePowerStatus(){
        FighterUI.SetActive(_power.On);
        UpdateTranslationAssistWarning();
        UpdateRotationAssistWarning();
    }
    void UpdateTranslationAssist(){UpdateTranslationAssistWarning();}
    void UpdateRotationAssist(){UpdateRotationAssistWarning();}

    void UpdateTuningName(string name){
        TuningName.text = name;
    }
    void UpdateTuningValue(string value){
        TuningValue.text = value;
    }
    void UpdateTuningIncrement(string increment){
        TuningIncrement.text = increment;
    }

    void IncreaseMFDBrightness(MFD mfd){
        if(mfd == MFD.Left){
            if(LeftMFDCanvas.alpha < 1.0f){LeftMFDCanvas.alpha += .01f;}
        }
        if(mfd == MFD.Center){
            if(CenterMFDCanvas.alpha < 1.0f){CenterMFDCanvas.alpha += .01f;}
        }
        if(mfd == MFD.Right){
            if(RightMFDCanvas.alpha < 1.0f){RightMFDCanvas.alpha += .01f;}
        }
    }

    void DecreaseMFDBrightness(MFD mfd){
        if(mfd == MFD.Left){
            if(LeftMFDCanvas.alpha > 0f){LeftMFDCanvas.alpha -= .01f;}
        }
        if(mfd == MFD.Center){
            if(CenterMFDCanvas.alpha > 0f){CenterMFDCanvas.alpha -= .01f;}
        }
        if(mfd == MFD.Right){
            if(RightMFDCanvas.alpha > 0f){RightMFDCanvas.alpha -= .01f;}
        }
    }

    void DeactivateMFDScreens(MFD mfd){
        if(mfd == MFD.Left){
            LeftMFDMainScreen.SetActive(false);
            LeftMFDRadarScreen.SetActive(false);
            LeftMFDWeaponScreen.SetActive(false);
        }
        if(mfd == MFD.Center){
            CenterMFDMainScreen.SetActive(false);
            CenterMFDRadarScreen.SetActive(false);
            CenterMFDWeaponScreen.SetActive(false);
        }
        if(mfd == MFD.Right){
            RightMFDMainScreen.SetActive(false);
            RightMFDRadarScreen.SetActive(false);
            RightMFDWeaponScreen.SetActive(false);
        }
    }
    void ActivateMFDMainScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){LeftMFDMainScreen.SetActive(true);}
        if(mfd == MFD.Center){CenterMFDMainScreen.SetActive(true);}
        if(mfd == MFD.Right){RightMFDMainScreen.SetActive(true);}
    }
    void ActivateMFDRadarScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){LeftMFDRadarScreen.SetActive(true);}
        if(mfd == MFD.Center){CenterMFDRadarScreen.SetActive(true);}
        if(mfd == MFD.Right){RightMFDRadarScreen.SetActive(true);}
    }
    void ActivateMFDWeaponScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){LeftMFDWeaponScreen.SetActive(true);}
        if(mfd == MFD.Center){CenterMFDWeaponScreen.SetActive(true);}
        if(mfd == MFD.Right){RightMFDWeaponScreen.SetActive(true);}
    }
}