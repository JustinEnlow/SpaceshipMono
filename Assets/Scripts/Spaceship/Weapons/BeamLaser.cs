using System.Collections;
using UnityEngine;

public class BeamLaser : MonoBehaviour, IWeapon{
    Ship ship;
    LineRenderer _line;
    bool _firing;

    void Awake(){
        ship = GetComponentInParent<Ship>();
        
        _line = GetComponent<LineRenderer>();

        _line.startWidth = .1f;
        _line.endWidth = .1f;
        _line.positionCount = 2;
        _line.enabled = false;
    }
    void OnEnable(){
        ship.input.OnFireWeapons += Fire;
        ship.input.OnStopFiringWeapons += StopFiring;
    }

    public void Fire(){_firing = true;}
    public void StopFiring(){_firing = false;}

    public void Update(){
        if(ship.power.On && ship.masterArm.Armed && _firing){StartCoroutine("FireWeapon");}
        else{StopCoroutine("FireWeapon"); _line.enabled = false;}
    }

    IEnumerator FireWeapon(){
        while(true){
            _line.enabled = true;
		    Ray ray = new Ray(transform.position, transform.forward);
		    RaycastHit hit;
		
		    _line.SetPosition(0, transform.position);
		    if(Physics.Raycast(ray, out hit, ship.stats.ShootDistance)){
                Debug.DrawRay(transform.position, transform.TransformDirection
                    (Vector3.forward) * hit.distance, Color.yellow);
                _line.SetPosition(1, hit.point);
                
                hit.collider.gameObject.GetComponentInParent<IHaveHealth>().ModifyHealth(
                    -ship.stats.DamageAmount * Time.deltaTime);
		    }
		    else{_line.SetPosition(1, ray.GetPoint(ship.stats.ShootDistance));}

            yield return null;
        }
    }
}