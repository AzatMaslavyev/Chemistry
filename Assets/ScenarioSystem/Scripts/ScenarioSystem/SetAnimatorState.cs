using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "SetAnimatorState", menuName = "ScenarioActions/SetAnimatorState")]
public class SetAnimatorState : ScenarioAction {
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.IsDone = true;
        scenarioStep.gameObjects[0].GetComponent<Animator>().SetInteger("state", scenarioStep.ints[0]);
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];
        if (step.ints == null || step.ints.Length != 1)
            step.ints = new int[1];
        step.rect.height = 160;
        step.rect.width = 140;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Animator");
        GameObject[] gameObjects = step.gameObjects;
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("State");
        step.ints[0] = EditorGUILayout.IntField(step.ints[0]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
