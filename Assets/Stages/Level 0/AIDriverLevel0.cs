using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.AI;
using Vehicle.Mechanics;

public class AIDriverLevel0 : VehicleDriver
{
    public float throttle = 0.5f;
    public VehicleController vc;
    public bool controllerActive;
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
        timeSinceLastCP = 0;
    }

    void Update()
    {
        if(controllerActive)
        {
            timeSinceLastCP += Time.deltaTime;
            vc.SendInput(throttle, 0, 0, 0);
        }
    }

    public override void End()
    {
        

    }
}
