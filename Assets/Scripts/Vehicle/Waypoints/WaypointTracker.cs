using UnityEngine;

namespace Vehicle.Waypoints
{
    public class WaypointTracker : MonoBehaviour
    {
        WaypointCircuit circuit;
        public bool smoothRoute;
        public Vector3 targetPosition;
        public Vector3 targetRotation;

        public float targetOffset = 10f;

        public int currentWaypoint;
        public float currentDistance;

        public Vector3 ProgressAlongRoute
        {
            // Returns approximate position the vehicle is along the routes curve
            get
            {
                return circuit.GetRoutePosition(currentDistance);
            }
        }

        void Start()
        {
            circuit = WaypointCircuit.Instance;
        }

        public void Reset()
        {
            currentDistance = 0;
            currentWaypoint = 0;
        }

        void Update()
        {
            // New unpacking feature in C# 7.0
            (targetPosition, targetRotation) = circuit.GetRoutePoint(currentDistance + targetOffset);

            Vector3 progressDelta = targetPosition - transform.position;

            // Direction from point along route to target position
            Vector3 rot1 = targetPosition - circuit.GetRoutePosition(currentDistance);
            // Direction from point along route to actual position
            Vector3 rot2 = transform.position - circuit.GetRoutePosition(currentDistance);
        
            // Dot product between the above direction vectors
            // If the dot product is greater than 0 then that means
            // the vehicle is further along the route than the currentDistance
            // and currentDistance must be moved forward
        
            if(Vector3.Dot(rot1,rot2) > 0)
            {
                currentDistance += progressDelta.magnitude * 0.1f;
            }
        }

    

        void OnDrawGizmos()
        {
            //Vector3 progressAlongRoute = circuit.GetRoutePosition(currentDistance);

            // adjacent
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, ProgressAlongRoute);

            // opposite
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(ProgressAlongRoute, targetPosition);

            // hypotenuse
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, targetPosition);

            // right angle
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(ProgressAlongRoute, Vector3.one);

            // target
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(targetPosition, 1);

        }
    }
}
