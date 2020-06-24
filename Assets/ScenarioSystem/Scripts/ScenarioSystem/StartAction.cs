using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "ScenarioStartAction", menuName = "ScenarioActions/ScenarioStartAction")]
public class StartAction : ScenarioAction {

    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        scenarioStep.IsDone = true;
    }

    public override void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;

        step.rect.height = 50;
        step.rect.width = 140;
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(0, 0, 140, 50),"");
        GUILayout.Label("Start node");
        GUILayout.FlexibleSpace();
        GUI.DragWindow();
    }
}
