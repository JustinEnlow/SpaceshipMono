using Nlo.Math;

namespace Nlo.Spaceship{
    public class FlightAssist{
        ShipEventManager eventManager;
        PowerToggle power;
        FlightAssistToggle assistToggle;
        ShipStats stats;
        PID pid;
        
        float LateralInput, VerticalInput, LongitudinalInput;
        float PitchInput, YawInput, RollInput;
        float LinearErrorX, LinearErrorY, LinearErrorZ;
        float AngularErrorX, AngularErrorY, AngularErrorZ;
        float LinearIntegralX, LinearIntegralY, LinearIntegralZ;
        float AngularIntegralX, AngularIntegralY, AngularIntegralZ;
        public float LinearOutputX{get; private set;}
        public float LinearOutputY{get; private set;}
        public float LinearOutputZ{get; private set;}
        public float AngularOutputX{get; private set;}
        public float AngularOutputY{get; private set;}
        public float AngularOutputZ{get; private set;}

        public FlightAssist(ShipEventManager eventManager, PowerToggle power, FlightAssistToggle assistToggle, ShipStats stats){
            this.eventManager = eventManager;
            this.power = power;
            this.assistToggle = assistToggle;
            this.stats = stats;
            pid = new PID();

            this.eventManager.OnLateralInputChanged += UpdateLateralInput;
            this.eventManager.OnVerticalInputChanged += UpdateVerticalInput;
            this.eventManager.OnLongitudinalInputChanged += UpdateLongitudinalInput;
            this.eventManager.OnPitchInputChanged += UpdatePitchInput;
            this.eventManager.OnYawInputChanged += UpdateYawInput;
            this.eventManager.OnRollInputChanged += UpdateRollInput;
        }

        void UpdateLateralInput(float value){LateralInput = value;}
        void UpdateVerticalInput(float value){VerticalInput = value;}
        void UpdateLongitudinalInput(float value){LongitudinalInput = value;}
        void UpdatePitchInput(float value){PitchInput = value;}
        void UpdateYawInput(float value){YawInput = value;}
        void UpdateRollInput(float value){RollInput = value;}

        public void Calculate(float linearVelocityX, float linearVelocityY, float linearVelocityZ, float angularVelocityX,
            float angularVelocityY, float angularVelocityZ, float deltaTime){
            /*
            Target velocity is specified by multiplying max velocity by player input
            The pid controller determines how much output we need to feed to the thrust system to reduce the difference between target 
            velocity and current velocity
            */
            if(assistToggle.TranslationAssistEnabled){
                pid.Calculate(stats.LateralMaxVelocity * LateralInput, linearVelocityX,//LinearVelocity.x, 
                    LinearErrorX, LinearIntegralX, stats.LinearGainX, deltaTime);
                LinearOutputX = Clamp.Float((pid.Output / stats.LateralMaxVelocity), -1f, 1f);
                LinearErrorX = pid.Error;
                LinearIntegralX = pid.Integral;
                    
                pid.Calculate(stats.VerticalMaxVelocity * VerticalInput, linearVelocityY,//LinearVelocity.y, 
                    LinearErrorY, LinearIntegralY, stats.LinearGainY, deltaTime);
                LinearOutputY = Clamp.Float((pid.Output / stats.VerticalMaxVelocity), -1f, 1f);
                LinearErrorY = pid.Error;
                LinearIntegralY = pid.Integral;
                    
                pid.Calculate(stats.LongitudinalMaxVelocity * LongitudinalInput, linearVelocityZ,//LinearVelocity.z, 
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

                    //prevent from exceeding max velocity
                if(linearVelocityX >=  stats.LateralMaxVelocity && LateralInput > 0){LinearOutputX = 0;}
                if(linearVelocityX <= -stats.LateralMaxVelocity && LateralInput < 0){LinearOutputX = 0;}
                    
                if(linearVelocityY >=  stats.VerticalMaxVelocity && VerticalInput > 0){LinearOutputY = 0;}
                if(linearVelocityY <= -stats.VerticalMaxVelocity && VerticalInput < 0){LinearOutputY = 0;}
                    
                if(linearVelocityZ >=  stats.LongitudinalMaxVelocity && LongitudinalInput > 0){LinearOutputZ = 0;}
                if(linearVelocityZ <= -stats.LongitudinalMaxVelocity && LongitudinalInput < 0){LinearOutputZ = 0;}        
            }
                
            if(assistToggle.RotationAssistEnabled){
                pid.Calculate(stats.PitchMaxVelocity * PitchInput, angularVelocityX, 
                    AngularErrorX, AngularIntegralX, stats.AngularGainX, deltaTime);
                AngularOutputX = Clamp.Float((pid.Output / stats.PitchMaxVelocity), -1f, 1f);
                AngularErrorX = pid.Error;
                AngularIntegralX = pid.Integral;
                    
                pid.Calculate(stats.YawMaxVelocity * YawInput, angularVelocityY, 
                    AngularErrorY, AngularIntegralY, stats.AngularGainY, deltaTime);
                AngularOutputY = Clamp.Float((pid.Output / stats.YawMaxVelocity), -1f, 1f);
                AngularErrorY = pid.Error;
                AngularIntegralY = pid.Integral;
                    
                pid.Calculate(stats.RollMaxVelocity * RollInput, angularVelocityZ, 
                    AngularErrorZ, AngularIntegralZ, stats.AngularGainZ, deltaTime);
                AngularOutputZ = Clamp.Float((pid.Output / stats.RollMaxVelocity), -1f, 1f);
                AngularErrorZ = pid.Error;
                AngularIntegralZ = pid.Integral;
            }
            else{
                AngularOutputX = PitchInput;
                AngularOutputY = YawInput;
                AngularOutputZ = RollInput;
                    
                if(angularVelocityX >=  stats.PitchMaxVelocity && PitchInput > 0){AngularOutputX = 0;}
                if(angularVelocityX <= -stats.PitchMaxVelocity && PitchInput < 0){AngularOutputX = 0;}
                    
                if(angularVelocityY >=  stats.YawMaxVelocity && YawInput > 0){AngularOutputY = 0;}
                if(angularVelocityY <= -stats.YawMaxVelocity && YawInput < 0){AngularOutputY = 0;}
                    
                if(angularVelocityZ >=  stats.RollMaxVelocity && RollInput > 0){AngularOutputZ = 0;}
                if(angularVelocityZ <= -stats.RollMaxVelocity && RollInput < 0){AngularOutputZ = 0;}
            }

            // determine flight assist output values
            LinearOutputX = LinearOutputX * stats.LateralDesiredThrust;
            LinearOutputY = LinearOutputY * stats.VerticalDesiredThrust;
            LinearOutputZ = LinearOutputZ * stats.LongitudinalDesiredThrust;
            AngularOutputX = AngularOutputX * stats.PitchDesiredThrust;
            AngularOutputY = AngularOutputY * stats.YawDesiredThrust;
            AngularOutputZ = AngularOutputZ * stats.RollDesiredThrust;
        }
    }
}