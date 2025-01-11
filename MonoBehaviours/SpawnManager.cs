using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;
    [SerializeField] float upperLimit = 6f;
    [SerializeField] float lowerLimit = -7.45f;
    [SerializeField] float spawnRate = 2f;
    [SerializeField] float spawnAfterSeconds = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnRate, spawnAfterSeconds);

    }


    private void SpawnObstacle()
    {
        if (!GameManager.instance.player.IsDead())
        {
            int randomIndex = Random.Range(0, 3);
            float spawnYposition = Random.Range(lowerLimit, upperLimit);
            Vector3 spawnPosition = new Vector3(22, spawnYposition, -2);
            Instantiate(obstaclePrefab[randomIndex], spawnPosition, obstaclePrefab[randomIndex].transform.rotation);
        }

    }
}
