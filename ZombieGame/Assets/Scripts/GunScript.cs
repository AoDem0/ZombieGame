using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    
    [SerializeField] private Camera FPScamera;
    public int maxBulletsAmount = 6;
    public int currentBulletsAmount;
    public int gunDMG = 10;
    private bool canShoot = true;
    [SerializeField]private float gunCooldownTime = 3f;
    [SerializeField]private float gunReloadTime = 5f;
    [SerializeField] private float range = 100f;

    void Start()
    {
        currentBulletsAmount = maxBulletsAmount;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) & canShoot & currentBulletsAmount > 0){
            Shoot();
            currentBulletsAmount -= 1;
            StartCoroutine(gunCooldown());
        }
        else if(currentBulletsAmount == 0){
                StartCoroutine(reloadGun());
            }
        if(Input.GetKeyDown("r")){
            StartCoroutine(reloadGun());
        }
    }

    
    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(FPScamera.transform.position, FPScamera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            if(enemy != null){
                Debug.Log("Enemy found!");
                enemy.TakeDamage(gunDMG);
                
            }
            
        }
    }

    private IEnumerator gunCooldown(){
        Debug.Log("Gun on cooldown");
        canShoot = false;
        yield return new WaitForSeconds(gunCooldownTime);
        canShoot = true;
        Debug.Log("Gun ready for shooting");
    }

    private IEnumerator reloadGun(){
        Debug.Log("Start reloading gun");
        yield return new WaitForSeconds(gunReloadTime);
        currentBulletsAmount = maxBulletsAmount;
    }
}
