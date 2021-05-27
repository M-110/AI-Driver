using UnityEngine;
using UnityEngine.VFX;
using Vehicle.Mechanics;

namespace Vehicle.Visuals
{
    public class SkidVFX : MonoBehaviour
    {
        public VehicleController vc;
        public VisualEffect skid;
        public WheelCollider wheel;
        // Start is called before the first frame update
        void Start()
        {
            vc = this.GetComponent<VehicleController>();

        }

        // Update is called once per frame
        void Update()
        {
            WheelHit hit;

            if(wheel.GetGroundHit(out hit))
            {
                skid.SetVector3("normal", hit.normal);

            }

        
        
        }
    }
}
