using Cinemachine;
using UnityEngine;
using Vehicle.AI;
using Vehicle.Mechanics;

namespace Vehicle.Player
{
    public class VehiclePlayerController : VehicleDriver
    {
        public VehicleController vc;
        public VehicleControlsInput controls;


        public float throttleLimit = 1f;
        public float throttle;
        public float brake;
        public float handbrake;
        public float steer;

        public bool controllerActive = false;

        void Awake()
        {
            controls = new VehicleControlsInput();
            GameObject cam = GameObject.FindWithTag("FollowCam");
            vc = GetComponent<VehicleController>();
            cam.GetComponent<CinemachineVirtualCamera>().Follow = this.transform;
            cam.GetComponent<CinemachineVirtualCamera>().LookAt = this.transform;
        }

        private void OnEnable()
        {
            controls.VehicleControls.Enable();
        }

        private void OnDisable()
        {
            controls.VehicleControls.Disable();
        }

        public override void Initialize()
        {
            controllerActive = true;
        }

        public override void End()
        {
        }


        void Update()
        {
            if(controllerActive == false) return;
        
            throttle = controls.VehicleControls.AccelerateForward.ReadValue<float>() * throttleLimit;
            brake = controls.VehicleControls.AccelerateBackward.ReadValue<float>();
            steer = controls.VehicleControls.Steer.ReadValue<float>();
            handbrake = controls.VehicleControls.Handbrake.ReadValue<float>();

            vc.SendInput(throttle, brake, steer, handbrake);
        
        }
    }
}
