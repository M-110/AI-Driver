using UnityEngine;
using Vehicle.Mechanics;
using Vehicle.Waypoints;

namespace Vehicle.AI
{
    public class AIDriver : MonoBehaviour
    {
        public VehicleController car;
        public float followDistance = 10f;
        public Vector3 trackerPosition = new Vector3(0, 0, 0);
        public AICheckpointManager checkpointManager;
        public int currentTrackerCheckpoint;
        public int currentCarCheckpoint;
    
        public GameObject trackerBall;
        public GameObject virtualCp;
        public GameObject virtualTrackerCp;
    
        
        public float steer;
    
    
        private void Awake()
        {
            car = GetComponent<VehicleController>();
            trackerPosition = transform.position;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(trackerPosition,
                checkpointManager.checkpoints[currentTrackerCheckpoint + 1].transform.position) < 4.0f)
            {
                currentTrackerCheckpoint++;
            }
    
            if(Vector3.Distance(this.transform.position, trackerPosition) < followDistance)
            {
                Vector3 directionToTracker =
                    (checkpointManager.checkpoints[currentTrackerCheckpoint + 1].transform.position - trackerPosition)
                    .normalized;
                trackerPosition += directionToTracker * 0.5f;
            }
    
            UpdateTrackers();
            Drive();
    
        }
    
        void UpdateTrackers()
        {
            trackerBall.transform.position = trackerPosition;
            virtualCp.transform.position =
                checkpointManager.checkpoints[currentTrackerCheckpoint + 1].transform.position;
            virtualTrackerCp.transform.position =
                checkpointManager.checkpoints[currentCarCheckpoint + 1].transform.position;
        }
    
        void Drive()
        {
            car.throttleInput = .5f;
    
            Steer();
        }
    
        void Steer()
        {
            Vector3 target = transform.InverseTransformPoint(trackerPosition);
            steer = Mathf.Atan2(target.x, target.y);
            //steer = Mathf.Atan2(trackerBall.transform.position.x, trackerBall.transform.position.x);
            car.steerInput = steer;
        }
    }
    
}

