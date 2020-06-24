using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "ConditionWaitEnterHelp", menuName = "ScenarioHelpActions/ConditionWaitEnterHelp")]
public class ConditionWaitEnterHelp : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        if (!scenarioStep.IsPreviousStepsDone())
            return;
        bool flagtime = false;
        if (scenarioStep.floats[1] >= 0)
        {
            scenarioStep.floats[1] -= Time.deltaTime;
        }
        if (scenarioStep.floats[1] < 0 && flagtime == false)
        {
            if (GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score >= 0)
                GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score -= scenarioStep.floats[2];
            else GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score = 0;
            Debug.Log(GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score);
            scenarioStep.gameObjects[1].SetActive(true);
            MessageShow.Instance.ShowMessage(scenarioStep.strings[2]);
            flagtime = true;
        }

        if (scenarioStep.gameObjects[0] == null || (interactionArea == scenarioStep.gameObjects[0].transform) 
            || (scenarioStep.gameObjects[0] == GlowEffectRayCaster.Instance.GetCatchedObject()))
        {
            if (scenarioStep.strings[1] != null)
                MessageShow.Instance.ShowMessage(scenarioStep.strings[1]);

            if (scenarioStep.strings[0] != "" && !Input.GetKeyDown(scenarioStep.strings[0]))
                return;
            MessageShow.Instance.ShowMessage("");
            scenarioStep.IsDone = true;
            if (scenarioStep.floats[1] >= 0) GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score += scenarioStep.floats[3];
            scenarioStep.gameObjects[1].SetActive(false);
            scenarioStep.floats[1] = scenarioStep.floats[0];
        }
    }


    public override void DrawNodeWindow(int id)
    {

        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 3)
            step.gameObjects = new GameObject[3];

        if (step.strings == null || step.strings.Length != 3)
        {
            step.strings = new string[3];
            step.strings[0] = "";
            step.strings[1] = "";
            step.strings[2] = "";
        }


        if (step.floats == null || step.floats.Length != 4)
        {
            step.floats = new float[4];
        }

        if (step.ints == null || step.ints.Length != 2)
            step.ints = new int[2];

        //Размеры
        this.step.rect.width = 170;
        this.step.rect.height = 500;
        //Стиль
        GUIStyle mystyle = new GUIStyle();
        mystyle.fontSize = 13;
        mystyle.normal.textColor = Color.blue;
        //Объекты и GUI
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Interaction Object: ");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Key: ");
        step.strings[0] = GUILayout.TextField(step.strings[0]);
        GUILayout.Label("Message: ");
        step.strings[1] = GUILayout.TextField(step.strings[1]);
        GUILayout.Label("Price: ");
        step.floats[3] = EditorGUILayout.FloatField(step.floats[3]);
        GUILayout.Label("Have Object Interaction: ");
        gameObjects[1] = (GameObject)EditorGUILayout.ObjectField(gameObjects[1], typeof(GameObject), true);
        if (GUILayout.Toggle(step.ints[0] == 1, "HaveObject"))
            step.ints[0] = 1;
        else step.ints[0] = 0;
        if (GUILayout.Toggle(step.ints[1] == 1, "ActiveObject"))
            step.ints[1] = 1;
        else step.ints[1] = 0;
        GUILayout.Label("\n" + " " + "Time message help", mystyle);
        GUILayout.Label("HelpIcon: ");
        gameObjects[2] = (GameObject)EditorGUILayout.ObjectField(gameObjects[2], typeof(GameObject), true);
        GUILayout.Label("Count float time: ");
        step.floats[1] = step.floats[0] = EditorGUILayout.FloatField(step.floats[0]);
        GUILayout.Label("Help message: ");
        step.strings[2] = GUILayout.TextField(step.strings[2]);
        GUILayout.Label("Penalty score: ");
        step.floats[2] = EditorGUILayout.FloatField(step.floats[2]);
        GUILayout.EndVertical();
        GUI.DragWindow();
    }
}