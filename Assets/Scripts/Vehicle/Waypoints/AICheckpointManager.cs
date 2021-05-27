using Sirenix.OdinInspector;
using UnityEngine;

namespace Vehicle.Waypoints
{
    public class AICheckpointManager : MonoBehaviour
    {
        static AICheckpointManager _instance;
        public static AICheckpointManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.Log("AICheckpointManager is null");
                }
                return _instance;
            }

        }
        public AICheckpoint[] checkpoints;

    


        void Awake()
        {
            _instance = this;

        }

        [Button("Update Checkpoints")]
        public void UpdateCheckpointArray()
        {
            checkpoints = GetComponentsInChildren<AICheckpoint>();

            int i = 0;
            foreach(AICheckpoint cp in  checkpoints)
            {
                if (i == checkpoints.Length -1)
                {
                    checkpoints[i].nextCp = checkpoints[0];
                }
                else
                {
                    checkpoints[i].nextCp = checkpoints[i + 1];

                    i++;
                }
            }

            i = 0;
            foreach (AICheckpoint cp in checkpoints)
            {
                if(i==0)
                {
                    checkpoints[i].prevCp = checkpoints[checkpoints.Length-1];
                }
                else
                {
                    checkpoints[i].prevCp = checkpoints[i - 1];
                }

                i++;
            }

            foreach (AICheckpoint cp in checkpoints)
            {
                cp.StatUpdate();
            }
        }
    }
}
