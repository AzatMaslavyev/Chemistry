using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu(fileName = "HelpConditionPositionObject", menuName = "ScenarioHelpActions/HelpConditionPositionObject")]
public class HelpConditionPositionObject : ScenarioAction
{
    public override void Action(Transform interactionArea, ScenarioStep scenarioStep)
    {
        if (!scenarioStep.IsPreviousStepsDone())
            return;
        bool flagtime = false;
                if (scenarioStep.floats[1] >= 0)
                {
                 scenarioStep.floats[1] -= Time.deltaTime;
                 Debug.Log(scenarioStep.floats[1]);
                 }
             if (scenarioStep.floats[1] < 0 && flagtime == false)
                {
                    GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score = 100;
                    if(GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score >= 0)
                GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score -= scenarioStep.floats[2];
                    Debug.Log(GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score);
                    //scenarioStep.gameObjects[3].SetActive(true);
                    MessageShow.Instance.ShowMessage(scenarioStep.strings[2]);
                    flagtime = true;
                }
            scenarioStep.gameObjects[2].GetComponent<ColliderCheck>().gameobjectcol1 = scenarioStep.gameObjects[0].tag;
            scenarioStep.gameObjects[2].GetComponent<ColliderCheck>().gameobjectcol2 = scenarioStep.gameObjects[1].tag;
       
        if (scenarioStep.gameObjects[2].GetComponent<ColliderCheck>().flagobjectcol1 && scenarioStep.gameObjects[2].GetComponent<ColliderCheck>().flagobjectcol2)
                {
            Debug.Log("IsDone");
                MessageShow.Instance.ShowMessage("");
                scenarioStep.IsDone = true;
                if (scenarioStep.floats[1] >= 0) GameObject.Find("ScenarioManager").GetComponent<Scenario>().Score += scenarioStep.floats[3];
                scenarioStep.gameObjects[3].SetActive(false);
                scenarioStep.floats[1] = scenarioStep.floats[0];
            }
        }
       

    public override void DrawNodeWindow(int id)
    {
       
        if (IsPlayMode())
            return;

        if (step.gameObjects == null || step.gameObjects.Length != 4)
            step.gameObjects = new GameObject[4];

        if (step.strings == null || step.strings.Length != 3)
        {
            step.strings = new string[3];
            step.strings[0] = "";
            step.strings[1] = "";
            step.strings[2] = "";
        }


        if (step.floats == null || step.floats.Length != 3)
        {
            step.floats = new float[3];
        }

        //Размеры
        this.step.rect.width = 300;
        this.step.rect.height = 400;
        //Стиль
        GUIStyle mystyle = new GUIStyle();
        mystyle.fontSize = 13;
        mystyle.normal.textColor = Color.blue;
        //Объекты и GUI
        GameObject[] gameObjects = step.gameObjects;
        GUILayout.BeginVertical();
        GUILayout.Label("\n");
        GUILayout.Label("Bool object 1: ");
        gameObjects[0] = (GameObject)EditorGUILayout.ObjectField(gameObjects[0], typeof(GameObject), true);
        GUILayout.Label("Bool object 2: ");
        gameObjects[1] = (GameObject)EditorGUILayout.ObjectField(gameObjects[1], typeof(GameObject), true);
        GUILayout.Label("Collider: ");
        gameObjects[2] = (GameObject)EditorGUILayout.ObjectField(gameObjects[2], typeof(GameObject), true);
        GUILayout.Label("\n" + " " + "Time message help", mystyle);
        GUILayout.Label("HelpIconPosition: ");
        gameObjects[3] = (GameObject)EditorGUILayout.ObjectField(gameObjects[3], typeof(GameObject), true);
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