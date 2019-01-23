using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int HP;
    [SerializeField] GameObject deathVFX;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ReduceHealth(int damage) {
        HP -= damage;
        if (HP <= 0) {
            Destroy(gameObject);
            if (deathVFX) {
                GameObject deathVFXObj = Instantiate(deathVFX, transform.position, Quaternion.identity);
            }
        }
    }
}
