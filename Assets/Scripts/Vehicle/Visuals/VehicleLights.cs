using Sirenix.OdinInspector;
using UnityEngine;
using Vehicle.Mechanics;

namespace Vehicle.Visuals
{
    public class VehicleLights : MonoBehaviour
    {
        VehicleController vc;
        [Title("Brake Lights")]
        public Color brakeColorOn;
        public float brakeEmissionIntesityOn;
        public Color brakeColorOff;
        public Renderer[] brakeRenderers;
        public Light[] mainBrakeLights;
        public float mainBrakeLightsIntesity = 0.92f;
        public Light[] miniBrakeLights;
        public float miniBrakeLightsIntesity = 0.33f;
        MaterialPropertyBlock block;
        public float brakesRate =.05f;
        [Title("Reverse Lights")]
        public Color reverseLightOn;
        public float reverseEmissionIntesityOn;
        public Color reverseLightOff;
        public Renderer[] reverseRenderers;
        public Light[] reverseLights;
        public float reverseLightIntesity = .4f;
        // Start is called before the first frame update
        void Start()
        {
            vc = this.GetComponent<VehicleController>();
            block = new MaterialPropertyBlock();
        }

        // Update is called once per frame
        void Update()
        {
            SetBrake(vc.brakeInput > 0);
        }

    

        void SetBrake(bool brakeOn)
        {
            if(brakeOn)
            {
                // Brake Light Material On
                foreach(Renderer brake in brakeRenderers)
                {
                    AnimateMaterialColorAndEmission(brake, brakeColorOn, brakeColorOn, brakeEmissionIntesityOn, brakesRate);
                }
                // Brake Light On
                foreach(Light light in mainBrakeLights)
                {
                    AnimateLights(light,mainBrakeLightsIntesity,brakesRate);
                }
            }
            else
            {
                // Brake Light Material Off
                foreach (Renderer brake in brakeRenderers)
                {
                    AnimateMaterialColorAndEmission(brake, brakeColorOff, brakeColorOff, 0, brakesRate);
                }
                // Brake Lights Off
                foreach(Light light in mainBrakeLights)
                {
                    AnimateLights(light,0,brakesRate);
                }
            }
        }

        void AnimateLights(Light light, float lightIntesity, float rate)
        {
            // Lerp light intesity towards target intensity.
            // if it is within .01f of the target intensity, simply set it to the target intesity
            float currentIntesity = light.intensity;
            if (Mathf.Abs(lightIntesity - Mathf.Lerp(currentIntesity, lightIntesity, rate)) < .01f)
            {
                light.intensity = lightIntesity;
            }
            else
            {
                light.intensity = Mathf.Lerp(currentIntesity, lightIntesity, rate);
            }
        }

        void AnimateMaterialColorAndEmission(Renderer renderer, Color color, Color emissionColor, float emissionIntesity, float rate)
        {
            renderer.GetPropertyBlock(block);
            Color currentColor = block.GetColor("_Color");
            block.SetColor("_Color", Color.Lerp(currentColor, color, rate));
            Color currentEmissionColor = block.GetColor("_EmissionColor");
            block.SetColor("_EmissionColor", Color.Lerp(currentEmissionColor, emissionColor * emissionIntesity, rate));
            renderer.SetPropertyBlock(block);
        }

        void SetReverseLights(bool reverseOn)
        {
            if(reverseOn)
            {

            }
        }
    }
}
