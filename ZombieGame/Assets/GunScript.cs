using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Camera FPScamera;
    public int gunDMG = 10;
    [SerializeField] private float range = 100f;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot();
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
}
