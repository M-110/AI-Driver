using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Vehicle.AI;
using Vehicle.Stats;
using Vehicle.UI;

namespace Vehicle.Core
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] vehiclePrefabAI;
        public TestProfile testProfile = TestProfile.None;
        //public int vehicleAILevel;
        public GameObject vehiclePrefabHuman;
        public Transform startingPosition;
        public List<GameObject> activeCars = new List<GameObject>();
        GameObject currentCar;
        VehicleDriver driver;
        StatsDisplay statsDisplay;
        TestProfiles testProfiles;


        public int countdownLength = 3;


        [Button("Spawn Human",ButtonSizes.Large,ButtonStyle.CompactBox)]
        void SpawnHumanButton() {SpawnHuman();}
        [Button("Spawn AI",ButtonSizes.Large,ButtonStyle.CompactBox)]
        void SpawnAIButton() {Spawn();}

        void Awake()
        {
            statsDisplay = StatsDisplay.Instance;
            testProfiles = GetComponent<TestProfiles>();
        }
    

        void SpawnHuman()
        {
            int spawnCount = 0;
            for (int i = 0; i < 1; i++)
            {
                currentCar = Instantiate(vehiclePrefabHuman, startingPosition.position, startingPosition.rotation);
                currentCar.name = "'Human'";
                currentCar.GetComponent<VehicleStatsTracker>().vehicleName = "'Human'";
                activeCars.Add(currentCar);
                spawnCount++;
            }

            StartCoroutine(Countdown());
        }
    
        void Spawn()
        {
            int spawnCount = 0;

            if (testProfile == TestProfile.Level0)
                activeCars = testProfiles.Level0(vehiclePrefabAI[0], startingPosition);
            if (testProfile == TestProfile.Level1)
                activeCars = testProfiles.Level1(vehiclePrefabAI[1], startingPosition);
            else if (testProfile == TestProfile.Level1A)
                activeCars = testProfiles.Level1a(vehiclePrefabAI[1], startingPosition);
            else if (testProfile == TestProfile.Level1B)
                activeCars = testProfiles.Level1b(vehiclePrefabAI[1], startingPosition);
            else if (testProfile == TestProfile.Level1C)
                activeCars = testProfiles.Level1c(vehiclePrefabAI[1], startingPosition);
            else if (testProfile == TestProfile.Level2)
                activeCars = testProfiles.Level2(vehiclePrefabAI[2], startingPosition);
        
            StatsManager.Instance.carCount = spawnCount;

            StartCoroutine(Countdown());
        }

        IEnumerator Countdown()
        {
            statsDisplay.Countdown(countdownLength, activeCars[0].GetComponent<VehicleStatsTracker>());
            yield return new WaitForSeconds(countdownLength);
            foreach(GameObject car in activeCars)
            {
                car.GetComponent<VehicleDriver>().Initialize();
                car.GetComponent<VehicleStatsTracker>().StartRace();
            }
        }
    
    }

    public enum TestProfile
    {
        None,
        Level0,
        Level1,
        Level1A,
        Level1B,
        Level1C,
        Level2,

    }
}