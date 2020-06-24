using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "ObjectActivation", menuName = "ScenarioActions/ObjectActivation")]
public class ObjectActivation : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.gameObjects[0].SetActive(scenarioStep.ints[0]==1);
        scenarioStep.IsDone = true;
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;
        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];
        if (step.ints == null || step.ints.Length != 1)
            step.ints = new int[1];
        step.rect.width = 140;
        GUILayout.BeginVertical();
        GUILayout.Label("\n Object");
        GameObject[] gameObjects = step.gameObjects;
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
         if (GUILayout.Toggle(step.ints[0] == 1, "SetActive"))
             step.ints[0] = 1;
         else step.ints[0] = 0;
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
