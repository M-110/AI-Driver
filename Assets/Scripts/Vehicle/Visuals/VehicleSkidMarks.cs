using UnityEngine;
using Vehicle.Mechanics;

namespace Vehicle.Visuals
{
    public class VehicleSkidMarks : MonoBehaviour
    {
        WheelCollider[] wheels;
        public VehicleController vc; // Connection to vehicle to get wheels and velocity
        VehicleSkidController sc; // 

        public int[] lastSkid;

        public float skidMultiplier = 10.0f; //Multiplies how much skids show
        public float skidMinSlipSpeed = 0.5f; // Won't apply marks below this speed;
        public float maxSpeedIntensity = 20.0f; // Speed where opacity reaches max
    
        void Start()
        {
            sc = VehicleSkidController.Instance;
            vc = this.GetComponent<VehicleController>();
            wheels = vc.wheelColliders;

            lastSkid = new int[wheels.Length];
            for (int i = 0; i < lastSkid.Length; i++)
            {
                lastSkid[i] = -1;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //CalculateSkid1();
            CalculateSkid3();

        }
/*
    void CalculateSkid1()
    {
        foreach (WheelCollider wheel in wheels)
        {
            WheelHit hit;
            if (wheel.GetGroundHit(out hit))
            {
                Vector3 localVelocity = vc.localVelocity;
                float skidTotal = Mathf.Abs(localVelocity.x);

                float wheelAngularVelocity = wheel.radius * ((2 * Mathf.PI * wheel.rpm) / 60);
                float wheelSpin = Mathf.Abs(localVelocity.z - wheelAngularVelocity) * skidMultiplier;

                skidTotal += wheelSpin;

                if(skidTotal >= skidMinSlipSpeed)
                {
                    float intensity = Mathf.Clamp01(skidTotal / maxSpeedIntensity);
                    lastSkid = sc.AddSkidMark(hit.point, hit.normal, intensity, lastSkid);
                }
                else
                {
                    lastSkid = -1;
                }
            }
            else
            {
                lastSkid = -1;
            }
        }
    }

    void CalculateSkid2()
    {
        foreach (WheelCollider wheel in wheels)
        {
            WheelHit hit;
            if (wheel.GetGroundHit(out hit))
            {
                float slipTotal = Mathf.Abs(hit.forwardSlip) + Mathf.Abs(hit.sidewaysSlip);
                if(slipTotal > skidMinSlipSpeed)
                {
                    float skidIntensity = Mathf.Clamp01(slipTotal / maxSpeedIntensity);
                    Debug.Log(hit.normal);
                    lastSkid = sc.AddSkidMark(hit.point, hit.normal, skidIntensity, lastSkid);
                }
                else lastSkid = -1;
            }
            else lastSkid = -1;
        }
    }*/

        void CalculateSkid3()
        {
            int i = 0;
            foreach (WheelCollider wheel in wheels)
            {
                WheelHit hit;
                if (wheel.GetGroundHit(out hit))
                {
                    float slipTotal = Mathf.Abs(hit.forwardSlip) + Mathf.Abs(hit.sidewaysSlip);
                    if(slipTotal > skidMinSlipSpeed)
                    {
                        float skidIntensity = Mathf.Clamp01(slipTotal / maxSpeedIntensity);
                        lastSkid[i] = sc.AddSkidMark(hit.point, hit.normal, skidIntensity, lastSkid[i]);
                    }
                    else lastSkid[i] = -1;
                }
                else lastSkid[i] = -1;
                i++;
            }
        }
    }
}
