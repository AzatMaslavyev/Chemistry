using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "PickObject", menuName = "ScenarioActions/PickObject")]
public class PickObject : ScenarioAction {

    public override void DrawNodeWindow(int id)
    {
        if (step.gameObjects == null || step.gameObjects.Length==0)
            step.gameObjects = new GameObject[2];
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Interaction Object:");
        GUILayout.BeginHorizontal();
        //GUILayout.TextField("10f");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
