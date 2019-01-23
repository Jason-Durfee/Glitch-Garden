using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] int secondsToDestroy = 3;
    [SerializeField] float projectileSpeed = 1;
    [SerializeField] float spinSpeed = 15;
    [SerializeField] int damage = 25;
    [SerializeField] bool spinning;

    // Start is called before the first frame update
    IEnumerator Start() {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {
        transform.localPosition = new Vector3(transform.localPosition.x + projectileSpeed * Time.deltaTime,transform.localPosition.y,0);
        if (spinning) {
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Health collisionHealth = collision.GetComponent<Health>();
            if (collisionHealth) {
                collisionHealth.ReduceHealth(damage);
            }
            Destroy(gameObject);
        }
    }
}
