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

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonUp("SpawnDefender") && gameManager) {
            SpawnDefender();
        }
    }
    private void SpawnDefender() {
        bool[,] grid = gameManager.GetGrid();
        int xWorldPos = (int)(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.5f);
        int yWorldPos = (int)(Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.5f);
        if (xWorldPos < 8 && xWorldPos > 0 && yWorldPos > 0 && yWorldPos < 6 && !grid[xWorldPos - 1, yWorldPos - 1]) {
            grid[xWorldPos - 1, yWorldPos - 1] = true;
            gameManager.SetGrid(grid);
            Instantiate(defender, new Vector3(xWorldPos, yWorldPos, 0), Quaternion.identity);
        }
    }
}
