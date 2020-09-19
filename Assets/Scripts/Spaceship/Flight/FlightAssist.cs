using UnityEngine;
using Nlo.Math;

//namespace Nlo.Flight{
    public class FlightAssist{
        Ship ship;
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

        public FlightAssist(Ship ship){
            this.ship = ship;
            pid = new PID();

            this.ship.input.OnLateralInputChanged += UpdateLateralInput;
            this.ship.input.OnVerticalInputChanged += UpdateVerticalInput;
            this.ship.input.OnLongitudinalInputChanged += UpdateLongitudinalInput;
            this.ship.input.OnPitchInputChanged += UpdatePitchInput;
            this.ship.input.OnYawInputChanged += UpdateYawInput;
            this.ship.input.OnRollInputChanged += UpdateRollInput;
        }

        void UpdateLateralInput(float value){LateralInput = value;}
        void UpdateVerticalInput(float value){VerticalInput = value;}
        void UpdateLongitudinalInput(float value){LongitudinalInput = value;}
        void UpdatePitchInput(float value){PitchInput = value;}
        void UpdateYawInput(float value){YawInput = value;}
        void UpdateRollInput(float value){RollInput = value;}

        public void Process(float deltaTime){
            if(ship.power.Enabled == false) return;
            
            // convert velocities from world space to local
            LinearVelocity = ship.rb.transform.InverseTransformVector(ship.rb.velocity);
                //use degrees instead of radians
            AngularVelocity = ship.rb.transform.InverseTransformVector(ship.rb.angularVelocity) * _radiansToDegreesMultiplier;

            /*
            Target velocity is specified by multiplying max velocity by player input
            The pid controller determines how much output we need to feed to the thrust system to reduce the difference between target 
            velocity and current velocity
            */
            if(ship.assistToggle.TranslationAssistEnabled){
                pid.Calculate(ship.stats.LateralMaxVelocity * LateralInput, LinearVelocity.x, 
                    LinearErrorX, LinearIntegralX, ship.stats.LinearGainX, deltaTime);
                LinearOutputX = Clamp.Float((pid.Output / ship.stats.LateralMaxVelocity), -1f, 1f);
                LinearErrorX = pid.Error;
                LinearIntegralX = pid.Integral;
                    
                pid.Calculate(ship.stats.VerticalMaxVelocity * VerticalInput, LinearVelocity.y, 
                    LinearErrorY, LinearIntegralY, ship.stats.LinearGainY, deltaTime);
                LinearOutputY = Clamp.Float((pid.Output / ship.stats.VerticalMaxVelocity), -1f, 1f);
                LinearErrorY = pid.Error;
                LinearIntegralY = pid.Integral;
                    
                pid.Calculate(ship.stats.LongitudinalMaxVelocity * LongitudinalInput, LinearVelocity.z, 
                    LinearErrorZ, LinearIntegralZ, ship.stats.LinearGainZ, deltaTime);
                LinearOutputZ = Clamp.Float((pid.Output / ship.stats.LongitudinalMaxVelocity), -1f, 1f);
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
                if(LinearVelocity.x >=  ship.stats.LateralMaxVelocity && LateralInput > 0){LinearOutputX = 0;}
                if(LinearVelocity.x <= -ship.stats.LateralMaxVelocity && LateralInput < 0){LinearOutputX = 0;}
                    
                if(LinearVelocity.y >=  ship.stats.VerticalMaxVelocity && VerticalInput > 0){LinearOutputY = 0;}
                if(LinearVelocity.y <= -ship.stats.VerticalMaxVelocity && VerticalInput < 0){LinearOutputY = 0;}
                    
                if(LinearVelocity.z >=  ship.stats.LongitudinalMaxVelocity && LongitudinalInput > 0){LinearOutputZ = 0;}
                if(LinearVelocity.z <= -ship.stats.LongitudinalMaxVelocity && LongitudinalInput < 0){LinearOutputZ = 0;}        
            }
                
            if(ship.assistToggle.RotationAssistEnabled){
                pid.Calculate(ship.stats.PitchMaxVelocity * PitchInput, AngularVelocity.x, 
                    AngularErrorX, AngularIntegralX, ship.stats.AngularGainX, deltaTime);
                AngularOutputX = Clamp.Float((pid.Output / ship.stats.PitchMaxVelocity), -1f, 1f);
                AngularErrorX = pid.Error;
                AngularIntegralX = pid.Integral;
                    
                pid.Calculate(ship.stats.YawMaxVelocity * YawInput, AngularVelocity.y, 
                    AngularErrorY, AngularIntegralY, ship.stats.AngularGainY, deltaTime);
                AngularOutputY = Clamp.Float((pid.Output / ship.stats.YawMaxVelocity), -1f, 1f);
                AngularErrorY = pid.Error;
                AngularIntegralY = pid.Integral;
                    
                pid.Calculate(ship.stats.RollMaxVelocity * RollInput, AngularVelocity.z, 
                    AngularErrorZ, AngularIntegralZ, ship.stats.AngularGainZ, deltaTime);
                AngularOutputZ = Clamp.Float((pid.Output / ship.stats.RollMaxVelocity), -1f, 1f);
                AngularErrorZ = pid.Error;
                AngularIntegralZ = pid.Integral;
            }
            else{
                AngularOutputX = PitchInput;
                AngularOutputY = YawInput;
                AngularOutputZ = RollInput;
                    
                if(AngularVelocity.x >=  ship.stats.PitchMaxVelocity && PitchInput > 0){AngularOutputX = 0;}
                if(AngularVelocity.x <= -ship.stats.PitchMaxVelocity && PitchInput < 0){AngularOutputX = 0;}
                    
                if(AngularVelocity.y >=  ship.stats.YawMaxVelocity && YawInput > 0){AngularOutputY = 0;}
                if(AngularVelocity.y <= -ship.stats.YawMaxVelocity && YawInput < 0){AngularOutputY = 0;}
                    
                if(AngularVelocity.z >=  ship.stats.RollMaxVelocity && RollInput > 0){AngularOutputZ = 0;}
                if(AngularVelocity.z <= -ship.stats.RollMaxVelocity && RollInput < 0){AngularOutputZ = 0;}
            }

            // output necessary values to unity physics system
            ship.rb.AddRelativeForce(
                LinearOutputX * ship.stats.LateralDesiredThrust, 
                LinearOutputY * ship.stats.VerticalDesiredThrust, 
                LinearOutputZ * ship.stats.LongitudinalDesiredThrust, 
                ForceMode.Force);
            ship.rb.AddRelativeTorque(
                AngularOutputX * ship.stats.PitchDesiredThrust, 
                AngularOutputY * ship.stats.YawDesiredThrust, 
                AngularOutputZ * ship.stats.RollDesiredThrust, 
                ForceMode.Force);
        }
    }
//}