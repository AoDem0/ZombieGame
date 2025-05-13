using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 50;
    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy hit. Current health: " + enemyHealth);
        enemyHealth -= amount;
        if (enemyHealth <= 0){
            Die();
        }

    }
    void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
