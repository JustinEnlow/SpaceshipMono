/*Copyright (C) <2018>  <Justin Enlow> <https://www.gnu.org/licenses/>*/
using UnityEngine;

public class InteractMouse : MonoBehaviour{
    bool standby = false;
    [SerializeField]LayerMask layerMask;
    float raycastDistance = 1;
    [SerializeField]Transform cursor = null;
    Collider interactionTarget;
    RaycastHit hit;
    InputController _input;
    
    ///attach colliders to all cockpit elements
    ///place colliders on cockpit interaction layer

    void Awake(){_input = GetComponentInParent<InputController>();}
    void OnEnable(){
        _input.OnInteract += Interact;
        _input.OnInteractAlternate += InteractAlternate;
    }
    void OnDisable(){
        _input.OnInteract -= Interact;
        _input.OnInteractAlternate -= InteractAlternate;
    }

    void FixedUpdate(){
        if(standby){
            //fade out cursor ui
            //use waitforseconds then decrease canvas group alpha
        }
        else{
            //turn on cursor ui
            //if mouse position has changed in the last 5 seconds(whatever timeframe)
        }

        ///raycast out 1-2 units from camera position
        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, layerMask )){
                ///place VRMouse sprite at raycast hit.point(returns hit position as world space vector3)
                cursor.position = hit.point;
                interactionTarget = hit.collider;
        }
        else{
            cursor.position = transform.position + transform.forward * raycastDistance;
            interactionTarget = null;
        }

        // TODO: scale VRMouse sprite according to distance from camera

        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
    }

    public void Interact(){
        if(interactionTarget != null){
            interactionTarget.GetComponent<IInteractable>().Interact();
        }
    }

    public void InteractAlternate(){
        if(interactionTarget != null){
            interactionTarget.GetComponent<IInteractable>().InteractAlternate();
        }
    }
}