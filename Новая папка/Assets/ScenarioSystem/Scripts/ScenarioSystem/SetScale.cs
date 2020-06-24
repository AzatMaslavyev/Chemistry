using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SetScale", menuName = "ScenarioActions/SetScale")]
public class SetScale : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        Transform temp = scenarioStep.gameObjects[0].transform;
        Vector3 target = new Vector3(scenarioStep.floats[0], scenarioStep.floats[1], scenarioStep.floats[2]);
        temp.localScale = target;
        scenarioStep.IsDone = true;
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];
        if (step.floats == null || step.floats.Length != 3)
            step.floats = new float[3];

        this.step.rect.height = 100;
        this.step.rect.width = 170;
        GUILayout.Label("\n");
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("Target");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Scale");
        GUILayout.BeginHorizontal();
        step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        step.floats[1] = EditorGUILayout.FloatField(step.floats[1]);
        step.floats[2] = EditorGUILayout.FloatField(step.floats[2]);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
