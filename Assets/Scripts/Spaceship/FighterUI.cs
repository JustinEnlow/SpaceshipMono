using UnityEngine;
using TMPro;
using Nlo.Spaceship;

public class FighterUI : MonoBehaviour{
    PowerToggle power;
    FlightAssistToggle assistToggle;
    Tuning tuning;
    MFDSystem mfd;
    
    [SerializeField]GameObject FighterUIGameObject;
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


    public void Initialize(PowerToggle power, FlightAssistToggle assistToggle, Tuning tuning, MFDSystem mfd){
        this.power = power;
        this.assistToggle = assistToggle;
        this.tuning = tuning;
        this.mfd = mfd;
    }
    public void Enable(){
        power.OnPowerToggled += UpdatePowerStatus;
        assistToggle.OnTranslationAssistToggled += UpdateTranslationAssist;
        assistToggle.OnRotationAssistToggled += UpdateRotationAssist;
        tuning.OnNameChanged += UpdateTuningName;
        tuning.OnValueChanged += UpdateTuningValue;
        tuning.OnIncrementChanged += UpdateTuningIncrement;
        mfd.OnIncreaseMFDBrightness += IncreaseMFDBrightness;
        mfd.OnDecreaseMFDBrightness += DecreaseMFDBrightness;
        mfd.OnActivateMFDMainScreen += ActivateMFDMainScreen;
        mfd.OnActivateMFDRadarScreen += ActivateMFDRadarScreen;
        mfd.OnActivateMFDWeaponScreen += ActivateMFDWeaponScreen;
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateTranslationAssistWarning(){
        TranslationAssistWarning.SetActive(assistToggle.TranslationAssistEnabled == false && power.Enabled);
    }
    void UpdateRotationAssistWarning(){
        RotationAssistWarning.SetActive(assistToggle.RotationAssistEnabled == false && power.Enabled);
    }

    void UpdatePowerStatus(){
        FighterUIGameObject.SetActive(power.Enabled);
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
        else if(mfd == MFD.Center){
            if(CenterMFDCanvas.alpha < 1.0f){CenterMFDCanvas.alpha += .01f;}
        }
        else if(mfd == MFD.Right){
            if(RightMFDCanvas.alpha < 1.0f){RightMFDCanvas.alpha += .01f;}
        }
    }

    void DecreaseMFDBrightness(MFD mfd){
        if(mfd == MFD.Left){
            if(LeftMFDCanvas.alpha > 0f){LeftMFDCanvas.alpha -= .01f;}
        }
        else if(mfd == MFD.Center){
            if(CenterMFDCanvas.alpha > 0f){CenterMFDCanvas.alpha -= .01f;}
        }
        else if(mfd == MFD.Right){
            if(RightMFDCanvas.alpha > 0f){RightMFDCanvas.alpha -= .01f;}
        }
    }

    void DeactivateMFDScreens(MFD mfd){
        if(mfd == MFD.Left){
            LeftMFDMainScreen.SetActive(false);
            LeftMFDRadarScreen.SetActive(false);
            LeftMFDWeaponScreen.SetActive(false);
        }
        else if(mfd == MFD.Center){
            CenterMFDMainScreen.SetActive(false);
            CenterMFDRadarScreen.SetActive(false);
            CenterMFDWeaponScreen.SetActive(false);
        }
        else if(mfd == MFD.Right){
            RightMFDMainScreen.SetActive(false);
            RightMFDRadarScreen.SetActive(false);
            RightMFDWeaponScreen.SetActive(false);
        }
    }
    void ActivateMFDMainScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){LeftMFDMainScreen.SetActive(true);}
        else if(mfd == MFD.Center){CenterMFDMainScreen.SetActive(true);}
        else if(mfd == MFD.Right){RightMFDMainScreen.SetActive(true);}
    }
    void ActivateMFDRadarScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){LeftMFDRadarScreen.SetActive(true);}
        else if(mfd == MFD.Center){CenterMFDRadarScreen.SetActive(true);}
        else if(mfd == MFD.Right){RightMFDRadarScreen.SetActive(true);}
    }
    void ActivateMFDWeaponScreen(MFD mfd){
        DeactivateMFDScreens(mfd);
        if(mfd == MFD.Left){
            LeftMFDWeaponScreen.SetActive(true);
            /*
            // Enable TextMeshProUGUI for each available hardpoint
            for(int i = 0; i < ship.hardpoints.Length; i++){
                hardpointText[i].SetActive(true);
            }
            */
        }
        else if(mfd == MFD.Center){CenterMFDWeaponScreen.SetActive(true);}
        else if(mfd == MFD.Right){RightMFDWeaponScreen.SetActive(true);}
    }
}