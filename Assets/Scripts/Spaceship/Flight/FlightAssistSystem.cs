using UnityEngine;
using Nlo.Math;

//namespace Nlo.Flight{
    public class FlightAssistSystem{
        Rigidbody rb;
        ShipStats stats;
        PowerToggleSystem power;
        FlightAssistToggleSystem assist;
        InputController input;
        PID pid;
        
        [SerializeField]Vector3 LinearVelocity, AngularVelocity;
        float LateralInput, VerticalInput, LongitudinalInput;
        float PitchInput, YawInput, RollInput;
        float LinearOutputX, LinearOutputY, LinearOutputZ;
        float AngularOutputX, AngularOutputY, AngularOutputZ;
        float LinearErrorX, LinearErrorY, LinearErrorZ;
        float AngularErrorX, AngularErrorY, AngularErrorZ;
        float LinearIntegralX, LinearIntegralY, LinearIntegralZ;
        float AngularIntegralX, AngularIntegralY, AngularIntegralZ;

        const float _radiansToDegreesMultiplier = (180 / Mathf.PI);

        public FlightAssistSystem(Rigidbody rb, ShipStats stats, PowerToggleSystem power, FlightAssistToggleSystem assist,
            InputController input, float deltaTime){

            this.rb = rb;
            this.stats = stats;
            this.power = power;
            this.assist = assist;
            this.input = input;
            pid = new PID();

            input.OnLateralInputChanged += UpdateLateralInput;
            input.OnVerticalInputChanged += UpdateVerticalInput;
            input.OnLongitudinalInputChanged += UpdateLongitudinalInput;
            input.OnPitchInputChanged += UpdatePitchInput;
            input.OnYawInputChanged += UpdateYawInput;
            input.OnRollInputChanged += UpdateRollInput;
        }

        void UpdateLateralInput(float value){LateralInput = value;}
        void UpdateVerticalInput(float value){VerticalInput = value;}
        void UpdateLongitudinalInput(float value){LongitudinalInput = value;}
        void UpdatePitchInput(float value){PitchInput = value;}
        void UpdateYawInput(float value){YawInput = value;}
        void UpdateRollInput(float value){RollInput = value;}

        public void Process(float deltaTime){
            if(power.On == false) return;
            
            // convert velocities from world space to local
            LinearVelocity = rb.transform.InverseTransformVector(rb.velocity);
                //use degrees instead of radians
            AngularVelocity = rb.transform.InverseTransformVector(rb.angularVelocity) * _radiansToDegreesMultiplier;

            /*
            Target velocity is specified by multiplying max velocity by player input
            The pid controller determines how much output we need to feed to the thrust system to reduce the difference between target 
            velocity and current velocity
            */
            if(assist.TranslationAssistEnabled){
                pid.Calculate(stats.LateralMaxVelocity * LateralInput, LinearVelocity.x, 
                    LinearErrorX, LinearIntegralX, stats.LinearGainX, deltaTime);
                LinearOutputX = Clamp.Float((pid.Output / stats.LateralMaxVelocity), -1f, 1f);
                LinearErrorX = pid.Error;
                LinearIntegralX = pid.Integral;
                    
                pid.Calculate(stats.VerticalMaxVelocity * VerticalInput, LinearVelocity.y, 
                    LinearErrorY, LinearIntegralY, stats.LinearGainY, deltaTime);
                LinearOutputY = Clamp.Float((pid.Output / stats.VerticalMaxVelocity), -1f, 1f);
                LinearErrorY = pid.Error;
                LinearIntegralY = pid.Integral;
                    
                pid.Calculate(stats.LongitudinalMaxVelocity * LongitudinalInput, LinearVelocity.z, 
                    LinearErrorZ, LinearIntegralZ, stats.LinearGainZ, deltaTime);
                LinearOutputZ = Clamp.Float((pid.Output / stats.LongitudinalMaxVelocity), -1f, 1f);
                LinearErrorZ = pid.Error;
                LinearIntegralZ = pid.Integral;
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
                if(LinearVelocity.x >=  stats.LateralMaxVelocity && LateralInput > 0){LinearOutputX = 0;}
                if(LinearVelocity.x <= -stats.LateralMaxVelocity && LateralInput < 0){LinearOutputX = 0;}
                    
                if(LinearVelocity.y >=  stats.VerticalMaxVelocity && VerticalInput > 0){LinearOutputY = 0;}
                if(LinearVelocity.y <= -stats.VerticalMaxVelocity && VerticalInput < 0){LinearOutputY = 0;}
                    
                if(LinearVelocity.z >=  stats.LongitudinalMaxVelocity && LongitudinalInput > 0){LinearOutputZ = 0;}
                if(LinearVelocity.z <= -stats.LongitudinalMaxVelocity && LongitudinalInput < 0){LinearOutputZ = 0;}        
            }
                
            if(assist.RotationAssistEnabled){
                pid.Calculate(stats.PitchMaxVelocity * PitchInput, AngularVelocity.x, 
                    AngularErrorX, AngularIntegralX, stats.AngularGainX, deltaTime);
                AngularOutputX = Clamp.Float((pid.Output / stats.PitchMaxVelocity), -1f, 1f);
                AngularErrorX = pid.Error;
                AngularIntegralX = pid.Integral;
                    
                pid.Calculate(stats.YawMaxVelocity * YawInput, AngularVelocity.y, 
                    AngularErrorY, AngularIntegralY, stats.AngularGainY, deltaTime);
                AngularOutputY = Clamp.Float((pid.Output / stats.YawMaxVelocity), -1f, 1f);
                AngularErrorY = pid.Error;
                AngularIntegralY = pid.Integral;
                    
                pid.Calculate(stats.RollMaxVelocity * RollInput, AngularVelocity.z, 
                    AngularErrorZ, AngularIntegralZ, stats.AngularGainZ, deltaTime);
                AngularOutputZ = Clamp.Float((pid.Output / stats.RollMaxVelocity), -1f, 1f);
                AngularErrorZ = pid.Error;
                AngularIntegralZ = pid.Integral;
            }
            else{
                AngularOutputX = PitchInput;
                AngularOutputY = YawInput;
                AngularOutputZ = RollInput;
                    
                if(AngularVelocity.x >=  stats.PitchMaxVelocity && PitchInput > 0){AngularOutputX = 0;}
                if(AngularVelocity.x <= -stats.PitchMaxVelocity && PitchInput < 0){AngularOutputX = 0;}
                    
                if(AngularVelocity.y >=  stats.YawMaxVelocity && YawInput > 0){AngularOutputY = 0;}
                if(AngularVelocity.y <= -stats.YawMaxVelocity && YawInput < 0){AngularOutputY = 0;}
                    
                if(AngularVelocity.z >=  stats.RollMaxVelocity && RollInput > 0){AngularOutputZ = 0;}
                if(AngularVelocity.z <= -stats.RollMaxVelocity && RollInput < 0){AngularOutputZ = 0;}
            }

            // output necessary values to unity physics system
            rb.AddRelativeForce(
                LinearOutputX * stats.LateralDesiredThrust, 
                LinearOutputY * stats.VerticalDesiredThrust, 
                LinearOutputZ * stats.LongitudinalDesiredThrust, 
                ForceMode.Force);
            rb.AddRelativeTorque(
                AngularOutputX * stats.PitchDesiredThrust, 
                AngularOutputY * stats.YawDesiredThrust, 
                AngularOutputZ * stats.RollDesiredThrust, 
                ForceMode.Force);
        }
    }
//}