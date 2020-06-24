using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "Wait", menuName = "ScenarioActions/Wait")]
public class Wait : ScenarioAction {
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.floats[1] -= Time.deltaTime;
        Debug.Log(scenarioStep.floats[1]);
        if (scenarioStep.floats[1] < 0)
        {
          
            scenarioStep.IsDone = true;

            scenarioStep.floats[1] = scenarioStep.floats[0];
        }
        
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.floats == null || step.floats.Length != 2)
            step.floats = new float[2];
        step.rect.width = 100;
        step.rect.height = 120;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Time");
        GameObject[] gameObjects = step.gameObjects;
        step.floats[1] = step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
