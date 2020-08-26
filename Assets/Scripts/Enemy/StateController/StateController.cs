/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;

public class StateController : MonoBehaviour{
    StateCombat _combatState;
    PowerToggleSystem _power;
    [SerializeField]GameObject _target;
    
    // bool shipInRange;
    // bool shipIsHostile;
    Vector3 _targetRelativePosition;
    
    void Awake(){
        _combatState = GetComponent<StateCombat>();
        _power = GetComponent<PowerToggleSystem>();
    }

    void Start(){_power.TogglePower();}

    public void Update(){
        // get targets position relative to this gameObject(this gameObject would be at 0,0,0)
        _targetRelativePosition = transform.InverseTransformPoint(_target.transform.position);
        _combatState.Engage(_targetRelativePosition);
    }
}