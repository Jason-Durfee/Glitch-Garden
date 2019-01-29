using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    [SerializeField] int currencyValue = 5;

    StarCurrency starCurrency;

    public int GetValue() {
        return currencyValue;
    }

    public void DestroyStar() {
        starCurrency = FindObjectOfType<StarCurrency>();
        if (starCurrency) {
            starCurrency.UpdateCurrentCurrency(currencyValue);
        }
        Destroy(gameObject);
    }

}
