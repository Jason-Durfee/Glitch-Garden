using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerLevelHandler : MonoBehaviour {
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer) {
            if (transform.parent.position.y >= 1 && transform.parent.position.y < 2) {
                spriteRenderer.sortingOrder = 9;
            }
            else if (transform.parent.position.y >= 2 && transform.parent.position.y < 3) {
                spriteRenderer.sortingOrder = 8;
            }
            else if (transform.parent.position.y >= 3 && transform.parent.position.y < 4) {
                spriteRenderer.sortingOrder = 7;
            }
            else if (transform.parent.position.y >= 4 && transform.parent.position.y < 5) {
                spriteRenderer.sortingOrder = 6;
            }
            else {
                spriteRenderer.sortingOrder = 5;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
