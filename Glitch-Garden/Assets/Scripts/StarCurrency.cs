using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCurrency : MonoBehaviour {
    [SerializeField] int startingCurrency;
    int currentCurrency;
    TextMeshProUGUI currencyText;

    private void Awake() {
        currentCurrency = startingCurrency;
        currencyText = GameObject.FindGameObjectWithTag("CurrencyDisplay").GetComponent<TextMeshProUGUI>();
        if (currencyText) {
            currencyText.text = currentCurrency.ToString();
        }
    }

    public int GetCurrentCurrency() {
        return currentCurrency;
    }

    public void UpdateCurrentCurrency(int updateAmount) {
        currentCurrency += updateAmount;
        if (currentCurrency > 1000) {
            currentCurrency = 1000;
        }
        if (currentCurrency < 0) {
            currentCurrency = 0;
        }
        currencyText.text = currentCurrency.ToString();
    }
}
