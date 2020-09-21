using System.Collections;
using UnityEngine;
using Nlo.Spaceship.Interfaces;

public class BeamLaser : MonoBehaviour, IWeapon{
    LineRenderer _line;

    void Awake(){
        _line = GetComponent<LineRenderer>();

        _line.startWidth = .1f;
        _line.endWidth = .1f;
        _line.positionCount = 2;
        _line.enabled = false;
    }

    public void Fire(){StartCoroutine("FireWeapon");}
    public void StopFiring(){
        StopCoroutine("FireWeapon");
        _line.enabled = false;
    }

    IEnumerator FireWeapon(){
        while(true){
            _line.enabled = true;
		    Ray ray = new Ray(transform.position, transform.forward);
		    RaycastHit hit;
		
		    _line.SetPosition(0, transform.position);
		    if(Physics.Raycast(ray, out hit, 100f/*ship.stats.ShootDistance*/)){
                Debug.DrawRay(transform.position, transform.TransformDirection
                    (Vector3.forward) * hit.distance, Color.yellow);
                _line.SetPosition(1, hit.point);
                
                //hit.collider.gameObject.GetComponentInParent<IHaveHealth>().ModifyHealth(
                //    -ship.stats.DamageAmount * Time.deltaTime);
		    }
		    else{_line.SetPosition(1, ray.GetPoint(100f/*ship.stats.ShootDistance*/));}

            yield return null;
        }
    }
}