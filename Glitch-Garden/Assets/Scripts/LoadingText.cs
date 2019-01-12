using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour {
    int dotCount = 0;
    bool loadingDone = false;
    TextMeshProUGUI loadingText;

    // Start is called before the first frame update
    void Start() {
        loadingText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Loading());
    }

    private IEnumerator Loading() {
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
            if (Time.time > 4) {
                loadingDone = true;
            }
        }
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    // Update is called once per frame
    void Update() {

    }
}
