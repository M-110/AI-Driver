using UnityEngine;

namespace Vehicle2
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class BasicCarEngine : ScriptableObject, IEngine
    {
        [SerializeField] float torqueMultiplier;
        
        public float GetRPM(float wheelRPM)
        {
            throw new System.NotImplementedException();
        }
    }
}