using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    [SerializeField] GameObject defender;
    GameManager gameManager;
    bool[,] grid;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseUp() {
        if (gameManager) {
            SpawnDefender(GetMousePosOnGrid());
        }
    }

    private Vector2 GetMousePosOnGrid() {
        int xWorldPos = (int)(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.5f);
        int yWorldPos = (int)(Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.5f);
        return new Vector2(xWorldPos, yWorldPos);
    }

    private void SpawnDefender(Vector2 clickPoint) {
        bool[,] grid = gameManager.GetGrid();
        if (!grid[(int)clickPoint.x - 1, (int)clickPoint.y - 1]) {
            grid[(int)clickPoint.x - 1, (int)clickPoint.y - 1] = true;
            gameManager.SetGrid(grid);
            Instantiate(defender, clickPoint, Quaternion.identity);
        }
    }

    public void SetDefender(GameObject newDefender) {
        defender = newDefender;
    }
}
