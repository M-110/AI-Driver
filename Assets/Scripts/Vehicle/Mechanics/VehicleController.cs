using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Vehicle.Mechanics
{
    public class VehicleController : MonoBehaviour
    {
        #region Inspector
        [FoldoutGroup ("Initial Settings", expanded:true)]
        [Title("Engine")]
        public float motorTorqueMultiplier = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [InlineButton("ResetTorqueCurve", "Reset Curve")]
        public AnimationCurve torqueCurve;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float idleRPM = 1000f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float maxRPM = 1000f;


        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float revLimiterDelta = 200f;

        [Title("Transmission")]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public float[] gearRatios = { 3.44f, 4.4f, 2.726f, 1.834f, 1.392f, 1f, .774f};

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float finalDriveRatio = 2.94f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float shiftDownRPM = 2000f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float shiftUpRPM = 6000f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("seconds", Overlay = true)]
        public float shiftUpTime = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("seconds", Overlay = true)]
        public float shiftDownTime = .5f;

        public enum DriveTrain
        {
            RearWheelDrive,
            FrontWheelDrive,
            AllWheelDrive
        }
        [Title("Tires")]
        [OnValueChanged("SetDriveWheels")]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public DriveTrain driveTrain = DriveTrain.AllWheelDrive;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [ReadOnly]
        public WheelCollider[] driveWheels;

        [InlineButton("SetWheelColliders")]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public WheelCollider[] wheelColliders;

        [PreviewField]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public GameObject wheelMeshPrefab;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [InlineButton("SetWheelMeshes")]
        public GameObject[] wheelMeshes;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float steeringSensitivity = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("degrees", Overlay = true)]
        public float maxSteerAngle = 30f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("degrees", Overlay = true)]
        public float minSteerAngle = 5f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("mph", Overlay = true)]
        public float steerAngleCutoffSpeed = 100f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("Newtons", Overlay = true)]
        public float brakeTorque = 2000f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float handBrakeSidewaysStiffness = .7f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float defaultSidewaysStiffness = .7f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [SuffixLabel("m/s", Overlay = true)]
        [OnValueChanged("SetWheelPhysicsSteps")]
        [MinValue(0)]
        [LabelWidth(250)]
        public float physicsSubstepsCriticalSpeed = 20f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [OnValueChanged("SetWheelPhysicsSteps")]
        [MinValue(0)]
        [LabelWidth(250)]
        public int physicsSubstepsStepBelow = 1;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [OnValueChanged("SetWheelPhysicsSteps")]
        [MinValue(0)]
        [LabelWidth(250)]
        public int physicsSubstepsStepAbove = 1;

        [Title("Driver Assist")]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public bool isTCSEnabled = true;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [Range(0,1)]
        public float tcsMinSlip = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [Range(0,1)]
        public float tcsStrength = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public bool isABSEnabled = true;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [Range(0,.6f)]
        public float absThreshold = .5f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public bool isESCEnabled = true;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [Range(0, 1)]
        public float escMinSlip = 1f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float escStrength = 1000f;


        [Title("Body")]
        [FoldoutGroup("Initial Settings", expanded: true)]
        public GameObject centerOfGravity;
        
        [FoldoutGroup("Initial Settings", expanded: true)]
        public float centerOfGravityHeight;

        [FoldoutGroup("Initial Settings", expanded: true)]
        [Range(0,1)]
        public float rearTrackLengthRatio = .5f;

        [FoldoutGroup("Initial Settings", expanded: true)]
        public float downForce = 25f;

        // Dynamic settings

        [FoldoutGroup("Dynamic Variables", expanded:true)]
        [Title("Engine Stats")]
        [SuffixLabel("rpm", Overlay = true)]
        public float averageWheelRPM;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [SuffixLabel("rpm", Overlay = true)]
        public float engineRPM;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [SuffixLabel("Newton-meter", Overlay = true)]
        public float engineTorque;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [SuffixLabel("Newton", Overlay = true)]
        public float wheelTorque;


        [Title("Transmission")]
        [FoldoutGroup("Dynamic Variables", expanded: true)]
        public int currentGear = 1;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        public float timeSinceLastShift = Mathf.Infinity;

        [Title("Input")]
        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ProgressBar(0,1, DrawValueLabel =false)]
        public float throttleInput = 0f;
        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ProgressBar(0, 1, DrawValueLabel = false, R =1)]
        public float brakeInput = 0f;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ProgressBar(0, 1, DrawValueLabel = false, G = 1)]
        public float handBrakeInput = 0;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [Range(-1,1)]
        public float steerInput = 0f;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [Range(-1,1)]
        public float torqueDirection = 1;

        [Title("Physics Stats")]
        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("m/s", Overlay = true)]
        public Vector3 localVelocity;

        [Title("Physics Stats")]
        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("m/s", Overlay = true)]
        public float forwardSpeed;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("mph", Overlay = true)]
        public float forwardSpeedMPH;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("m/s", Overlay = true)]
        public Vector3 forwardVelocity;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("m/s", Overlay = true)]
        public float rigidbodySpeed;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("mph", Overlay = true)]
        public float rigidbodySpeedMPH;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("G", Overlay = true)]
        public Vector3 rigidbodyAcceleration = Vector3.zero;

        [FoldoutGroup("Dynamic Variables", expanded: true)]
        [ReadOnly]
        [SuffixLabel("hp", Overlay = true)]
        public float horsepower;


        // Hidden from inspector
        Rigidbody rb;

        float smoothSteer = 0f;




        void ResetTorqueCurve()
        {
            /*torqueCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1000, 160), new Keyframe(1500, 240),
                    new Keyframe(2000, 280), new Keyframe(2500, 310), new Keyframe(3000, 320), new Keyframe(3500, 330),
                    new Keyframe(4000, 340), new Keyframe(4500, 350), new Keyframe(5000, 355), new Keyframe(5500, 348),
                    new Keyframe(6000, 332), new Keyframe(6500, 325), new Keyframe(7000, 40), new Keyframe(7500, 0));*/


            //2020 Hellcat
            /*torqueCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1000, 400), new Keyframe(1500, 600),
            new Keyframe(2000, 700), new Keyframe(2500, 760), new Keyframe(3000, 800), new Keyframe(3500, 827),
            new Keyframe(4000, 860), new Keyframe(4500, 875), new Keyframe(5000, 875), new Keyframe(5500, 855),
            new Keyframe(6000, 830), new Keyframe(6500, 0), new Keyframe(7000, 0));*/

            torqueCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1000, 75), new Keyframe(1500, 112),
                new Keyframe(2000, 127), new Keyframe(2500, 138), new Keyframe(3000, 147), new Keyframe(3500, 153),
                new Keyframe(4000, 158), new Keyframe(4500, 161), new Keyframe(5000, 163), new Keyframe(5500, 161),
                new Keyframe(6000, 152), new Keyframe(6500, 130), new Keyframe(7000, 0));


        }

        void SetDriveWheels()
        {
            
            if (driveTrain == DriveTrain.AllWheelDrive)
            {
                driveWheels = wheelColliders;
            }
            else if(driveTrain == DriveTrain.FrontWheelDrive)
            {
                driveWheels = new WheelCollider[2];

                driveWheels[0] = wheelColliders[0];
                driveWheels[1] = wheelColliders[1];
                    
            }
            else if(driveTrain == DriveTrain.RearWheelDrive)
            {
                driveWheels = new WheelCollider[2];

                driveWheels[0] = wheelColliders[2];
                driveWheels[1] = wheelColliders[3];
            }
            else
            {
                Debug.Log("Invalid Drive Train");
            }
        }
        void SetWheelColliders()
        {
            wheelColliders = gameObject.GetComponentsInChildren<WheelCollider>();

        }

        void SetWheelMeshes()
        {
            if (wheelMeshes != null)
            {
                foreach (GameObject wheelMesh in wheelMeshes)
                {
                    DestroyImmediate(wheelMesh);
                }
            }

            wheelMeshes = new GameObject[wheelColliders.Length];

            int i = 0;
            foreach (WheelCollider wheelCollider in wheelColliders)
            {
                var wheelMesh = Instantiate(wheelMeshPrefab);
                wheelMesh.transform.parent = wheelCollider.transform;
                wheelMesh.transform.localPosition = Vector3.zero;
                wheelMesh.transform.localRotation = Quaternion.identity;
                wheelMeshes[i] = wheelMesh;
                i++;

            }


        }

        void SetWheelPhysicsSteps()
        {
            foreach(WheelCollider wheel in wheelColliders)
            {
                wheel.ConfigureVehicleSubsteps(physicsSubstepsCriticalSpeed, physicsSubstepsStepBelow, physicsSubstepsStepAbove);
            }
        }

        private void CalculatePhysicsStats()
        {
            forwardSpeed = transform.InverseTransformDirection(rb.velocity).z;
            localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeedMPH = forwardSpeed * 2.23694f;
            rigidbodySpeed = rb.velocity.magnitude;
            rigidbodySpeedMPH = rigidbodySpeed * 2.23694f;
            horsepower = engineTorque * engineRPM / 5252;

            rigidbodyAcceleration =   CalculateGForce();
        }

        public Vector3 CalculateGForce()
        {
            Vector3 lastVelocity = forwardVelocity;
            forwardVelocity = rb.velocity;
            Vector3 acceleration = (forwardVelocity - lastVelocity) / Time.deltaTime;
            //forwardVelocity = transform.InverseTransformDirection(acceleration);

            return Vector3.Lerp(rigidbodyAcceleration, transform.InverseTransformDirection(acceleration), .2f);

        }



        
        #endregion


        void Start()
        {
            rb = GetComponent<Rigidbody>();
            SetWheelPhysicsSteps();
        }

        void FixedUpdate()
        {
            
            TorqueCalculations(); //calculate wheelTorque

            ApplySteering(); //ackerman steering + speed limited angle
            ApplyMotorTorque(); //apply wheelTorque, check TCS
            ApplyBrakeTorque(); //apply brakeTorque, check ABS
            ApplyESC(); //applies ESC (electronic stability control) if losing control
            ApplyHandBrake(); //lock back wheels, lower sideways friction

            CalculatePhysicsStats(); // --> forwardSpeed, etc

            ApplyDownForce(); // <-- apply downForce to rigidbody
            LoadShifting(); //set center of mass based on acceleration

        }

        void Update()
        {
            ShiftHandler(); //shift up or down

            UpdateWheelMeshAnimation(); // --> update Wheel Mesh position/rotation
        }

        #region Visuals
        void UpdateWheelMeshAnimation()
        {
            for (int i = 0; i < 4; i++)
            {
                wheelColliders[i].GetWorldPose(out Vector3 pos, out Quaternion rot);
                wheelMeshes[i].transform.position = pos;

                if (i == 0 || i == 2)
                    wheelMeshes[i].transform.rotation = rot;
                else
                    wheelMeshes[i].transform.rotation = rot * new Quaternion(0, 0, 1, 0);
            }
        }
        #endregion

        #region Input
        public void SendInput(float _throttleInput, float _brakeInput, float _steerInput, float _handBrakeInput)
        {
            handBrakeInput = _handBrakeInput;
            steerInput = _steerInput;

            if(forwardSpeed>.01f) // Forward
            {
                throttleInput = _throttleInput;
                brakeInput = _brakeInput;
                torqueDirection = 1;
            }
            else if(forwardSpeed < -.01f) // Reverse
            {
                throttleInput = _brakeInput;
                brakeInput = _throttleInput;
                torqueDirection = -0.5f;
            }
            else // Stopped
            {
                if((_throttleInput > 0) && (_brakeInput >0))
                {
                    // This would be revving engine
                    torqueDirection = 1;
                    throttleInput = _throttleInput;
                    brakeInput = _brakeInput;
                }
                else if(_throttleInput > 0)
                {
                    throttleInput = _throttleInput;
                    brakeInput = _brakeInput;
                    torqueDirection = 1;
                }
                else if(_brakeInput > 0)
                {
                    throttleInput = _brakeInput;
                    brakeInput = _throttleInput;
                    torqueDirection = -0.5f;
                }
                else
                {
                    throttleInput = _throttleInput;
                    brakeInput = _brakeInput;
                    torqueDirection = 1f;
                }
            }
        }
        #endregion

        #region DriveHandling

        void ShiftHandler()
        {
            timeSinceLastShift += Time.deltaTime;

            if (engineRPM > shiftUpRPM && timeSinceLastShift > shiftUpTime && currentGear < gearRatios.Length - 1)
            {
                //shift UP
                currentGear += 1;
                timeSinceLastShift = 0f;
            }
            else if (engineRPM < shiftDownRPM && timeSinceLastShift > shiftUpTime && currentGear > 1)
            {
                //shift DOWN
                currentGear -= 1;
                timeSinceLastShift = 0f;
            }
        }

        #endregion

        #region Physics

        void LoadShifting()
        {
            float trackWidth = Vector3.Distance(
                wheelColliders[0].transform.position, wheelColliders[1].transform.position);
            float trackLength = Vector3.Distance(
                wheelColliders[0].transform.position, wheelColliders[2].transform.position);

            float zLoadShift = 
                rearTrackLengthRatio - rigidbodyAcceleration.z / 9.8f * centerOfGravityHeight / trackLength;
            float xLoadShift = 
                .5f - rigidbodyAcceleration.x / 9.8f * centerOfGravityHeight / trackLength;

            centerOfGravity.transform.localPosition = 
                transform.InverseTransformPoint(wheelColliders[2].transform.position) + 
                        new Vector3(xLoadShift * trackWidth,
                                    centerOfGravityHeight - wheelColliders[0].radius,
                                    zLoadShift * trackLength);

            rb.centerOfMass = centerOfGravity.transform.localPosition;

        }

        void TorqueCalculations()
        {
            GetAverageWheelRPM();
            CalculateEngineRPM();
            CalculateEngineTorque();
            CalculateWheelTorque();
        }

        
        void GetAverageWheelRPM()
        {
            averageWheelRPM = driveWheels.Sum(wheel => Mathf.Abs(Mathf.Max(wheel.rpm, 0))) 
                              / driveWheels.Length;
        }

        void CalculateEngineRPM()
        {
            engineRPM = averageWheelRPM * gearRatios[currentGear] * finalDriveRatio;

            // must have minimum idle RPM

            engineRPM = Mathf.Max(idleRPM, engineRPM);
        }

        

        void CalculateEngineTorque()
        {
            engineTorque = torqueCurve.Evaluate(engineRPM) * motorTorqueMultiplier;
        }

        void CalculateWheelTorque()
        {
            wheelTorque = torqueDirection * engineTorque * gearRatios[currentGear] * finalDriveRatio 
                          / wheelColliders[0].radius / driveWheels.Length;
        }

        void ApplySteering()
        {
            for(int i = 0; i<2; i++)
            {
                wheelColliders[i].steerAngle = maxSteerAngle * steerInput;
            }

            // Steer angle lowers with speed
            // Input * maxAngle - (maxAngle - minAngle) * speed / cutoffSpeed
            float targetSteerAngle = steerInput * steeringSensitivity * Mathf.Deg2Rad * Mathf.Max(minSteerAngle, maxSteerAngle - ((maxSteerAngle - minSteerAngle) / (steerAngleCutoffSpeed)) * forwardSpeedMPH);

            targetSteerAngle = Mathf.Lerp(smoothSteer, targetSteerAngle, .15f);

            smoothSteer = targetSteerAngle; 

            // Ackerman steering
            // Formula Inside Wheel: arctan(2 * Length * sin(target angle) / ( (2 * Length * cos(target angle)) - (Width * sin(target angle)) 
            // Formula Outside Wheel: arctan(2 * Length * sin(target angle) / ( (2 * Length * cos(target angle)) + (Width * sin(target angle))
            float trackWidthAckerman = Vector3.Distance(wheelColliders[0].transform.position, wheelColliders[1].transform.position);
            float trackLengthAckerman = Vector3.Distance(wheelColliders[0].transform.position, wheelColliders[2].transform.position);

            float insideAckermanAngle = Mathf.Rad2Deg * Mathf.Atan(2 * trackLengthAckerman * Mathf.Sin(targetSteerAngle) / 
                                                                   (2 * trackLengthAckerman * Mathf.Cos(targetSteerAngle) - trackWidthAckerman * Mathf.Sin(targetSteerAngle)));


            float outsideAckermanAngle = Mathf.Rad2Deg * (Mathf.Atan(2 * trackLengthAckerman * Mathf.Sin(targetSteerAngle) /
                                                                     (2 * trackLengthAckerman * Mathf.Cos(targetSteerAngle) + trackWidthAckerman * Mathf.Sin(targetSteerAngle))));
            
            // if steering left, left = inside angle, right = outside angle
            if(smoothSteer <= 0)
            {
                wheelColliders[1].steerAngle = insideAckermanAngle;
                wheelColliders[0].steerAngle = outsideAckermanAngle;
            }
            // if steering right, right = inside angle, left = outside angle
            else
            {
                wheelColliders[0].steerAngle = insideAckermanAngle;
                wheelColliders[1].steerAngle = outsideAckermanAngle;
            }
        

        }

        void ApplyESC()
        {
            if (!isESCEnabled || !(handBrakeInput < 1f)) return;

            wheelColliders[2].GetGroundHit(out WheelHit hitBL);
            wheelColliders[3].GetGroundHit(out WheelHit hitBR);
            float slipAverage = (hitBL.sidewaysSlip + hitBR.sidewaysSlip) / 2f;

            if(slipAverage > escMinSlip)
                wheelColliders[3].brakeTorque = Mathf.Abs(slipAverage) * escStrength;
            else if(slipAverage < -escMinSlip)
                wheelColliders[2].brakeTorque = Mathf.Abs(slipAverage) * escStrength;
        }

        void ApplyMotorTorque()
        {
            foreach (WheelCollider wheel in driveWheels)
            {
                if (isTCSEnabled && averageWheelRPM < 100f)
                {
                    wheel.GetGroundHit(out WheelHit hit);
                    if (hit.forwardSlip > tcsMinSlip)
                        wheelTorque -= Mathf.Clamp(wheelTorque * hit.forwardSlip * tcsStrength, 0f, wheelTorque);
                }
                wheel.motorTorque = wheelTorque * throttleInput;
            }
        }

        void ApplyBrakeTorque()
        {
            foreach (WheelCollider wheel in driveWheels)
            {
                if (isABSEnabled && handBrakeInput < 1)
                {
                    wheel.GetGroundHit(out WheelHit hit);

                    if (Mathf.Abs(hit.forwardSlip) * brakeInput > absThreshold)
                        wheel.brakeTorque = 0f;
                    else
                        wheel.brakeTorque = brakeTorque * brakeInput;
                }
                else
                    wheel.brakeTorque = brakeTorque * brakeInput;
            }
        }

        void ApplyHandBrake()
        {
            for (int i = 2; i < 4; i++)
            {
                WheelFrictionCurve wfc = wheelColliders[i].sidewaysFriction;
                wfc.stiffness = defaultSidewaysStiffness;

                if (handBrakeInput > 0)
                {
                    wheelColliders[i].brakeTorque = 3000f;
                    wfc.stiffness = handBrakeSidewaysStiffness;
                }

                wheelColliders[i].sidewaysFriction = wfc;
            }
            
        }

        void ApplyDownForce()
        {
            rb.AddRelativeForce(Vector3.down * (rigidbodySpeed * downForce), ForceMode.Force);
        }

        #endregion
    }
}
