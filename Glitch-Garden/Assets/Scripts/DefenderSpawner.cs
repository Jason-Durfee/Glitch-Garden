using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    [SerializeField] GameObject defender;

    GameManager gameManager;
    StarCurrency starCurrency;
    int defenderCost;
    bool[,] grid;
    int currentCurrency;
    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        starCurrency = FindObjectOfType<StarCurrency>();
        currentCurrency = starCurrency.GetCurrentCurrency();
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
        currentCurrency = starCurrency.GetCurrentCurrency();
        if (defender && !grid[(int)clickPoint.x - 1, (int)clickPoint.y - 1] && defenderCost <= currentCurrency) {
            grid[(int)clickPoint.x - 1, (int)clickPoint.y - 1] = true;
            gameManager.SetGrid(grid);
            starCurrency.UpdateCurrentCurrency(-defenderCost);
            Instantiate(defender, clickPoint, Quaternion.identity);
        }
    }

    public void SetDefender(GameObject newDefender, int newDefenderCost) {
        defender = newDefender;
        defenderCost = newDefenderCost;
    }
}
