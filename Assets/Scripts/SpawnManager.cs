﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float delay = 2.0f;
    private float interval = 2.0f;
    private PlayerController script;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", delay, interval);
        script = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(!script.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
