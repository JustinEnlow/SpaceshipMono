using System;
using UnityEngine;

public class MasterArmSystem : MonoBehaviour{
    InputController _input;
    MasterArmClick _masterArmInteract;

    public bool Armed{get; private set;}
    
    public event Action OnMasterArmToggled;

    void Awake(){
        _input = GetComponentInChildren<InputController>();
        _masterArmInteract = GetComponentInChildren<MasterArmClick>();
    }
    void OnEnable(){
        _input.OnToggleMasterArm += ToggleMasterArm;
        _masterArmInteract.OnInteract += ToggleMasterArm;
    }

    public void ToggleMasterArm(){
        Armed = !Armed;
        OnMasterArmToggled?.Invoke();
    }
}