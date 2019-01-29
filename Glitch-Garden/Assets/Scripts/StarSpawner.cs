using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {
    [SerializeField] GameObject star;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RandomlySpawnStar());
    }

    // Update is called once per frame
    void Update() {

    }

    private IEnumerator RandomlySpawnStar() {
        yield return new WaitForSeconds(3);
        GameObject starObj = Instantiate(star, transform.position, Quaternion.identity) as GameObject;
        StartCoroutine(RandomlySpawnStar());
    }
}
