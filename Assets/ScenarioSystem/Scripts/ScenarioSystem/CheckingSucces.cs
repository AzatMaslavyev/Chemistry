using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "CheckingSuccess", menuName = "State(Check)/CheckingSuccess")]
public class CheckingSuccess : ScenarioAction
{
    ScenarioController scenarioController;
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        bool tagflag = false;
        string tag;
        tag = scenarioStep.gameObjects[0].tag;
        //scenarioStep.ints[2]++;
        //Debug.Log(scenarioStep.ints[2]);
        if (GameObject.FindGameObjectWithTag(tag)) tagflag = true;
        if (tagflag)
        {
            GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score += step.floats[0];

            if (scenarioController == null)
                scenarioController = GameObject.FindObjectOfType<ScenarioController>();
            scenarioController.RemoveActiveStep(scenarioStep);
            scenarioController.AddActiveStep(scenarioStep.GetStep(scenarioStep.ints[0]));

        }
        else
        {
            scenarioStep.IsDone = true;
        }

    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];

        if (step.ints == null || step.ints.Length != 1)
            step.ints = new int[1];
        if (step.floats == null || step.floats.Length != 1)
        {
            step.floats = new float[2];
        }

        step.rect.width = 150;
        step.rect.height = 220;
        GUILayout.Label("\n");
        GUILayout.BeginVertical();
        GUILayout.Label("Start id");
        GameObject[] gameObjects = step.gameObjects;
        step.ints[0] = EditorGUILayout.IntField(step.ints[0]);
        GUILayout.Label("Victory score: ");
        step.floats[1] = EditorGUILayout.FloatField(step.floats[1]);
        GUILayout.Label("Tag: ");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}
