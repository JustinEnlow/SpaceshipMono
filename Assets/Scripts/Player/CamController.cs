/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;
using UnityEngine.XR;

public class CamController : MonoBehaviour {
    #region
    [SerializeField]Camera firstPersonCam;
    [SerializeField]Camera thirdPersonCam;
    [SerializeField]Transform firstPersonHorizontal;
    [SerializeField]Transform thirdPersonHorizontal;
    [SerializeField]Transform thirdPersonVertical;
    [SerializeField]Camera vrCamera;
    XRInputSubsystem xr;
    InputController _input;
    
    float horizontal = 0;
    float vertical = 0;
    [SerializeField]float rotationSpeed = 1f;
    bool useVR = false;
    #endregion
    
    void Awake(){
        _input = gameObject.GetComponent<InputController>();
        ///lock cursor to screen
        Cursor.lockState = CursorLockMode.Locked;
        // check if using VR headset
        if(XRSettings.isDeviceActive == true){
            vrCamera.enabled = true;
            firstPersonCam.enabled = false;
            thirdPersonCam.enabled = false;
            
            useVR = true;
        }
        else{
            firstPersonCam.enabled = true;
            thirdPersonCam.enabled = false;
        }
    }

    void OnEnable(){
        _input.OnToggleCamera += ToggleCamera;
        _input.OnCameraHorizontalChanged += RotateCameraHorizontal;
        _input.OnCameraVerticalChanged += RotateCameraVertical;
        _input.OnResetCameraRotation += ResetCameraRotation;
        _input.OnRecenterVR += RecenterVR;
    }
    void OnDisable(){
        _input.OnToggleCamera -= ToggleCamera;
        _input.OnCameraHorizontalChanged -= RotateCameraHorizontal;
        _input.OnCameraVerticalChanged -= RotateCameraVertical;
        _input.OnResetCameraRotation -= ResetCameraRotation;
        _input.OnRecenterVR -= RecenterVR;
    }
    
    void ToggleCamera(){
        if(useVR == false){
            firstPersonCam.enabled = !firstPersonCam.enabled;
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
        }
    }
    
    void RotateCameraHorizontal(float value){
        horizontal = value;
        if(useVR){firstPersonHorizontal.Rotate(0, horizontal * rotationSpeed, 0);}
        else{
            if(firstPersonCam.enabled == true){firstPersonHorizontal.Rotate(0, horizontal * rotationSpeed, 0);}
            else{thirdPersonHorizontal.Rotate(0, -horizontal * rotationSpeed, 0);}
        }
    }
    
    void RotateCameraVertical(float value){
        vertical = value;
        if(useVR){firstPersonCam.transform.Rotate(-vertical * rotationSpeed, 0, 0);}
        else{
            if(firstPersonCam.enabled == true){firstPersonCam.transform.Rotate(-vertical * rotationSpeed, 0, 0);}
            else{thirdPersonVertical.Rotate(vertical * rotationSpeed, 0, 0);}
        }
    }
    
    void ResetCameraRotation(){
        if(firstPersonCam.enabled == true){
            firstPersonHorizontal.localEulerAngles = Vector3.zero;
            firstPersonCam.transform.localEulerAngles = Vector3.zero;
        }
        else{
            thirdPersonHorizontal.localEulerAngles = Vector3.zero;
            thirdPersonVertical.localEulerAngles = Vector3.zero;
        }
    }
    
    void RecenterVR(){if(useVR){xr.TryRecenter();}}
}