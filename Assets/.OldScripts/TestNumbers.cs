﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNumbers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Random.Range(0, 2));
    }
}
