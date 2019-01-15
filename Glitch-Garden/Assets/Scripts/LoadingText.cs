using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingText : MonoBehaviour {
    int dotCount = 0;
    bool loadingDone = false;
    TextMeshProUGUI loadingText;

    // Start is called before the first frame update
    void Start() {
        loadingText = GetComponent<TextMeshProUGUI>();
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            StartCoroutine(LoadingWithProgrammedDelay());
        }
    }

    private IEnumerator LoadingWithProgrammedDelay() {
        StartCoroutine(Timer(3));
        while (!loadingDone) {
            dotCount++;
            yield return new WaitForSeconds(0.5f);
            loadingText.text = "Loading";
            for (int dotIndex = 0; dotIndex < dotCount; dotIndex++) {
                loadingText.text += ".";
            }
            if (dotCount == 3) {
                dotCount = -1;
            }
        }
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    private IEnumerator Timer(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        loadingDone = true;
    }

    // Update is called once per frame
    void Update() {

    }
}
