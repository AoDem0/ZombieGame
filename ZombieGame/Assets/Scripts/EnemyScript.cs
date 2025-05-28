using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int currentEnemyHealth;
    public int maxEnemyHealth = 50;
    [SerializeField]private EventsList events;

    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy hit. Current health: " + currentEnemyHealth);
        currentEnemyHealth -= amount;
        if (currentEnemyHealth <= 0){
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Enemy died");
        events.EnemyDeath();
        Destroy(gameObject);
    }
}
