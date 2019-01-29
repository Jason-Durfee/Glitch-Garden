using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    bool[,] grid;
    [SerializeField] List<int> currentlyFilledGridX, currentlyFilledGridY;
    // Start is called before the first frame update
    void Start() {
        grid = new bool[7,5];
        for (int filledGridIndex = 0; filledGridIndex < currentlyFilledGridX.Count; filledGridIndex++) {
            grid[currentlyFilledGridX[filledGridIndex], currentlyFilledGridY[filledGridIndex]] = true;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void QuitGame() {
        Application.Quit();
    }

    public bool[,] GetGrid() {
        return grid;
    }

    public void SetGrid(bool[,] newGrid) {
        grid = newGrid;
    }
}
