using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int currentEnemyHealth;
    public int maxEnemyHealth = 50;
    [SerializeField] private float time = 1f;
    [SerializeField] private Vector3 homePosition;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EventsList events;
    private Transform targetWindow;
    [SerializeField] private WaveManager man;


    void Start()
    {
        events = FindAnyObjectByType<EventsList>();
        man = FindAnyObjectByType<WaveManager>();
        currentEnemyHealth = maxEnemyHealth;
        agent.speed = man.zombieMoveSpeed;
        StartCoroutine(FindPath());
    }

    private IEnumerator FindPath()
    {
        //agent.SetDestination(homePosition);

        GameObject[] windows = GameObject.FindGameObjectsWithTag("Window");
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject window in windows)
        {
            float distance = Vector3.Distance(transform.position, window.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                targetWindow = window.transform;
            }
        }
        yield return new WaitForSeconds(time);
        if (targetWindow != null)
        {
            agent.SetDestination(targetWindow.position);
        }
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy hit. Current health: " + currentEnemyHealth);
        currentEnemyHealth -= amount;
        if (currentEnemyHealth <= 0)
        {
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
