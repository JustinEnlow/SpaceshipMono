using UnityEngine;

public class FighterAnimationSystem : MonoBehaviour{
    PowerToggleSystem _power;
    MasterArmSystem _masterArm;
    LightToggleSystem _light;

    [SerializeField]GameObject PowerSwitchMesh;
    [SerializeField]GameObject MasterArmSwitchMesh;
    [SerializeField]GameObject floodSwitchMesh, positionSwitchMesh, strobeSwitchMesh;
    [SerializeField]GameObject floodLights, positionLights, strobeLights;
    [SerializeField]Renderer positionMeshRendererLeft, positionMeshRendererRight;
    [SerializeField]Renderer strobeMeshRenderer;

    void Awake(){
        _power = GetComponent<PowerToggleSystem>();
        _masterArm = GetComponent<MasterArmSystem>();
        _light = GetComponent<LightToggleSystem>();
    }
    void OnEnable(){
        _power.OnPowerToggled += AnimatePowerSwitch;
        _masterArm.OnMasterArmToggled += AnimateMasterArmSwitch;
        _light.OnFloodLightsToggled += AnimateFloodSwitch;
        _light.OnFloodLightsToggled += UpdateFloodLights;
        _light.OnPositionLightsToggled += AnimatePositionSwitch;
        _light.OnPositionLightsToggled += UpdatePositionLights;
        _light.OnStrobeLightsToggled += AnimateStrobeSwitch;
        _light.OnStrobeLightsToggled += UpdateStrobeLights;
    }

    void AnimatePowerSwitch(){
        RotateSwitch(_power.On, PowerSwitchMesh);

        UpdateFloodLights();
        UpdatePositionLights();
        UpdateStrobeLights();
    }

    void AnimateMasterArmSwitch(){
        RotateSwitch(_masterArm.Armed, MasterArmSwitchMesh);
    }

    void AnimateFloodSwitch(){RotateSwitch(_light.FloodLightsOn, floodSwitchMesh);}
    void UpdateFloodLights(){floodLights.SetActive(_light.FloodLightsOn && _power.On);}
    
    void AnimatePositionSwitch(){RotateSwitch(_light.PositionLightsOn, positionSwitchMesh);}
    void UpdatePositionLights(){
        if(_light.PositionLightsOn && _power.On){
            positionMeshRendererLeft.material.SetInt("_LightOn", 1);
            positionMeshRendererRight.material.SetInt("_LightOn", 1);
        }
        else{
            positionMeshRendererLeft.material.SetInt("_LightOn", 0);
            positionMeshRendererRight.material.SetInt("_LightOn", 0);
        }
        positionLights.SetActive(_light.PositionLightsOn && _power.On);
    }

    void AnimateStrobeSwitch(){RotateSwitch(_light.StrobeLightsOn, strobeSwitchMesh);}
    void UpdateStrobeLights(){
        if(_light.StrobeLightsOn && _power.On){
            strobeMeshRenderer.material.SetInt("_LightOn", 1);
        }
        else{
            strobeMeshRenderer.material.SetInt("_LightOn", 0);
        }
        strobeLights.SetActive(_light.StrobeLightsOn && _power.On);
    }

    void RotateSwitch(bool on, GameObject switchMesh){
        if(on == true) {switchMesh.transform.Rotate( 60, 0, 0);}
        if(on == false){switchMesh.transform.Rotate(-60, 0, 0);}
    }
}
