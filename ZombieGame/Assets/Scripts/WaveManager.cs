using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [SerializeField]private GameObject zombiePrefab;
    [SerializeField] private float timeBetweenWaves = 120f;
    [SerializeField]private int zombiesPerWave = 5;
    [SerializeField] private float zombieModif = 0.9f;
    [SerializeField] private int currentWave = 0;
    [SerializeField] public float spawnInterval = 60f;
    [SerializeField] private List<GameObject> aliveZombies;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private int nightNum = 0;
    public float zombieMoveSpeed = 1.4f;

    [SerializeField] private audioManager audioMan;

    void Start()
    {
        StartCoroutine(StartWaves());
        text.text = "night 1";
    }

    private IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        while (true)
        {
            audioMan.Play("waveSound");
            currentWave++;
            nightNum++;
            text.text = "night " + nightNum;
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
            audioMan.Play("zombieSpawn");
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
        int ranSide = Random.Range(0, 3);
        float ranX = 0f;
        float ranZ = 0f;
        switch (ranSide)
        {
            case 0:
                ranX = Random.Range(40.2f, 54f);
                ranZ = Random.Range(-21.3f, 49.5f);
                break;
            case 1:
                ranX = Random.Range(-45.88f, 38f);
                ranZ = Random.Range(36.13f, 49.9f);
                break;
            case 2:
                ranX = Random.Range(-61.7f, -47.9f);
                ranZ = Random.Range(-21.3f, 48.9f);
                break;
            default:
                break;
        }
        
        Vector3 position = new Vector3(ranX, 0f, ranZ);
        return position;
    }
}
