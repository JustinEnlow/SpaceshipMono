using UnityEngine;
using Nlo.Spaceship;
using Nlo.Spaceship.Interfaces;

public class CoilGun_SemiAuto : MonoBehaviour, IWeapon{
    public FireGroup FireGroup{get; set;}
    public string Name{get; private set;}
    float ProjectileVelocity{get; set;}
    [SerializeField]Transform bulletSpawnPoint;
    [SerializeField]GameObject bulletPrefab;

    void Awake(){
        FireGroup = FireGroup.None;
        Name = "CoilGun_SemiAuto";
    }
    void Start(){ProjectileVelocity = 40f;}

    public void Fire(){
        Shoot();
    }
    public void StopFiring(){}

    void Shoot(){
        Debug.Log("shooting 1 round");
        
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity, this.transform);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileVelocity;
        // destroy instantiated bullets after set time to reduce system resource usage
        Destroy(bullet, 10f);
    }
}