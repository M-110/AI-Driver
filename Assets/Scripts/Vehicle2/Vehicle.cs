using System.Linq;
using UnityEngine;

namespace Vehicle2
{
    public class Vehicle
    {
        IEngine engine;
        float currentRPM;
        WheelCollider[] driveWheels;

        float WheelRPM => driveWheels.Sum(wheel => Mathf.Abs(Mathf.Max(wheel.rpm, 0))) 
                          / driveWheels.Length;
        void Update()
        {
            engine.GetRPM(WheelRPM);
        }
    }
}