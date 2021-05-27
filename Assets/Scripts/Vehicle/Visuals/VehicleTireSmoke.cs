using UnityEngine;
using UnityEngine.VFX;
using Vehicle.Mechanics;

namespace Vehicle.Visuals
{
    public class VehicleTireSmoke : MonoBehaviour
    {
        VehicleController vc;
        WheelCollider[] wheelColliders;
        VisualEffect[] smoke;

        public Transform vfxParent;
        public GameObject smokePrefab;

        public float minSlip = 0.25f;
        public float maxSlip = 2f;
        public float smokeModifier = 10;
        public float multiplySize = 3.5f;


        void Start()
        {
            vc = this.GetComponent<VehicleController>();
            wheelColliders = vc.wheelColliders;

            smoke = new VisualEffect[wheelColliders.Length];
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                smoke[i] = Instantiate(smokePrefab, vfxParent, false).GetComponent<VisualEffect>();
                smoke[i].transform.position = wheelColliders[i].transform.position + new Vector3(0, -wheelColliders[i].radius, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                smoke[i].SetFloat("multiplySize", multiplySize);
                smoke[i].SetFloat("spawnRate", 0);
                WheelHit hit;
                if(wheelColliders[i].GetGroundHit(out hit))
                {
                    float slipTotal = Mathf.Abs(hit.forwardSlip) + Mathf.Abs(hit.sidewaysSlip);
                    if(slipTotal > minSlip)
                    {
                        slipTotal = Mathf.Min(maxSlip, slipTotal);
                        smoke[i].SetFloat("spawnRate", slipTotal * smokeModifier);
                    }
                
                }
            }


        }
    }
}
