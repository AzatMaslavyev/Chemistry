using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "WaitEnter", menuName = "ScenarioActions/WaitEnter")]
public class WaitEnter : ScenarioAction {
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {

        if (!scenarioStep.IsPreviousStepsDone())
            return;
        if (scenarioStep.gameObjects[0] == null || (interactionArea == scenarioStep.gameObjects[0].transform) || (scenarioStep.gameObjects[0] == GlowEffectRayCaster.Instance.GetCatchedObject()))
            {
                if (scenarioStep.strings[1] != null)
                    MessageShow.Instance.ShowMessage(scenarioStep.strings[1]);

                if (scenarioStep.strings[0] != "" && !Input.GetKeyDown(scenarioStep.strings[0]))
                    return;

                MessageShow.Instance.ShowMessage("");
                scenarioStep.IsDone = true;
            }
            else MessageShow.Instance.ShowMessage("");
    }


    public override void DrawNodeWindow(int id)
    {

        if (IsPlayMode())
            return;
        if (step.gameObjects == null || step.gameObjects.Length != 1)
            step.gameObjects = new GameObject[1];

        //if (step.strings == null || step.strings.Length != 2)
        //{
        //    step.strings = new string[2];
        //    step.strings[0] = "";
        //    step.strings[1] = "";
        //}

        if (step.ints == null || step.ints.Length != 2)
            step.ints = new int[2];

        this.step.rect.width = 150;
        this.step.rect.height = 220;
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Interaction Object:");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Key");
        step.strings[0] = GUILayout.TextField(step.strings[0]);
        GUILayout.Label("Message");
        step.strings[1] = GUILayout.TextField(step.strings[1]);
        //if (GUILayout.Toggle(step.ints[0] == 1, "HaveObject"))
        //    step.ints[0] = 1;
        //else step.ints[0] = 0;
        //if (GUILayout.Toggle(step.ints[1] == 1, "ActiveObject"))
        //    step.ints[1] = 1;
        //else step.ints[1] = 0;
        GUILayout.EndVertical();

        GUI.DragWindow();
    }
}
