using UnityEngine;

namespace Vehicle.Waypoints
{
    public class AICheckpoint : MonoBehaviour
    {
        public float distanceNextCp;
        public float angleNextCp;
        public float heightDeltaNextCp;
        public float averageAngleNextThreeCp;
        public float dangerValue;

        public AICheckpoint prevCp;
        public AICheckpoint nextCp;
    
        public void StatUpdate()
        {
            Vector3 position = transform.position;
            Vector3 nextCpPosition = nextCp.transform.position;
            
            distanceNextCp = Vector3.Distance(position, nextCpPosition);
            angleNextCp = Vector3.Angle(position - prevCp.transform.position, nextCpPosition - position);
            heightDeltaNextCp = position.y - nextCpPosition.y;

            averageAngleNextThreeCp = (angleNextCp + nextCp.angleNextCp + nextCp.nextCp.angleNextCp) / 3f;
            dangerValue = averageAngleNextThreeCp + heightDeltaNextCp * 10f;
        }
    }
}
