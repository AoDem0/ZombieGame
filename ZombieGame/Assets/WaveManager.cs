using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField]private GameObject zombiePrefab;
    [SerializeField] private float timeBetweenWaves = 120f;
    [SerializeField]private int zombiesPerWave = 5;
    [SerializeField] private float zombieModif = 0.9f;
    [SerializeField] private int currentWave = 0;
    [SerializeField] public float spawnInterval = 1f;
    [SerializeField] public float spawnDistanceMin = 20f;
    [SerializeField] public float spawnDistanceMax = 40f;
    [SerializeField] private List<GameObject> aliveZombies;

    [SerializeField] private int nightNum = 0;

    public float zombieMoveSpeed = 3.4f;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        while (true)
        {
            currentWave++;
            nightNum++;
            zombieModif += 0.1f;
            zombieMoveSpeed += 0.05f;
            int zombiesToSpawn = Mathf.RoundToInt(zombiesPerWave * currentWave * zombieModif);
            Debug.Log($"Wave {currentWave} starting: {zombiesToSpawn} zombies!");
            yield return StartCoroutine(SpawnWave(zombiesToSpawn));
            yield return StartCoroutine(WaitForZombiesToDie());
            Debug.Log($"Wave {currentWave} defeated. Next wave in {timeBetweenWaves} seconds.");
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(int count)
    {

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            GameObject zombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
            aliveZombies.Add(zombie);
            yield return new WaitForSeconds(spawnInterval);
        }

    }

    private IEnumerator WaitForZombiesToDie()
    {
        while (aliveZombies.Exists(z => z != null))
        {
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float distance = Random.Range(spawnDistanceMin, spawnDistanceMax);
        Vector3 position = new Vector3(randomDir.x, 0f, randomDir.y) * distance;
        return position;
    }
}
