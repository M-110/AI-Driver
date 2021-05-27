using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.Mechanics;

public class TestCar : MonoBehaviour
{

    float timer = 0f;
    bool testing = true;
    bool done = false;
    VehicleController vc;
    public float speedGoal = 60f;
    public float angleGoal = 90f;
    public Transform startTurnTransform;
    public Transform endTurnTransform;
    // Start is called before the first frame update
    void Start()
    {
        
        vc = GetComponent<VehicleController>();
        vc.throttleInput = 1;
        //Invoke("TurnTest2", 6f);
        //InvokeRepeating("TurnTest", 6f, 2f);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (vc.forwardSpeedMPH > speedGoal)
        {
            if(testing == true)
            {
                testing = false;
                startTurnTransform.position = transform.position;
                startTurnTransform.rotation = transform.rotation;
            }
            
            vc.steerInput = 1;

            
        }
        if (testing == false && done == false)
        {
            //print(Vector3.Angle(startTurnTransform.forward, transform.forward));
            if (Vector3.Angle(startTurnTransform.forward, transform.forward) > angleGoal)
            {
                done = true;
                endTurnTransform.position = transform.position;
                endTurnTransform.rotation = transform.rotation;
                print("Turning Radius: " + Mathf.Sqrt(Mathf.Pow(Vector3.Distance(startTurnTransform.position, endTurnTransform.position), 2) / 2f) + " at speed " + speedGoal + " and angle " + angleGoal);
            }

        }
    }

    private void SpeedTest()
    {
        if (!testing) return;

        timer += Time.deltaTime;

        vc.throttleInput = 1f;
        if (vc.forwardSpeedMPH > speedGoal)
        {
            Debug.Log(timer + " at " + vc.tcsMinSlip);
            testing = false;
            vc.brakeInput = 1f;
            vc.throttleInput = 0f;
        }
    }
    private void TurnTest()
    {
        vc.steerInput *= -1;
    }
    private void TurnTest2()
    {
        vc.steerInput = -1;
    }

}
