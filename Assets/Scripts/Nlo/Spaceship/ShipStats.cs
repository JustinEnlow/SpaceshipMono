using Nlo.Math;

namespace Nlo.Spaceship{
    public class ShipStats{
        public float LateralMaxVelocity{get;set;}
        public float VerticalMaxVelocity{get;set;}
        public float LongitudinalMaxVelocity{get;set;}
        public float PitchMaxVelocity{get;set;}
        public float YawMaxVelocity{get;set;}
        public float RollMaxVelocity{get;set;}
        public float LateralMaxThrust{get; set;}
        public float VerticalMaxThrust {get; set;}
        public float LongitudinalMaxThrust {get; set;}
        public float LateralDesiredThrust {get; set;}
        public float VerticalDesiredThrust {get; set;}
        public float LongitudinalDesiredThrust {get; set;}
        public float PitchMaxThrust {get; set;}
        public float YawMaxThrust {get; set;}
        public float RollMaxThrust {get; set;}
        public float PitchDesiredThrust {get; set;}
        public float YawDesiredThrust {get; set;}
        public float RollDesiredThrust {get; set;}
        public PIDGain LinearGainX, LinearGainY, LinearGainZ, AngularGainX, AngularGainY, AngularGainZ;

        public ShipStats(float lateralMaxVelocity, float verticalMaxVelocity, float longitudinalMaxVelocity, float pitchMaxVelocity, 
            float yawMaxVelocity, float rollMaxVelocity, float lateralMaxThrust, float verticalMaxThrust, float longitudinalMaxThrust, 
            float pitchMaxThrust, float yawMaxThrust, float rollMaxThrust, float linearXGainP, float linearXGainI, float linearXGainD, 
            float linearYGainP, float linearYGainI, float linearYGainD, float linearZGainP, float linearZGainI, float linearZGainD, 
            float angularXGainP, float angularXGainI, float angularXGainD, float angularYGainP, float angularYGainI, float angularYGainD, 
            float angularZGainP, float angularZGainI, float angularZGainD){

            LateralMaxVelocity      = lateralMaxVelocity;
            VerticalMaxVelocity     = verticalMaxVelocity;
            LongitudinalMaxVelocity = longitudinalMaxVelocity;
            PitchMaxVelocity        = pitchMaxVelocity;
            YawMaxVelocity          = yawMaxVelocity;
            RollMaxVelocity         = rollMaxVelocity;
            
            LateralMaxThrust      = lateralMaxThrust;
            VerticalMaxThrust     = verticalMaxThrust;
            LongitudinalMaxThrust = longitudinalMaxThrust;
            LateralDesiredThrust = LateralMaxThrust;
            VerticalDesiredThrust = VerticalMaxThrust;
            LongitudinalDesiredThrust = LongitudinalMaxThrust;
            PitchMaxThrust = pitchMaxThrust;
            YawMaxThrust   = yawMaxThrust;
            RollMaxThrust  = rollMaxThrust;
            PitchDesiredThrust = PitchMaxThrust;
            YawDesiredThrust = YawMaxThrust;
            RollDesiredThrust = RollMaxThrust;

            LinearGainX.p = linearXGainP;
            LinearGainX.i = linearXGainI;
            LinearGainX.d = linearXGainD;
            LinearGainY.p = linearYGainP;
            LinearGainY.i = linearYGainI;
            LinearGainY.d = linearYGainD;
            LinearGainZ.p = linearZGainP;
            LinearGainZ.i = linearZGainI;
            LinearGainZ.d = linearZGainD;

            AngularGainX.p = angularXGainP;
            AngularGainX.i = angularXGainI;
            AngularGainX.d = angularXGainD;
            AngularGainY.p = angularYGainP;
            AngularGainY.i = angularYGainI;
            AngularGainY.d = angularYGainD;
            AngularGainZ.p = angularZGainP;
            AngularGainZ.i = angularZGainI;
            AngularGainZ.d = angularZGainD;
        }
    }
}