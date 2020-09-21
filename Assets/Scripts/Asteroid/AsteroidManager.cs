using UnityEngine;

public class AsteroidManager : MonoBehaviour{
    public float TotalHealth{get; private set;}
    public float CurrentHealth{get; private set;}
    public float ArmorAmount{get; private set;}
    [SerializeField]float maxTorque;
    [SerializeField]Rigidbody rb;

    void Awake(){
        TotalHealth = 100f;
        CurrentHealth = TotalHealth;
        ArmorAmount = 0f;

        Vector3 _rotation = new Vector3(Random.Range(-maxTorque, maxTorque),
		Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));

		rb.AddTorque(_rotation);
    }

    public void ModifyHealth(float _amount){
        if(_amount > 0){return;}
        else{CurrentHealth = CurrentHealth + _amount;}
        
        if(CurrentHealth <= 0){Destroy(this.gameObject);}
    }
}