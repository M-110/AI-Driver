using UnityEngine;
using Vehicle.Waypoints;

namespace Vehicle.Stats
{
    public class Stats
    {
        public string name;
        public int cp; //checkpoints reached
        public float d; //total distance
        public float t; //total time
        public float s1; //sector 1 time
        public float s2; //sector 2 time
        public float s3; //sector 3 time
        public float s4; //sector 4 time
        public float lap; //lap time

        public Stats(string name, int cp, float d, float t, float s1, float s2, float s3, float s4, float lap)
        {
            this.name = name;
            if(cp == 0) this.cp = 88; else this.cp = cp;
            this.d = d;
            this.t = t;
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            this.s4 = s4;
            this.lap = lap;
        }
    }

    public class VehicleStatsTracker : MonoBehaviour
    {
        public string vehicleName;
        float timeSinceLastCp;
        [SerializeField] float maxTimeBetweenCp = 4f;

        public int currentCheckpoint;
        public int currentSector = 1;
        public float totalTime = 0;

        [SerializeField] float sector1Time = -1;
        [SerializeField] float sector2Time = -1;
        [SerializeField] float sector3Time = -1;
        [SerializeField] float sector4Time = -1;
        [SerializeField] float lapTime = -1;

        public AICheckpointManager checkpointManager;

        [SerializeField] int sector1finalCP = 21;
        [SerializeField] int sector2finalCP = 50;
        [SerializeField] int sector3finalCP = 73;
        public bool racing = false;

        void Start()
        {
            checkpointManager = AICheckpointManager.Instance;
            totalTime = 0;
            timeSinceLastCp = 0;
            racing = false;
        }

    

        void Update()
        {
            if (!racing) return;

            totalTime += Time.deltaTime;
            timeSinceLastCp += Time.deltaTime;

            if(timeSinceLastCp > maxTimeBetweenCp)
            {
                Debug.Log("Too slow");
                EndRace();
            }

            UpdateSectorsAndTimes();
        }

        void UpdateSectorsAndTimes()
        {
            if (currentCheckpoint > sector1finalCP && currentSector < 2)
            {
                sector1Time = totalTime;
                currentSector++;
            }
            else if (currentCheckpoint > sector2finalCP && currentSector < 3)
            {
                sector2Time = totalTime - sector1Time;
                currentSector++;
            }
            else if (currentCheckpoint > sector3finalCP && currentSector < 4)
            {
                sector3Time = totalTime - sector1Time - sector2Time;
                currentSector++;
            }
            else if (currentCheckpoint == 0 && currentSector == 4)
            {
                sector4Time = totalTime - sector1Time - sector2Time - sector3Time;
                lapTime = totalTime;
                EndRace();
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject == checkpointManager.checkpoints[currentCheckpoint + 1].gameObject)
            {
                currentCheckpoint++;
                timeSinceLastCp = 0;
                if(currentCheckpoint == checkpointManager.checkpoints.Length - 1) currentCheckpoint = 0;
            }

            if(collider.tag == "wall")
            {
                Debug.Log("Hit wall");
                EndRace();
            }

        }

        public void StartRace()
        {
            racing = true;
        }

        public void EndRace()
        {
            float distanceTraveled = GetComponent<WaypointTracker>().currentDistance;
            if(lapTime>-1) distanceTraveled = 1429f;
            Stats stats = new Stats(vehicleName, currentCheckpoint, distanceTraveled, totalTime, sector1Time, sector2Time, sector3Time, sector4Time, lapTime);

            StatsManager.Instance.AddStats(stats);

            racing = false;

            //Destroy self
        }


    }
}