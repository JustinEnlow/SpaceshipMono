using UnityEngine;

public class Ship : MonoBehaviour{
    public Rigidbody rb;
    public InputController input;
    public ShipStats stats;
    public PowerToggle power;
    public PowerToggleInteract powerToggleInteract;
    public MasterArm masterArm;
    public MasterArmInteract masterArmInteract;
    public LightToggle lightToggle;
    public LightsInteract[] lights;
    public Tuning tuning;
    public TuningPotInteract[] tuningPots;
    public MFDSystem mfd;
    public MFDPotInteract[] mfdPots;
    public MFDButtonInteract[] mfdButtons;

    public FlightAssistToggle assistToggle;
    public FlightAssist assist;

    FighterAnimation fighterAnim;
    FighterUI fighterUI;

    void Awake(){
        stats = new ShipStats(100f, 0f, 25f, 25f, 25f, 75f, 75f, 75f, 30000f, 30000f, 30000f, 30000f, 30000f, 30000f, 100, 10f, 
            100f, 0f, 0f, 100f, 0f, 0f, 100f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 1f, 0f, 0f);
        powerToggleInteract = gameObject.GetComponentInChildren<PowerToggleInteract>();
        masterArmInteract = gameObject.GetComponentInChildren<MasterArmInteract>();
        lights = gameObject.GetComponentsInChildren<LightsInteract>();
        tuningPots = gameObject.GetComponentsInChildren<TuningPotInteract>();
        mfdPots = gameObject.GetComponentsInChildren<MFDPotInteract>();
        mfdButtons = gameObject.GetComponentsInChildren<MFDButtonInteract>();

        power = new PowerToggle(this);
        assistToggle = new FlightAssistToggle(this);
        masterArm = new MasterArm(this);

        
        assist = new FlightAssist(this);
        lightToggle = new LightToggle(this);
        tuning = new Tuning(this);
        mfd = new MFDSystem(this);

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

    void FixedUpdate(){assist.Process(Time.fixedDeltaTime);}
}