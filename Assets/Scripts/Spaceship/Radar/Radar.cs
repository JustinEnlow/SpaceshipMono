using UnityEngine;

public class Radar : MonoBehaviour{ // all radar objects should be on "3dRadar" layer
    // we set baseBlipPrefab here so that we dont have to assign it on each RadarObject
    Ship ship;
    [SerializeField]GameObject _baseBlipPrefab;
    Vector3 _baseBlipLocalPosition;
    [SerializeField]Camera radarCam;
    [SerializeField]Transform radarCameraTilt;

    void Start(){
        ship = GetComponent<Ship>();

        ship.mfd.OnToggleRadarOrthoPersp += ToggleOrthoPersp;
        ship.mfd.OnRadarZoomIn += ZoomIn;
        ship.mfd.OnRadarZoomOut += ZoomOut;
        ship.mfd.OnRadarTiltUp += TiltUp;
        ship.mfd.OnRadarTiltDown += TiltDown;
    }

    void OnTriggerEnter(Collider other){
        var radarObject = other.transform.parent.GetComponentInChildren<RadarObject>();
        radarObject.EnableRadarMesh();
        radarObject.EnableTrackingLine();
        radarObject.CreateBaseBlip(_baseBlipPrefab);
    }
    
    void OnTriggerStay(Collider other){// called every physics step for each Collider other
        var otherLocalPosition = transform.InverseTransformPoint(other.transform.position);
        
        _baseBlipLocalPosition.x = otherLocalPosition.x;
        _baseBlipLocalPosition.y = 0f;
        _baseBlipLocalPosition.z = otherLocalPosition.z;

        var baseBlipWorldPosition = transform.TransformPoint(_baseBlipLocalPosition);
        ////////////////////////////////////////////////////////////////////////////////////
        var radarObject = other.transform.parent.GetComponentInChildren<RadarObject>();
        radarObject.UpdateTrackingLinePosition(baseBlipWorldPosition);
        radarObject.UpdateBaseBlipPosition(baseBlipWorldPosition, transform.rotation);
    }
    
    void OnTriggerExit(Collider other){
        var radarObject = other.transform.parent.GetComponentInChildren<RadarObject>();
        radarObject.DisableRadarMesh();
        radarObject.DisableTrackingLine();
        radarObject.DestroyBaseBlip();
    }

    void ToggleOrthoPersp(){radarCam.orthographic = !radarCam.orthographic;}
    void ZoomOut(){
        radarCam.orthographicSize += 5.0f;
        radarCam.fieldOfView += 2.5f;
    }
    void ZoomIn(){
        radarCam.orthographicSize -= 5.0f;
        radarCam.fieldOfView -= 2.5f;
    }
    void TiltDown(){radarCameraTilt.Rotate(Vector3.right * -2);}
    void TiltUp(){radarCameraTilt.Rotate(Vector3.right * 2);}
}