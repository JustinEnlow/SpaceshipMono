using System.Collections;
using UnityEngine;

public class BeamLaser : MonoBehaviour, IWeapon{
    ShipStats _stats;
    PowerToggleSystem _power;
    MasterArmSystem _masterArm;
    [SerializeField]InputController _input;
    LineRenderer _line;
    bool _firing;

    void Start(){
        //var _ship = GetComponentInParent<ShipProcessExecutionController>();
        _stats = GetComponentInParent<ShipStats>();//_ship._stats;
        _power = GetComponentInParent<PowerToggleSystem>();
        _masterArm = GetComponentInParent<MasterArmSystem>();
        //_input = GetComponentInParent<InputController>();
        
        _line = GetComponent<LineRenderer>();

        _line.startWidth = .1f;
        _line.endWidth = .1f;
        _line.positionCount = 2;
        _line.enabled = false;
    }
    void OnEnable(){
        _input.OnFireWeapons += Fire;
        _input.OnStopFiringWeapons += StopFiring;
    }

    public void Fire(){_firing = true;}
    public void StopFiring(){_firing = false;}

    public void Update(){
        if(_power.On && _masterArm.Armed && _firing){StartCoroutine("FireWeapon");}
        else{StopCoroutine("FireWeapon"); _line.enabled = false;}
    }

    IEnumerator FireWeapon(){
        while(true){
            _line.enabled = true;
		    Ray ray = new Ray(transform.position, transform.forward);
		    RaycastHit hit;
		
		    _line.SetPosition(0, transform.position);
		    if(Physics.Raycast(ray, out hit, _stats.ShootDistance)){
                Debug.DrawRay(transform.position, transform.TransformDirection
                    (Vector3.forward) * hit.distance, Color.yellow);
                _line.SetPosition(1, hit.point);
                
                hit.collider.gameObject.GetComponentInParent<IHaveHealth>().ModifyHealth(
                    -_stats.DamageAmount * Time.deltaTime);
		    }
		    else{_line.SetPosition(1, ray.GetPoint(_stats.ShootDistance));}

            yield return null;
        }
    }
}