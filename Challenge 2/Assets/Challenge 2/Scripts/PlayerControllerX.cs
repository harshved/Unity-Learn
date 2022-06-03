﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpam = true;

    void Start()
    {
        InvokeRepeating("DogsCanSpam", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpam)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpam = false;
        }
    }

    void DogsCanSpam()
    {
        canSpam = true;
    }
}
