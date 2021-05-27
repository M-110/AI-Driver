using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.Stats;

public class TestProfiles: MonoBehaviour
{
    public List<GameObject> Level0(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;
        
        string carName = $"'AI Level 0'";
        car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);

        car.name = carName;
        car.GetComponent<VehicleStatsTracker>().vehicleName = carName;

        car.GetComponent<AIDriverLevel0>().throttle = 1f;

        cars.Add(car);
        return cars;
    }

    public List<GameObject> Level1(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;
        
        string carName = $"'AI Level 1, throttle=.4f, angle=8f, offset=31'";
        car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);

        car.name = carName;
        car.GetComponent<VehicleStatsTracker>().vehicleName = carName;

        car.GetComponent<AIDriverLevel1>().throttle = .4f;
        car.GetComponent<AIDriverLevel1>().angleModifier = 8f;
        car.GetComponent<AIDriverLevel1>().tracker.targetOffset = 33;

        cars.Add(car);
        return cars;
    }

    public List<GameObject> Level1a(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;

        for (int i = 1; i < 100; i++)
        {
            string name = $"'AI Level 1 Throttle: {i} / 100'";
            car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);
            car.name = name;
            car.GetComponent<VehicleStatsTracker>().vehicleName = name;
            car.GetComponent<AIDriverLevel1>().throttle = i / 100f;
            cars.Add(car);
        }
        return cars;
    }

    public List<GameObject> Level1b(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;

        for (int i = 3; i < 6; i++)
        {
            for (int j = 1; j < 40; j++)
            {
                string name = $"'AI Level 1 Throttle: {i} / 10, Angle: {j} / 2.5'";
                car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);

                car.name = name;
                car.GetComponent<VehicleStatsTracker>().vehicleName = name;

                car.GetComponent<AIDriverLevel1>().throttle = i / 10f;
                car.GetComponent<AIDriverLevel1>().angleModifier = j / 2f;

                cars.Add(car);
            }
        }
        return cars;
    }

    public List<GameObject> Level1c(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;

        for (int i = 0; i < 40; i++)
        {
            string name = $"'AI Level 1c Throttle: Follow Distance: {i}'";
            car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);

            car.name = name;
            car.GetComponent<VehicleStatsTracker>().vehicleName = name;

            car.GetComponent<AIDriverLevel1>().throttle = .4f;
            car.GetComponent<AIDriverLevel1>().angleModifier = 8f;
            car.GetComponent<AIDriverLevel1>().tracker.targetOffset = i;

            cars.Add(car);
        }
        return cars;
    }

    public List<GameObject> Level2(GameObject vehiclePrefab, Transform startingPosition)
    {
        List<GameObject> cars = new List<GameObject>();
        GameObject car;

        string name = $"'AI Level 2'";
        car = Instantiate(vehiclePrefab, startingPosition.position, startingPosition.rotation);

        car.name = name;
        car.GetComponent<VehicleStatsTracker>().vehicleName = name;
        //car.GetComponent<AIDriverLevel2>().throttle = .4f;
        cars.Add(car);
        return cars;
    }
}
