using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ScenarioAction",menuName ="ScenarioActions/ScenarioAction")]
public class ScenarioAction : ScriptableObject {
    protected ScenarioStep step;

    public virtual void Init(ScenarioStep step)
    {
        this.step = step;
    }

    public virtual void Action(Transform interactionArea)
    {

    }

    public virtual void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {

        if (!scenarioStep.IsPreviousStepsDone())
            return;
        if (interactionArea != null && interactionArea == scenarioStep.gameObjects[0])
            return;

    } 

    public virtual void DrawNodeWindow(int id)
    {
        if (IsPlayMode())
            return;
        GUILayout.Label("\n");
        if (GUILayout.Button("ScenarioAction"))
            Debug.Log("wow");
        GUILayout.FlexibleSpace();

        GUI.DragWindow();
    }

    public bool IsPlayMode()
    {
        //if (step == null)
        //{
        //    GUILayout.BeginVertical();
        //    GUILayout.Label("PLAY MODE!");
        //    GUILayout.EndVertical();
        //    GUI.DragWindow();
        //    return true;
        //}
        return false;
    }
}
