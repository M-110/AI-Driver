using UnityEngine;

namespace Vehicle.AI
{
    public abstract class VehicleDriver : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void End();
    }
}
