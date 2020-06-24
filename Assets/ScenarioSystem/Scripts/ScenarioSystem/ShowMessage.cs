using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "ShowMessage", menuName = "ScenarioActions/ShowMessage")]
public class ShowMessage : ScenarioAction
{
    public object GUIEditorLayout { get; private set; }

    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        if (scenarioStep.IsPreviousStepsDone()) 
                MessageShow.Instance.ShowMessage(scenarioStep.strings[0]);
            scenarioStep.floats[1] -= Time.deltaTime;
            Debug.Log(scenarioStep.floats[1]);
            if (scenarioStep.floats[1] < 0)
            {
                
                MessageShow.Instance.ShowMessage("");
                scenarioStep.IsDone = true;
                scenarioStep.floats[1] = scenarioStep.floats[0];
            }
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
        if (step.floats == null || step.floats.Length != 2)
            step.floats = new float[2];
         
        this.step.rect.height = 100;
        this.step.rect.width = 120;
        GUILayout.BeginVertical();
        GUILayout.Label("Show Time");
        step.floats[0] = step.floats[1] = EditorGUILayout.FloatField(step.floats[0]);
        GUILayout.Label("Message");
        step.strings[0] = GUILayout.TextField(step.strings[0]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}