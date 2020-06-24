using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "ExitButton", menuName = "State(Check)/ExitButton")]
public class ExitButton : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {

        if (!scenarioStep.IsPreviousStepsDone())
            return;
    
            if (scenarioStep.strings[0] != "" && !Input.GetKeyDown(scenarioStep.strings[0]))
                return;

        if (GameObject.Find("ScenarioManager").GetComponent<Scenario>().endcount == 0)
            GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score -= step.floats[0];

        scenarioStep.IsDone = true;
        GameObject.Find("ScenarioManager").GetComponent<Scenario>().endcount = 0;
        if(!GameObject.FindGameObjectWithTag("TextExit")) GameObject.FindGameObjectWithTag("TextExit").SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Scenario"), 2f);
    }


    public override void DrawNodeWindow(int id)
    {

        if (IsPlayMode())
            return;

        if (step.strings == null || step.strings.Length != 1)
        {
            step.strings = new string[1];
            step.strings[0] = "";
        }

        if(step.floats == null || step.floats.Length != 1)
        {
            step.floats = new float[1];
        }

        this.step.rect.width = 100;
        this.step.rect.height = 150;
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Key");
        step.strings[0] = GUILayout.TextField(step.strings[0]);
        GUILayout.Label("Score");
        step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        GUILayout.EndVertical();

        GUI.DragWindow();
    }
}
