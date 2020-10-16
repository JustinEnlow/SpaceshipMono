using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Nlo.Spaceship;
using Nlo.Spaceship.Interfaces;

public class CoilGun_Auto : MonoBehaviour, IWeapon{
    public FireGroup FireGroup{get; set;}
    public string Name{get; private set;}
    bool firing;
    float ProjectileVelocity{get; set;}
    [SerializeField]Transform bulletSpawnPoint;
    [SerializeField]GameObject bulletPrefab;

    void Awake(){
        FireGroup = FireGroup.None;
        Name = "CoilGun_Auto";
    }
    void Start(){ProjectileVelocity = 40f;}

    public void Fire(){
        firing = true;
        //Shoot();
        StartCoroutine("Shoot2");
    }
    public void StopFiring(){
        firing = false;
        StopCoroutine("Shoot2");
    }

    // async may not be timing accurately
    async Task Shoot(){
        while(firing){
            Debug.Log("shooting 1 round");
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity, this.transform);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileVelocity;
            // destroy instantiated bullets after set time to reduce system resource usage
            Destroy(bullet, 10f);

            await Task.Delay(100);
        }
    }

    IEnumerator Shoot2(){
        while(true){
            Debug.Log("shooting 1 round");
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity, this.transform);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * ProjectileVelocity;
            Destroy(bullet, 10f);

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}