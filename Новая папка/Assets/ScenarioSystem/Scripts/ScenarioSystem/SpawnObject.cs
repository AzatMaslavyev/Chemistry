using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "SpawnObject", menuName = "ScenarioActions/SpawnObject")]
public class SpawnObject : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.IsDone = true;
        if (scenarioStep.gameObjects[0] == null)
            return;
        GameObject go = Instantiate(scenarioStep.gameObjects[0]);
        go.transform.SetParent(scenarioStep.gameObjects[1].transform);
        go.transform.localPosition = new Vector3(scenarioStep.floats[0], scenarioStep.floats[1], scenarioStep.floats[2]);
        go.transform.rotation = Quaternion.Euler(scenarioStep.floats[3], scenarioStep.floats[4], scenarioStep.floats[5]);
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 2)
            step.gameObjects = new GameObject[2];
        if (step.floats == null || step.floats.Length != 6)
            step.floats = new float[6];

        this.step.rect.height = 230;
        this.step.rect.width = 170;
        
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Prefab");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Parent");
        gameObjects[1] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);

        GUILayout.Label("Local Pos:");
        GUILayout.BeginHorizontal();
        step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        step.floats[1] = EditorGUILayout.FloatField(step.floats[1]);
        step.floats[2] = EditorGUILayout.FloatField(step.floats[2]);
        GUILayout.EndHorizontal();
        GUILayout.Label("Rotation:");
        GUILayout.BeginHorizontal();
        step.floats[3] = EditorGUILayout.FloatField(step.floats[3]);
        step.floats[4] = EditorGUILayout.FloatField(step.floats[4]);
        step.floats[5] = EditorGUILayout.FloatField(step.floats[5]);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
