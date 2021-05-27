using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrain : MonoBehaviour
{
    public CarDNA dna;
    public int dnaLength = 4;
    public float reward = 0;
    public bool alive = true;
    public void Init()
    {
        dna = new CarDNA(dnaLength, 1);
        
        reward = 0;
        alive = true;
    }

    public void Crash()
    {

    }

    

    void Update()
    {
        GetComponent<VehicleAIController>().parameters = dna.genes;
    }
}
