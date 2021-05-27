using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(CheckpointPlacer))]
// ReSharper disable once CheckNamespace
public class CheckPointCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CheckpointPlacer myScript = (CheckpointPlacer)target;
        if (GUILayout.Button("Create Checkpoints"))
        {
            myScript.CreateCheckpoints();
        }
    }
}
