using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTrackTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vehicle")
        {
            collision.gameObject.GetComponent<CarBrain>().Crash();
        }
    }
}
