using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Rotation1", menuName = "ScenarioActions/Rotation1")]
public class Rotation1 : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        Transform temp = scenarioStep.gameObjects[0].transform;
        Quaternion rotation = Quaternion.Euler(scenarioStep.floats[0], scenarioStep.floats[1], scenarioStep.floats[2]);
        temp.localRotation = Quaternion.RotateTowards(temp.localRotation, rotation, Time.deltaTime * scenarioStep.floats[3]);
            if (temp.localRotation.Equals(rotation))
                scenarioStep.IsDone = true;
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];
        if (step.floats == null || step.floats.Length != 4)
            step.floats = new float[4];

        this.step.rect.height = 250;
        this.step.rect.width = 170;
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Target");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Rotation");
        GUILayout.BeginHorizontal();
        step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        step.floats[1] = EditorGUILayout.FloatField(step.floats[1]);
        step.floats[2] = EditorGUILayout.FloatField(step.floats[2]);
        GUILayout.EndHorizontal();
        GUILayout.Label("MoveSpeed");
        step.floats[3] = EditorGUILayout.FloatField(step.floats[3]);

        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}