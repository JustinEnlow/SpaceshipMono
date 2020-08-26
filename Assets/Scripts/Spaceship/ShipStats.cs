using UnityEngine;
using Nlo.Math;

public class ShipStats : MonoBehaviour, IShoot{
    public float TotalHealth{get;set;}
    public float CurrentHealth{get;set;}
    public float ArmorAmount{get;set;}
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
    public int ShootDistance{get; set;}
    public float DamageAmount{get; set;}
    public PIDGain LinearGainX, LinearGainY, LinearGainZ, AngularGainX, AngularGainY, AngularGainZ;

    void Awake(/*float totalHealth, float armorAmount, float lateralMaxVelocity, float verticalMaxVelocity, 
        float longitudinalMaxVelocity, float pitchMaxVelocity, float yawMaxVelocity, float rollMaxVelocity,
        float lateralmaxThrust, float verticalMaxThrust, float longitudinalMaxThrust, float pitchMaxThrust, 
        float yawMaxThrust, float rollMaxThrust, int shootDistance, float damageAmount, float linearXGainP,
        float linearXGainI, float linearXGainD, float linearYGainP, float linearYGainI, float linearYGainD, 
        float linearZGainP, float linearZGainI, float linearZGainD, float angularXGainP, float angularXGainI,
        float angularXGainD, float angularYGainP, float angularYGainI, float angularYGainD, float angularZGainP,
        float angularZGainI, float angularZGainD*/){

        TotalHealth   = 100f;
        CurrentHealth = TotalHealth;
        ArmorAmount   = 0f;

        LateralMaxVelocity      = 25;
        VerticalMaxVelocity     = 25;
        LongitudinalMaxVelocity = 25;
        PitchMaxVelocity        = 75;
        YawMaxVelocity          = 75;
        RollMaxVelocity         = 75;
        
        LateralMaxThrust      = 30000f;
        VerticalMaxThrust     = 30000f;
        LongitudinalMaxThrust = 30000f;
        LateralDesiredThrust = LateralMaxThrust;
        VerticalDesiredThrust = VerticalMaxThrust;
        LongitudinalDesiredThrust = LongitudinalMaxThrust;
        PitchMaxThrust = 30000f;
        YawMaxThrust   = 30000f;
        RollMaxThrust  = 30000f;
        PitchDesiredThrust = PitchMaxThrust;
        YawDesiredThrust = YawMaxThrust;
        RollDesiredThrust = RollMaxThrust;
        
        ShootDistance = 100;
        DamageAmount  = 10f;

        LinearGainX.p = 100f;
        LinearGainX.i = 0f;
        LinearGainX.d = 0f;
        LinearGainY.p = 100f;
        LinearGainY.i = 0f;
        LinearGainY.d = 0f;
        LinearGainZ.p = 100f;
        LinearGainZ.i = 0f;
        LinearGainZ.d = 0f;

        AngularGainX.p = 1f;
        AngularGainX.i = 0f;
        AngularGainX.d = 0f;
        AngularGainY.p = 1f;
        AngularGainY.i = 0f;
        AngularGainY.d = 0f;
        AngularGainZ.p = 1f;
        AngularGainZ.i = 0f;
        AngularGainZ.d = 0f;
    }
}