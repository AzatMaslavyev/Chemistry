using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "MoveLocalTo", menuName = "ScenarioActions/MoveLocalTo")]
public class MoveLocalTo : ScenarioAction {

    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        Transform temp = scenarioStep.gameObjects[0].transform;
        Vector3 target = new Vector3(scenarioStep.floats[0], scenarioStep.floats[1], scenarioStep.floats[2]);
        temp.localPosition = Vector3.MoveTowards(temp.localPosition, target, Time.deltaTime * scenarioStep.floats[3]);
        if (temp.localPosition.Equals(target))
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

        this.step.rect.height = 130;
        this.step.rect.width = 170;
        GUILayout.Label("\n");
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("What to move?");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Target vector");
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
