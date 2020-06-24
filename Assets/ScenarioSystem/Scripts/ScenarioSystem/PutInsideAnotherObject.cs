using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "PutInsideAnotherObject", menuName = "ScenarioActions/PutInsideAnotherObject")]
public class PutInsideAnotherObject : ScenarioAction {
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        if (scenarioStep.strings[0] != "" && !Input.GetKey(scenarioStep.strings[0]))
            return;
        scenarioStep.IsDone = true;
        scenarioStep.gameObjects[0].transform.SetParent(scenarioStep.gameObjects[1].transform);
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 2)
            step.gameObjects = new GameObject[2];
        if (step.strings == null || step.strings.Length != 1)
        {
            step.strings = new string[1];
            step.strings[0] = "";
        }
        this.step.rect.height = 130;
        GUILayout.Label("\n");
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("What to put?");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject),true);
        GUILayout.Label("Where to put?");
        gameObjects[1] = (GameObject)EditorGUILayout.ObjectField(gameObjects[1], typeof(GameObject), true);
        GUILayout.Label("Key");
        step.strings[0] = GUILayout.TextField(step.strings[0]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
