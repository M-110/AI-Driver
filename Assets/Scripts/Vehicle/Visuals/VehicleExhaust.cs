using UnityEngine;
using UnityEngine.VFX;
using Vehicle.Mechanics;

namespace Vehicle.Visuals
{
    public class VehicleExhaust : MonoBehaviour
    {
        public VisualEffect visualEffect;
        VehicleController vc;

        // Start is called before the first frame update
        void Start()
        {
            vc = this.GetComponent<VehicleController>();
        }

        // Update is called once per frame
        void Update()
        {
            if(vc.rigidbodySpeedMPH < 12)
            {
                visualEffect.SetFloat("spawnRate", 12-vc.rigidbodySpeedMPH );
            }
            else
            {
                visualEffect.SetFloat("spawnRate", 0);
            }
        }
    }
}
