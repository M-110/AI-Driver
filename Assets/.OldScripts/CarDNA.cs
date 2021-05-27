using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDNA : MonoBehaviour
{   
    public List<float> genes = new List<float>();
    int dnaLength = 0;
    int maxValues = 0;
    public float distance = 0;

    public CarDNA(int length, int max)
    {
        // Construct initial size of DNA
        dnaLength = length;
        maxValues = max;
        SetRandom();
    }

    public void SetRandom()
    {
        genes.Clear();

        for (int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0f, maxValues));
        }
    }

    public void SetGene(int pos, int value)
    {
        genes[pos] = value;
    }

    public void Combine(CarDNA d1, CarDNA d2)
    {
        for (int i = 0; i < dnaLength; i++)
        {
            if(Random.Range(0,2) == 0)
            {
                genes[i] = d1.genes[i];
            }
            else
            {
                genes[i] = d2.genes[i];
            }
        }
    }

    public void Mutate()
    {
        genes[Random.Range(0,dnaLength+1)] = Random.Range(0,maxValues);
    }
}
