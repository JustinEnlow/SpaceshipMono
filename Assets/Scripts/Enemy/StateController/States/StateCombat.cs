/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;
using Nlo.Spaceship.Math;

public class StateCombat : MonoBehaviour{
    //FlightController _flight;
    
    float _pitch;
    float _yaw;
    float _roll;
    float _longitudinal = 0;
    float _lateral;
    float _vertical;
    [SerializeField]float _close = 10f;
    
    void Awake(){
        //_flight = GetComponent<FlightController>();
    }

    public void  Engage(Vector3 targetRelativePosition){
        _lateral = 0;
        _vertical = 0;
        // if target relative position is farther than 10(_close) meters away, fly toward it.
        _longitudinal = targetRelativePosition.z - _close;
        _longitudinal = Clamp.Float(_longitudinal, -1, 1);
        // if target relative position is above our position, _pitch up. if below, _pitch down
        _pitch = targetRelativePosition.y;
        _pitch = Clamp.Float(_pitch, -1, 1);
        // if target relative position to right of our position, _yaw right. if left, _yaw left
        _yaw = targetRelativePosition.x;
        _yaw = Clamp.Float(_yaw, -1, 1);
        
        _roll = 0;
        
        //_flight.Lateral = _lateral;
        //_flight.Vertical = _vertical;
        //_flight.Longitudinal = _longitudinal;
        //_flight.Pitch = -_pitch;
        //_flight.Yaw = _yaw;
        //_flight.Roll = -_roll;
    }
}