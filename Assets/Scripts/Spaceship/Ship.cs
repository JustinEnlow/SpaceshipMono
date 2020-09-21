using UnityEngine;
using Nlo.Spaceship;
using Nlo.Spaceship.Interfaces;

public class Ship : MonoBehaviour{
    [HideInInspector]public Rigidbody rb;
    public ShipEventManager eventManager;
    public ShipStats stats;
    public PowerToggle power;
    public MasterArm masterArm;
    public LightToggle lightToggle;
    public Tuning tuning;
    public MFDSystem mfd;
    IWeapon[] weapons;
    WeaponSystem weaponSystem;

    public FlightAssistToggle assistToggle;
    public FlightAssist assist;

    FighterAnimation fighterAnim;
    FighterUI fighterUI;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        eventManager = new ShipEventManager();
        stats = new ShipStats(25f, 25f, 25f, 75f, 75f, 75f, 30000f, 30000f, 30000f, 30000f, 30000f, 30000f, 100f, 0f, 0f, 100f, 0f, 0f, 
            100f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f);

        power = new PowerToggle(eventManager);
        assistToggle = new FlightAssistToggle(eventManager, power);
        masterArm = new MasterArm(eventManager);

        
        assist = new FlightAssist(eventManager, power, assistToggle, stats/*, rb*/);
        lightToggle = new LightToggle(eventManager);
        mfd = new MFDSystem(eventManager, power);
        tuning = new Tuning(eventManager, power, stats/*, tuningPots*/);

        weaponSystem = new WeaponSystem(eventManager, power, masterArm);
        weapons = gameObject.GetComponentsInChildren<IWeapon>();
        var weaponEnabledStatus = new bool[weapons.Length];
        for(int i = 0; i < weaponEnabledStatus.Length; i++){
            weaponEnabledStatus[i] = true;
        }
        weaponSystem.UpdateWeapons(weapons, weaponEnabledStatus);

        fighterAnim = GetComponent<FighterAnimation>();
        fighterAnim.Initialize(this);
        fighterUI = GetComponent<FighterUI>();
        fighterUI.Initialize(this);
    }
    void OnEnable(){
        fighterAnim.Enable();
        fighterUI.Enable();
    }
    void Start(){tuning.UpdateTuningParameter();}

    void FixedUpdate(){
        if(power.Enabled){
            // convert velocities from world space to local
            var LinearVelocity = rb.transform.InverseTransformVector(rb.velocity);
                //use degrees instead of radians
            var AngularVelocity = rb.transform.InverseTransformVector(rb.angularVelocity) * Mathf.Rad2Deg;
            
            // feed velocity values into assist.Process
            assist.Calculate(LinearVelocity.x, LinearVelocity.y, LinearVelocity.z, AngularVelocity.x, AngularVelocity.y, 
                AngularVelocity.z, Time.fixedDeltaTime);
            
            // feed assist.Process return values to unity physics engine
            rb.AddRelativeForce(assist.LinearOutputX, assist.LinearOutputY, assist.LinearOutputZ, ForceMode.Force);
            rb.AddRelativeTorque(assist.AngularOutputX, assist.AngularOutputY, assist.AngularOutputZ, ForceMode.Force);
        }
    }
}