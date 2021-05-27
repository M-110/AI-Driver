using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.AI;
using Vehicle.Mechanics;
using Vehicle.Waypoints;

public class AIDriverLevel2 : VehicleDriver
{
    #region main
    public VehicleController vc;
    public WaypointTracker tracker;
    public bool controllerActive;

    public float maxTimeBetweenCP = 4f;
    float timeSinceLastCP;
    #endregion main

    #region telemetry
    [SerializeField] float speed;
    #endregion telemetry

    public override void Initialize()
    {
        controllerActive = true;
    }

    void Awake()
    {
        vc = GetComponent<VehicleController>();
        tracker = GetComponent<WaypointTracker>();
    }

    void Update()
    {
        if (!controllerActive) return;
        timeSinceLastCP += Time.deltaTime;
        UpdateTelemetry();

        Drive();
    }

    void UpdateTelemetry()
    {
        vc.rigidbodySpeed = speed;
    }
    void Drive()
    {
        
        float angleToTarget = transform.InverseTransformPoint(tracker.targetPosition).x;
        //angleToTarget = Mathf.Abs(angleToTarget) < 1 ? 0 : angleToTarget / angleModifier;
        
        float steer = Mathf.Clamp(angleToTarget, -1, 1);
       // vc.SendInput(throttle * (1 - Mathf.Abs(steer)) , 0, steer , 0);
    }


    public override void End()
    {
        

    }
}
