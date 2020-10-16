using UnityEngine;
using Nlo.Spaceship;
using Nlo.Spaceship.Interfaces;

public class Ship : MonoBehaviour{
    public ShipStats stats{get; private set;}
    public ShipEventManager eventManager{get; private set;}
    public PowerToggle power{get; private set;}
    public FlightAssistToggle assistToggle{get; private set;}
    public FlightAssist assist{get; private set;}
    public MFDSystem mfd{get; private set;}
    public Tuning tuning{get; private set;}
    public MasterArm masterArm{get; private set;}
    IWeapon[] primaryFireGroup;
    IWeapon[] secondaryFireGroup;
    public WeaponSystem weaponSystem{get; private set;}
    public LightToggle lightToggle{get; private set;}
    public FighterAnimation fighterAnim{get; private set;}
    public FighterUI fighterUI{get; private set;}
    public Rigidbody rb{get; private set;}
    [SerializeField]Transform[] hardpoints;
    [SerializeField]GameObject CoilGun_AutoPrefab;
    [SerializeField]GameObject CoilGun_SemiAutoPrefab;
    public IWeapon[] weapons{get; set;}

    void Awake(){
        stats = new ShipStats(25f, 25f, 25f, 75f, 75f, 75f, 30000f, 30000f, 30000f, 30000f, 30000f, 30000f, 100f, 0f, 0f, 100f, 0f, 0f, 
            100f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 2, 1500f);

        eventManager = new ShipEventManager();
        power = new PowerToggle(eventManager);
        assistToggle = new FlightAssistToggle(eventManager, power);
        assist = new FlightAssist(eventManager, power, assistToggle, stats);
        mfd = new MFDSystem(eventManager, power, stats);
        tuning = new Tuning(eventManager, power, stats);
        masterArm = new MasterArm(eventManager);
//            stats.weapons[0] = Instantiate(CoilGun_AutoPrefab, hardpoints[0].position, Quaternion.identity, 
//                /*parent*/hardpoints[0]).GetComponent<IWeapon>();
//            stats.weapons[1] = Instantiate(CoilGun_SemiAutoPrefab, hardpoints[1].position, Quaternion.identity, 
//                /*parent*/hardpoints[1]).GetComponent<IWeapon>();
//            //stats.weapons[2] = null;
        weaponSystem = new WeaponSystem(eventManager, power, masterArm);
        lightToggle = new LightToggle(eventManager);

        fighterAnim = GetComponent<FighterAnimation>();
        fighterAnim.Initialize(power, masterArm, lightToggle);
        fighterUI = GetComponent<FighterUI>();
        fighterUI.Initialize(power, assistToggle, tuning, mfd);

        rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = stats.Mass;
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.useGravity = false;
        rb.isKinematic = false;

    }
    void OnEnable(){
        fighterAnim.Enable();
        fighterUI.Enable();
    }
    void Start(){
        tuning.UpdateTuningParameter();
//        for(int i = 0; i < weapons.Length; i++){
//            if(weapons[i] != null){
//                Debug.Log("Hardpoint " + i + " has a " + weapons[i].Name + " equipped");
//            }
//            else{Debug.Log("Hardpoint " + i + " has nothing equipped");}
//        }
    }

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