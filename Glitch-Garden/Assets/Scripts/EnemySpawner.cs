using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float minRandomWaitTime = 5;
    [SerializeField] float maxRandomWaitTime = 10;
    [SerializeField] float defaultWaitTime = 5;
    [SerializeField] GameObject enemyToSpawn;

    float randomWaitTime;
    bool spawning = false;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(StartSpawningAfterDelay());
    }

    // Update is called once per frame
    void Update() {
        if (spawning) {
            spawning = false;
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies() {
        SpawnEnemy();
        randomWaitTime = UnityEngine.Random.Range(minRandomWaitTime, maxRandomWaitTime);
        yield return new WaitForSeconds(randomWaitTime);
        spawning = true;
    }

    private IEnumerator StartSpawningAfterDelay() {
        yield return new WaitForSeconds(defaultWaitTime);
        spawning = true;
    }

    private void SpawnEnemy() {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }
}
