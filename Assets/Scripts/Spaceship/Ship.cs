using UnityEngine;

public class Ship : MonoBehaviour{
    public Rigidbody rb;
    public InputController input;
    public ShipStats stats;
    public PowerToggleSystem power;
    PowerToggleClick powerToggleInteract;
    public MasterArmSystem masterArm;
    MasterArmClick masterArmInteract;
    public LightToggleSystem lightToggle;
    LightsInteract[] lights;
    public TuningSystem tuning;
    TuningPotInteract[] tuningPots;
    public MFDSystem mfd;
    MFDPotInteract[] mfdPots;
    MFDButtonInteract[] mfdButtons;

    public FlightAssistToggleSystem assistToggle;
    public FlightAssistSystem assist;

    void Awake(){
        stats = new ShipStats(100f, 0f, 25f, 25f, 25f, 75f, 75f, 75f, 30000f, 30000f, 30000f, 30000f, 30000f, 30000f, 100, 10f, 
            100f, 0f, 0f, 100f, 0f, 0f, 100f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f);
        powerToggleInteract = gameObject.GetComponentInChildren<PowerToggleClick>();
        masterArmInteract = gameObject.GetComponentInChildren<MasterArmClick>();
        lights = gameObject.GetComponentsInChildren<LightsInteract>();
        tuningPots = gameObject.GetComponentsInChildren<TuningPotInteract>();
        mfdPots = gameObject.GetComponentsInChildren<MFDPotInteract>();
        mfdButtons = gameObject.GetComponentsInChildren<MFDButtonInteract>();

        power = new PowerToggleSystem(input, powerToggleInteract);
        assistToggle = new FlightAssistToggleSystem(power, input);
        masterArm = new MasterArmSystem(input, masterArmInteract);

        
        assist = new FlightAssistSystem(rb, stats, power, assistToggle, input, Time.fixedDeltaTime);
        lightToggle = new LightToggleSystem(input, lights);
        tuning = new TuningSystem(power, input, tuningPots, stats);
        mfd = new MFDSystem(power, mfdPots, mfdButtons);
    }

    void FixedUpdate(){assist.Process(Time.fixedDeltaTime);}
}