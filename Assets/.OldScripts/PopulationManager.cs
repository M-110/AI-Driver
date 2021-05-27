using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Vehicle.Waypoints;

public class PopulationManager : MonoBehaviour
{
    public GameObject carPrefab;
    public AICheckpointManager checkpointManager;
    public Transform startingPosition;
    public int populationSize = 10;
    public float mutationRate = 5;
    List<GameObject> population = new List<GameObject>();
    public int generation = 1;
    public float timeElapsed = 0;
    public float trialTime = 20f;

    GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation: " + generation, guiStyle);
        GUI.Label(new Rect(10, 65, 100, 20), "Trial Time: " + (int)timeElapsed, guiStyle);

    }


    void Start()
    {
        //Spawn Initial Population
        for(int i = 0; i < populationSize; i++)
        {
            GameObject go = Instantiate(carPrefab,startingPosition.position,startingPosition.transform.rotation);
            go.GetComponent<VehicleAIController>().cpManager = checkpointManager;
            go.GetComponent<CarBrain>().Init();
            
            population.Add(go);
        }
    }

    GameObject Breed(GameObject parent1, GameObject  parent2)
    {
        CarDNA dna1 = parent1.GetComponent<CarDNA>();
        CarDNA dna2 = parent2.GetComponent<CarDNA>();
        
        GameObject offspring  = Instantiate(carPrefab,startingPosition.position,startingPosition.transform.rotation);
        CarBrain brain = offspring.GetComponent<CarBrain>();
        Debug.Log(offspring);

        for(int i = 0; i < brain.dnaLength; i++)
            {
                //Random DNA mutation
                if(UnityEngine.Random.Range(0,1000) <= mutationRate)
                {
                brain.dna.Mutate();
                brain.Init();
                }
                //Inheret DNA from random parent
                else
                {
                brain.Init();
                brain.dna.Combine(parent1.GetComponent<CarBrain>().dna, parent2.GetComponent<CarBrain>().dna);
                }
            }
            
            offspring.GetComponent<VehicleAIController>().cpManager = checkpointManager;
        return offspring;
    }

    private void BreedNewPopulation()
    {
        //Sort car population by sucess
        List<GameObject> sortedList = population.OrderByDescending(o => o.GetComponent<CarBrain>().reward).ToList();

        //Clear last generation's population
        population.Clear();

        //Breed the top of the list
        int parentCount = (int)(sortedList.Count / 2);
        for (int i = 0; i < parentCount; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i + 1], sortedList[i]));
        }

        for (int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed  >= trialTime)
        {
            BreedNewPopulation();
            timeElapsed = 0;
        }
    }
}
