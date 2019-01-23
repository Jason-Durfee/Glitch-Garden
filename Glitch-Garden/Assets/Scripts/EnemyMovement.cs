using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [Range(0, 5)]

    float moveSpeed;
    bool canMove = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (canMove) {
            MoveEnemy();
        }
    }

    private void MoveEnemy() {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void StartWalking(float speed) {
        moveSpeed = speed;
        canMove = true;
    }
}
