using UnityEngine;

public class RadarObject : MonoBehaviour{  //Add to every Object that can appear on radar
    [SerializeField]GameObject _blipMesh;
    GameObject _baseBlip;
    [SerializeField]LineRenderer _lineRenderer;
    void Start(){
        _lineRenderer.alignment = LineAlignment.View;
        //_lineRenderer.material = new Material(Shader.Find("Standard"));
        _lineRenderer.generateLightingData = false;
        _lineRenderer.startWidth = .5f;
        _lineRenderer.endWidth = .5f;
        _lineRenderer.startColor = Color.cyan;
        _lineRenderer.endColor = Color.cyan;
        _lineRenderer.useWorldSpace = true;
        _lineRenderer.positionCount = 2;
    }

    public void EnableRadarMesh(){_blipMesh.SetActive(true);}
    public void DisableRadarMesh(){_blipMesh.SetActive(false);}

    public void EnableTrackingLine(){_lineRenderer.enabled = true;}
    public void DisableTrackingLine(){_lineRenderer.enabled = false;}
    public void UpdateTrackingLinePosition(Vector3 baseBlipWorldPosition){
        _lineRenderer.SetPosition(0, gameObject.transform.position);
        _lineRenderer.SetPosition(1, baseBlipWorldPosition);
    }

    public void CreateBaseBlip(GameObject baseBlip){
        // _baseBlip is baseBlip prefab as child of this gameObject
        _baseBlip = Instantiate(baseBlip, this.gameObject.transform);
    }
    public void DestroyBaseBlip(){Destroy(_baseBlip);}
    public void UpdateBaseBlipPosition(Vector3 baseBlipWorldPosition, Quaternion baseBlipWorldRotation){
        _baseBlip.transform.position = baseBlipWorldPosition;
        _baseBlip.transform.rotation = baseBlipWorldRotation;
    }
}