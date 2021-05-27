using UnityEngine;

namespace Vehicle.Waypoints
{
    public class WaypointCircuit : MonoBehaviour
    {
        static WaypointCircuit _instance;
        public static WaypointCircuit Instance
        {
            get
            {
                if(_instance == null) Debug.Log("WaypointCircuit is null");
                return _instance;
            }
        }

        public Transform[] waypoints;
        public float substeps;
        public bool smooth = false;

        public Vector3[] points;
        public float[] distances;
        public float totalLength;
        public int waypointLength;


        void Awake()
        {
            _instance = this;
            if(waypoints.Length > 0)
            {
                // Assign each waypoint a position and accumuluated distance
                CalculatePointsAndDistances();
            }
        
        }

        void OnDrawGizmos()
        {
            if(waypoints.Length < 2) return;
            CalculatePointsAndDistances();
            DrawPathLines();
        }

        void CalculatePointsAndDistances()
        {
            // Calculates variables for the two arrays: points[] and distances[]
            // points[i] = Vector3 position of waypoints[i]
            // distances[i] = float value representiting the total accumulated distance from start to waypoints[i]
            waypointLength = waypoints.Length;

            points = new Vector3[waypointLength + 1];
            distances = new float[waypointLength + 1];

            float accumulatedDistance = 0;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = waypoints[i % waypointLength].position;
            
                distances[i] = accumulatedDistance;

                Vector3 currentPosition = waypoints[i % waypointLength].position;
                Vector3 nextPosition = waypoints[(i + 1) % waypointLength].position;

                accumulatedDistance += Vector3.Distance(currentPosition, nextPosition);
            }
        }

        private void DrawPathLines()
        {
            // Draws Gizmo line between each waypoint
            // if (smooth = true) add substeps to make the line more curved between points
            // else just have straight lines between each waypoint

            totalLength = distances[distances.Length - 1];

            Gizmos.color = Color.magenta;

            Vector3 previousPoint = points[0];

        

            if(smooth)
            {
                for (float dist = 0; dist < totalLength; dist += totalLength/substeps)
                {
                    Vector3 nextPoint = GetRoutePosition(dist+1);
                    Gizmos.DrawLine(previousPoint, nextPoint);
                    previousPoint = nextPoint;
                }
                Gizmos.DrawLine(previousPoint, waypoints[0].position); //Connect final point after loop
            }
            else
            {
                for (int i = 1; i < waypointLength + 1; i++)
                {
                    Vector3 nextPoint = points[i % waypointLength];
                    Gizmos.DrawLine(previousPoint, nextPoint);
                    previousPoint = nextPoint;
                }
            }
        }

        public (Vector3 position, Vector3 rotation) GetRoutePoint(float dist)
        {
            Vector3 p1 = GetRoutePosition(dist);
            Vector3 p2 = GetRoutePosition(dist + 0.1f);
            Vector3 rotation = (p2 - p1).normalized;
            return (p1, rotation);
        }

        public Vector3 GetRoutePosition(float dist)
        {
            // dist is current distance along path
            // like the float version of int of our current waypoint

            dist = Mathf.Repeat(dist, totalLength); // Cycles through totalLength. float version of % operator.

            int point = 0; // We need to cycle through the points and find the next point corresponding to being after our distance
            while(distances[point] < dist)
            {
                point++;
            }

            int previousPoint = (point - 2 + waypointLength) % waypointLength;
            int currentPoint = (point - 1 + waypointLength) % waypointLength;
            int nextPoint = point;
            int nextNextPoint = (point + 1) % waypointLength;

            // Gives the percentage dist is between currentPoint and nextPoint
            float i = Mathf.InverseLerp(distances[currentPoint], distances[nextPoint], dist);

            if(smooth)
            {
                Vector3 p0 = points[previousPoint];
                Vector3 p1 = points[currentPoint];
                Vector3 p2 = points[nextPoint];
                Vector3 p3 = points[nextNextPoint];

                return CatmullRom(p0, p1, p2, p3, i);
            }
            else
            {
                Vector3 p1 = points[currentPoint];
                Vector3 p2 = points[nextPoint];
                return Vector3.Lerp(p1, p2, i);
            }


        }

        private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            // https://www.mvps.org/directx/articles/catmull/
            // This is a formula for generating a spline using 4 points on a curve.
            // Returns a Vector3 representing the point along the spline between p1 and p2.
            // t is the percent distance the point is between p1 and p2
            // So if t = .50f, this returns the point along the curve halfway between p1 and p2

            return 0.5f * ((2 * p1) +
                           (-p0 + p2) * t +
                           (2 * p0 - 5 * p1 + 4 * p2 - p3) * t * t +
                           (-p0 + 3 * p1 - 3 * p2 + p3) * t * t * t);


        }
    }
}
