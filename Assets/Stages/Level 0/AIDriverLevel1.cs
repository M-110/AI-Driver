using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.AI;
using Vehicle.Mechanics;
using Vehicle.Waypoints;

public class AIDriverLevel1 : VehicleDriver
{
    public float throttle = 0.5f;
    public float angleModifier = 10f;
    public VehicleController vc;
    public WaypointTracker tracker;
    public bool controllerActive = false;
    public float maxTimeBetweenCP = 4f;
    float timeSinceLastCP;


    public override void Initialize()
    {
        Debug.Log("STARTED");
        controllerActive = true;
    }

    void Awake()
    {
        vc = GetComponent<VehicleController>();
        tracker = GetComponent<WaypointTracker>();
        timeSinceLastCP = 0;
    }

    void Update()
    {
        //TEST = (transform.position - tracker.ProgressAlongRoute).x;
        float angleToTarget = transform.InverseTransformPoint(tracker.targetPosition).x;
        angleToTarget = Mathf.Abs(angleToTarget) < 1 ? 0 : angleToTarget / angleModifier;

        if(controllerActive)
        {
            timeSinceLastCP += Time.deltaTime;
            vc.SendInput(throttle, 0, Mathf.Clamp(angleToTarget, -1, 1), 0);
        }
    }

    public override void End()
    {
        

    }
}
