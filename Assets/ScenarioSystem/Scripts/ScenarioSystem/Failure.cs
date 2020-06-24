using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Failure", menuName = "State(Check)/Failure")]
public class Failure : ScenarioAction {
    ScenarioController scenarioController;
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        if ((GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score - step.floats[0]) >= 0)
            GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score -= step.floats[0];
        else GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score = 0;
        Destroy(GameObject.FindGameObjectWithTag("Scenario"));
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.strings == null || step.strings.Length != 1)
            step.strings = new string[1];
        if (step.floats == null || step.floats.Length != 1)
        {
            step.floats = new float[1];
        }
        step.rect.width = 150;
        step.rect.height = 150;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Message: ");
        step.strings[0] = EditorGUILayout.TextField(step.strings[0]);
        GUILayout.Label("Penality score fail: ");
        step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
