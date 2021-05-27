using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR) 

[ExecuteInEditMode]
// ReSharper disable once CheckNamespace
public class CheckpointPlacer : MonoBehaviour
{
    public CheckpointManagerEditor circuit;
    GameObject tracker;
    public GameObject firstCp;
    public GameObject cpPrefab;
    public float cpDistance = 1;
    int currentTrackerWp;
    bool go;
    int number = 1;
    float lastCpTime;

    public void CreateCheckpoints()
    {
        tracker = GameObject.Find("CPPLACER");
        if (tracker == null)
        {
            tracker = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            DestroyImmediate(tracker.GetComponent<Collider>());
        }
        tracker.transform.position = firstCp.transform.position;
        tracker.gameObject.name = "CPPLACER";
        lastCpTime = Time.time + cpDistance;
        currentTrackerWp = 0;
        number = 1;
        go = true;
    }

    void PlaceCheckPoint()
    {
        GameObject cp = Instantiate(cpPrefab, transform, true);
        cp.transform.position = tracker.transform.position;
        cp.transform.rotation = tracker.transform.rotation;
        cp.gameObject.name = "" + number;
        number++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!go) return;

        Quaternion rotation = Quaternion.LookRotation(circuit.checkpoints[currentTrackerWp].transform.position -
                            tracker.transform.position);
        tracker.transform.rotation = Quaternion.Slerp(tracker.transform.rotation, rotation, Time.deltaTime * 2);

        tracker.transform.Translate(0, 0, 1.0f);

        if (Vector3.Distance(tracker.transform.position, circuit.checkpoints[currentTrackerWp].transform.position) < 1)
        {
            currentTrackerWp++;
            if (currentTrackerWp >= circuit.checkpoints.Length)
                go = false; //we've reached the end
        }

        if (lastCpTime < Time.time)
        {
            PlaceCheckPoint();
            lastCpTime = Time.time + cpDistance;
        }

        EditorApplication.QueuePlayerLoopUpdate();
    }
}
#endif