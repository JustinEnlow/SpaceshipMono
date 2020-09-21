using UnityEngine;

public class FighterAnimation : MonoBehaviour{
    Ship ship;

    [SerializeField]GameObject PowerSwitchMesh;
    [SerializeField]GameObject MasterArmSwitchMesh;
    [SerializeField]GameObject floodSwitchMesh, positionSwitchMesh, strobeSwitchMesh;
    [SerializeField]GameObject floodLights, positionLights, strobeLights;
    [SerializeField]Renderer positionMeshRendererLeft, positionMeshRendererRight;
    [SerializeField]Renderer strobeMeshRenderer;


    public void Initialize(Ship ship){this.ship = ship;}
    public void Enable(){
        ship.power.OnPowerToggled += AnimatePowerSwitch;
        ship.masterArm.OnMasterArmToggled += AnimateMasterArmSwitch;
        ship.lightToggle.OnFloodLightsToggled += AnimateFloodSwitch;
        ship.lightToggle.OnFloodLightsToggled += UpdateFloodLights;
        ship.lightToggle.OnPositionLightsToggled += AnimatePositionSwitch;
        ship.lightToggle.OnPositionLightsToggled += UpdatePositionLights;
        ship.lightToggle.OnStrobeLightsToggled += AnimateStrobeSwitch;
        ship.lightToggle.OnStrobeLightsToggled += UpdateStrobeLights;
    }

    void AnimatePowerSwitch(){
        RotateSwitch(ship.power.Enabled, PowerSwitchMesh);

        UpdateFloodLights();
        UpdatePositionLights();
        UpdateStrobeLights();
    }

    void AnimateMasterArmSwitch(){RotateSwitch(ship.masterArm.Enabled, MasterArmSwitchMesh);}

    void AnimateFloodSwitch(){RotateSwitch(ship.lightToggle.FloodLightsOn, floodSwitchMesh);}
    void UpdateFloodLights(){floodLights.SetActive(ship.lightToggle.FloodLightsOn && ship.power.Enabled);}
    
    void AnimatePositionSwitch(){RotateSwitch(ship.lightToggle.PositionLightsOn, positionSwitchMesh);}
    void UpdatePositionLights(){
        if(ship.lightToggle.PositionLightsOn && ship.power.Enabled){
            positionMeshRendererLeft.material.SetInt("_LightOn", 1);
            positionMeshRendererRight.material.SetInt("_LightOn", 1);
        }
        else{
            positionMeshRendererLeft.material.SetInt("_LightOn", 0);
            positionMeshRendererRight.material.SetInt("_LightOn", 0);
        }
        positionLights.SetActive(ship.lightToggle.PositionLightsOn && ship.power.Enabled);
    }

    void AnimateStrobeSwitch(){RotateSwitch(ship.lightToggle.StrobeLightsOn, strobeSwitchMesh);}
    void UpdateStrobeLights(){
        if(ship.lightToggle.StrobeLightsOn && ship.power.Enabled){
            strobeMeshRenderer.material.SetInt("_LightOn", 1);
        }
        else{
            strobeMeshRenderer.material.SetInt("_LightOn", 0);
        }
        strobeLights.SetActive(ship.lightToggle.StrobeLightsOn && ship.power.Enabled);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    void RotateSwitch(bool on, GameObject switchMesh){
        if(on == true) {switchMesh.transform.Rotate( 60, 0, 0);}
        if(on == false){switchMesh.transform.Rotate(-60, 0, 0);}
    }
}
