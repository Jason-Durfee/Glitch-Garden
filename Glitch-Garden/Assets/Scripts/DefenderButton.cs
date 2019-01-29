using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] GameObject defenderObject;
    [SerializeField] int defenderCost;

    GameObject defenderSelector;
    private void OnMouseUp() {
        MoveDefenderSelector();
        ChangeSpriteColoring();
        SetNewDefender();
    }

    private void MoveDefenderSelector() {
        defenderSelector = GameObject.FindGameObjectWithTag("DefenderSelector");
        if (defenderSelector) {
            defenderSelector.transform.localPosition = transform.localPosition;
        }
    }

    private void ChangeSpriteColoring() {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("DefenderButton");
        if (buttons.Length > 0) {
            foreach (GameObject gameObj in buttons) {
                SpriteRenderer tempSpriteRend = gameObj.GetComponent<SpriteRenderer>();
                if (tempSpriteRend) {
                    tempSpriteRend.color = new Color(0.43f, 0.43f, 0.43f);
                }
            }
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer) {
                spriteRenderer.color = new Color(1, 1, 1);
            }
        }
    }

    private void SetNewDefender() {
        DefenderSpawner spawner = FindObjectOfType<DefenderSpawner>();
        if (spawner && defenderObject) {
            spawner.SetDefender(defenderObject, defenderCost);
        }
    }
}
