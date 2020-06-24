using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Loop", menuName = "ScenarioActions/Loop")]
public class Loop : ScenarioAction {
    ScenarioController scenarioController;
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.ints[2]++;
        Debug.Log(scenarioStep.ints[2]);
        if (scenarioStep.ints[2] >= scenarioStep.ints[1])
        {
            scenarioStep.IsDone = true;
            scenarioStep.ints[2] = 0;
        }
        else
        {
            if (scenarioController == null)
                scenarioController = GameObject.FindObjectOfType<ScenarioController>();
            scenarioController.RemoveActiveStep(scenarioStep);
            scenarioController.AddActiveStep(scenarioStep.GetStep(scenarioStep.ints[0]));
        }
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.ints == null || step.ints.Length != 3)
            step.ints = new int[3];
        step.rect.width = 100;
        step.rect.height = 100;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Start id");
        step.ints[0] = EditorGUILayout.IntField(step.ints[0]);
        GUILayout.Label("Iteration count");
        step.ints[2] = 0;
        step.ints[1] = EditorGUILayout.IntField(step.ints[1]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
