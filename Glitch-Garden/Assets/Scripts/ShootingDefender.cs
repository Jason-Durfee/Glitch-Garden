﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDefender : MonoBehaviour {
    [SerializeField] GameObject projectile;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ShootProjectile() {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
