using UnityEngine;
using Nlo.Spaceship;

public class FighterAnimation : MonoBehaviour{
    PowerToggle power;
    MasterArm masterArm;
    LightToggle lightToggle;

    [SerializeField]GameObject PowerSwitchMesh;
    [SerializeField]GameObject MasterArmSwitchMesh;
    [SerializeField]GameObject floodSwitchMesh, positionSwitchMesh, strobeSwitchMesh;
    [SerializeField]GameObject floodLights, positionLights, strobeLights;
    [SerializeField]Renderer positionMeshRendererLeft, positionMeshRendererRight;
    [SerializeField]Renderer strobeMeshRenderer;


    public void Initialize(PowerToggle power, MasterArm masterArm, LightToggle lightToggle){
        this.power = power;
        this.masterArm = masterArm;
        this.lightToggle = lightToggle;
    }
    public void Enable(){
        power.OnPowerToggled += AnimatePowerSwitch;
        masterArm.OnMasterArmToggled += AnimateMasterArmSwitch;
        lightToggle.OnFloodLightsToggled += AnimateFloodSwitch;
        lightToggle.OnFloodLightsToggled += UpdateFloodLights;
        lightToggle.OnPositionLightsToggled += AnimatePositionSwitch;
        lightToggle.OnPositionLightsToggled += UpdatePositionLights;
        lightToggle.OnStrobeLightsToggled += AnimateStrobeSwitch;
        lightToggle.OnStrobeLightsToggled += UpdateStrobeLights;
    }

    void AnimatePowerSwitch(){
        RotateSwitch(power.Enabled, PowerSwitchMesh);

        UpdateFloodLights();
        UpdatePositionLights();
        UpdateStrobeLights();
    }

    void AnimateMasterArmSwitch(){RotateSwitch(masterArm.Enabled, MasterArmSwitchMesh);}

    void AnimateFloodSwitch(){RotateSwitch(lightToggle.FloodLightsOn, floodSwitchMesh);}
    void UpdateFloodLights(){floodLights.SetActive(lightToggle.FloodLightsOn && power.Enabled);}
    
    void AnimatePositionSwitch(){RotateSwitch(lightToggle.PositionLightsOn, positionSwitchMesh);}
    void UpdatePositionLights(){
        if(lightToggle.PositionLightsOn && power.Enabled){
            positionMeshRendererLeft.material.SetInt("_LightOn", 1);
            positionMeshRendererRight.material.SetInt("_LightOn", 1);
        }
        else{
            positionMeshRendererLeft.material.SetInt("_LightOn", 0);
            positionMeshRendererRight.material.SetInt("_LightOn", 0);
        }
        positionLights.SetActive(lightToggle.PositionLightsOn && power.Enabled);
    }

    void AnimateStrobeSwitch(){RotateSwitch(lightToggle.StrobeLightsOn, strobeSwitchMesh);}
    void UpdateStrobeLights(){
        if(lightToggle.StrobeLightsOn && power.Enabled){
            strobeMeshRenderer.material.SetInt("_LightOn", 1);
        }
        else{
            strobeMeshRenderer.material.SetInt("_LightOn", 0);
        }
        strobeLights.SetActive(lightToggle.StrobeLightsOn && power.Enabled);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    void RotateSwitch(bool on, GameObject switchMesh){
        if(on == true) {switchMesh.transform.Rotate( 60, 0, 0);}
        if(on == false){switchMesh.transform.Rotate(-60, 0, 0);}
    }
}
