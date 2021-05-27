using UnityEngine;
using Sirenix.OdinInspector;


// ReSharper disable once CheckNamespace
public class CheckpointManagerEditor : MonoBehaviour
{
    
    [InlineButton("UpdateCP", "Update Checkpoints")]
    public CheckpointRoller[] checkpoints;

    void UpdateCP()
    {
        checkpoints = GetComponentsInChildren<CheckpointRoller>();
    }

    [Button("Snap To Ground")]
    public void SnapToGround()
    {
        foreach(CheckpointRoller cp in checkpoints)
        {
            RaycastHit hitInfo;
            var hits = Physics.RaycastAll(cp.transform.position + Vector3.up, Vector3.down, 10f);
            foreach(var hit in hits)
            {
                if (hit.collider.gameObject == cp.gameObject)
                    continue;

                cp.transform.position = hit.point;
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        checkpoints = GetComponentsInChildren<CheckpointRoller>();
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (i == checkpoints.Length - 1)
            {
                Gizmos.DrawLine(checkpoints[i].transform.position, checkpoints[0].transform.position);
            }
            else
            {
                Gizmos.DrawLine(checkpoints[i].transform.position, checkpoints[i + 1].transform.position);
            }
        }
        //Gizmos.DrawLine()
    }
}
