using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.Mechanics;
using Vehicle.Waypoints;

public class VehicleAIController : MonoBehaviour
{
    public AITracker tracker;
    public int currentWP;
    public AICheckpointManager cpManager;
    public VehicleController car;
    public CarBrain carBrain;
    public float combinedThrottleBrake;
    public float throttle = 1f;
    public float brake = 0f;
    public float handbrake = 0f;
    public float steer = 0f;
    public float angleToTarget;

    public float timeStalled = 0f;
    public List<float> parameters = new List<float>();

    void Start()
    {
        carBrain = GetComponent<CarBrain>();
    }

    private void Update()
    {
        CheckForStall();

        ManageCheckpoints();

        CalculateSteer();

        CalculateThrottleAndBrake();

        car.SendInput(Mathf.Clamp01(throttle), Mathf.Clamp01(brake), steer, handbrake);
    }

    private void ManageCheckpoints()
    {
        if(Vector3.Distance(transform.position, cpManager.checkpoints[currentWP+1].transform.position) < 5f)
        {
            if (currentWP >= cpManager.checkpoints.Length)
            {
                //CarBrain.FinishRace();
            }
            else
            {
                currentWP++;
                //carAgent.CheckpointSuccess();
            }
        }
    }

    private void CalculateThrottleAndBrake()
    {
        //float dangerValue = cpManager.checkpoints[tracker.currentCP].dangerValue;
        //float danger = Mathf.Max(angleToTarget, dangerValue) / (10f * floatA);
        //float speedMultiplier = Mathf.Pow(1f - (1f / (200f * floatB)), 2f * floatC);
        //combinedThrottleBrake = Mathf.Clamp01(1 - (1 * speedMultiplier * floatD) + floatE);

        if (combinedThrottleBrake >= .5f)
        {
            throttle = 2 * combinedThrottleBrake - 1f;
            brake = 0f;
        }
        else
        {
            //throttle = 0;
            //brake = 1 - 2 * combinedThrottleBrake;
            throttle = 1;
        }
    }

    private void CalculateSteer()
    {
        Vector3 target;
        float targetAngle;
        target = transform.InverseTransformPoint(tracker.transform.position);
        targetAngle = Mathf.Atan2(target.x, target.z) * 2;
        angleToTarget = Vector3.Angle(transform.forward, tracker.transform.position - transform.position);
        steer = Mathf.Clamp(targetAngle, -1, 1);
    }

    public void ResetController()
    {
        currentWP = 0;
    }

    
    public void CheckForStall()
    {
        if( car.forwardSpeedMPH < 5f)
        {
            timeStalled += Time.deltaTime;
            if(timeStalled>10f)
            {
                carBrain.Crash();
                timeStalled = 0f;
            }
        }
        else
        {
            timeStalled = 0f;
        }
    }

}
