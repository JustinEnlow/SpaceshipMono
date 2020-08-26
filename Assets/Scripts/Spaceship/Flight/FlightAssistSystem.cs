using UnityEngine;
using Nlo.Math;

//namespace Nlo.Flight{
    public class FlightAssistSystem : MonoBehaviour{
        Rigidbody _rb;
        ShipStats _stats;
        PowerToggleSystem _power;
        FlightAssistToggleSystem _assist;
        InputController _input;
        PID _pid;
        
        [SerializeField]Vector3 LinearVelocity, AngularVelocity;
        float LateralInput, VerticalInput, LongitudinalInput;
        float PitchInput, YawInput, RollInput;
        float LinearOutputX, LinearOutputY, LinearOutputZ;
        float AngularOutputX, AngularOutputY, AngularOutputZ;
        float LinearErrorX, LinearErrorY, LinearErrorZ;
        float AngularErrorX, AngularErrorY, AngularErrorZ;
        float LinearIntegralX, LinearIntegralY, LinearIntegralZ;
        float AngularIntegralX, AngularIntegralY, AngularIntegralZ;

        void Awake(){
            _rb = GetComponent<Rigidbody>();
            _stats = GetComponent<ShipStats>();
            _power = GetComponent<PowerToggleSystem>();
            _assist = GetComponent<FlightAssistToggleSystem>();
            _input = GetComponentInChildren<InputController>();
            _pid = new PID(Time.fixedDeltaTime);
        }
        void OnEnable(){
            _input.OnLateralInputChanged += UpdateLateralInput;
            _input.OnVerticalInputChanged += UpdateVerticalInput;
            _input.OnLongitudinalInputChanged += UpdateLongitudinalInput;
            _input.OnPitchInputChanged += UpdatePitchInput;
            _input.OnYawInputChanged += UpdateYawInput;
            _input.OnRollInputChanged += UpdateRollInput;
        }

        void UpdateLateralInput(float value){LateralInput = value;}
        void UpdateVerticalInput(float value){VerticalInput = value;}
        void UpdateLongitudinalInput(float value){LongitudinalInput = value;}
        void UpdatePitchInput(float value){PitchInput = value;}
        void UpdateYawInput(float value){YawInput = value;}
        void UpdateRollInput(float value){RollInput = value;}

        void FixedUpdate(){
            if(_power.On == false) return;
            
            // convert velocities from world space to local
            LinearVelocity = _rb.transform.InverseTransformVector(_rb.velocity);
            AngularVelocity = _rb.transform.InverseTransformVector(_rb.angularVelocity) * (180 / Mathf.PI);

            /*
            Target velocity is specified by multiplying max velocity by player input
            The pid controller determines how much output we need to feed to the thrust system to reduce the difference between target 
            velocity and current velocity
            */
            if(_assist.TranslationAssistEnabled){
                _pid.Calculate(_stats.LateralMaxVelocity * LateralInput, LinearVelocity.x, 
                    LinearErrorX, LinearIntegralX, _stats.LinearGainX);
                LinearOutputX = Clamp.Float((_pid.GetOutput() / _stats.LateralMaxVelocity), -1f, 1f);
                LinearErrorX = _pid.GetError();
                LinearIntegralX = _pid.GetIntegral();
                    
                _pid.Calculate(_stats.VerticalMaxVelocity * VerticalInput, LinearVelocity.y, 
                    LinearErrorY, LinearIntegralY, _stats.LinearGainY);
                LinearOutputY = Clamp.Float((_pid.GetOutput() / _stats.VerticalMaxVelocity), -1f, 1f);
                LinearErrorY = _pid.GetError();
                LinearIntegralY = _pid.GetIntegral();
                    
                _pid.Calculate(_stats.LongitudinalMaxVelocity * LongitudinalInput, LinearVelocity.z, 
                    LinearErrorZ, LinearIntegralZ, _stats.LinearGainZ);
                LinearOutputZ = Clamp.Float((_pid.GetOutput() / _stats.LongitudinalMaxVelocity), -1f, 1f);
                LinearErrorZ = _pid.GetError();
                LinearIntegralZ = _pid.GetIntegral();
            }
            /*
            player input directly controls thrust output, unless max velocity is reached. player must manually apply acceleration to 
            nullify velocity on a given axis
            */
            else{
                LinearOutputX = LateralInput;
                LinearOutputY = VerticalInput;
                LinearOutputZ = LongitudinalInput;

                    //prevent ship from exceeding max velocity
                if(LinearVelocity.x >=  _stats.LateralMaxVelocity && LateralInput > 0){LinearOutputX = 0;}
                if(LinearVelocity.x <= -_stats.LateralMaxVelocity && LateralInput < 0){LinearOutputX = 0;}
                    
                if(LinearVelocity.y >=  _stats.VerticalMaxVelocity && VerticalInput > 0){LinearOutputY = 0;}
                if(LinearVelocity.y <= -_stats.VerticalMaxVelocity && VerticalInput < 0){LinearOutputY = 0;}
                    
                if(LinearVelocity.z >=  _stats.LongitudinalMaxVelocity && LongitudinalInput > 0){LinearOutputZ = 0;}
                if(LinearVelocity.z <= -_stats.LongitudinalMaxVelocity && LongitudinalInput < 0){LinearOutputZ = 0;}        
            }
                
            if(_assist.RotationAssistEnabled){
                _pid.Calculate(_stats.PitchMaxVelocity * PitchInput, AngularVelocity.x, 
                    AngularErrorX, AngularIntegralX, _stats.AngularGainX);
                AngularOutputX = Clamp.Float((_pid.GetOutput() / _stats.PitchMaxVelocity), -1f, 1f);
                AngularErrorX = _pid.GetError();
                AngularIntegralX = _pid.GetIntegral();
                    
                _pid.Calculate(_stats.YawMaxVelocity * YawInput, AngularVelocity.y, 
                    AngularErrorY, AngularIntegralY, _stats.AngularGainY);
                AngularOutputY = Clamp.Float((_pid.GetOutput() / _stats.YawMaxVelocity), -1f, 1f);
                AngularErrorY = _pid.GetError();
                AngularIntegralY = _pid.GetIntegral();
                    
                _pid.Calculate(_stats.RollMaxVelocity * RollInput, AngularVelocity.z, 
                    AngularErrorZ, AngularIntegralZ, _stats.AngularGainZ);
                AngularOutputZ = Clamp.Float((_pid.GetOutput() / _stats.RollMaxVelocity), -1f, 1f);
                AngularErrorZ = _pid.GetError();
                AngularIntegralZ = _pid.GetIntegral();
            }
            else{
                AngularOutputX = PitchInput;
                AngularOutputY = YawInput;
                AngularOutputZ = RollInput;
                    
                if(AngularVelocity.x >=  _stats.PitchMaxVelocity && PitchInput > 0){AngularOutputX = 0;}
                if(AngularVelocity.x <= -_stats.PitchMaxVelocity && PitchInput < 0){AngularOutputX = 0;}
                    
                if(AngularVelocity.y >=  _stats.YawMaxVelocity && YawInput > 0){AngularOutputY = 0;}
                if(AngularVelocity.y <= -_stats.YawMaxVelocity && YawInput < 0){AngularOutputY = 0;}
                    
                if(AngularVelocity.z >=  _stats.RollMaxVelocity && RollInput > 0){AngularOutputZ = 0;}
                if(AngularVelocity.z <= -_stats.RollMaxVelocity && RollInput < 0){AngularOutputZ = 0;}
            }

            // output necessary values to unity physics system
            _rb.AddRelativeForce(
                LinearOutputX * _stats.LateralDesiredThrust, 
                LinearOutputY * _stats.VerticalDesiredThrust, 
                LinearOutputZ * _stats.LongitudinalDesiredThrust, 
                ForceMode.Force);
            _rb.AddRelativeTorque(
                AngularOutputX * _stats.PitchDesiredThrust, 
                AngularOutputY * _stats.YawDesiredThrust, 
                AngularOutputZ * _stats.RollDesiredThrust, 
                ForceMode.Force);
        }
    }
//}