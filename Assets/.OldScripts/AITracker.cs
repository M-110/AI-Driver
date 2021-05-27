using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.Waypoints;

public class AITracker : MonoBehaviour
{
    public VehicleAIController controller;
    public AICheckpointManager cpManager;
    public Transform startingPos;
    public int currentCP = 0;
    public float followDistance = 10f;

    void Start()
    {
        cpManager = controller.cpManager;
    }
    private void Update()
    {

        if (Vector3.Distance(transform.position, controller.transform.position) < followDistance)
        {
            transform.LookAt(cpManager.checkpoints[currentCP + 1].transform.position);
            transform.Translate(0, 0, 1f);
        }

        if (Vector3.Distance(transform.position, cpManager.checkpoints[currentCP + 1].transform.position) < 1)
        {
            currentCP++;
            if (currentCP >= cpManager.checkpoints.Length)
            {
                currentCP = 0;
            }
        }
    }

    public void ResetTracker()
    {
        currentCP = 0;
        transform.position = startingPos.position;
    
    }




}
