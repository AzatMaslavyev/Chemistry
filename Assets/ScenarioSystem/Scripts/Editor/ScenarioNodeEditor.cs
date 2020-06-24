using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEditor.SceneManagement;

public class ScenarioNodeEditor : EditorWindow {

    public static ScenarioNodeEditor curwindow;

    static List<ScenarioStep> scenarioSteps;
    Vector2 mousePos;
    enum EditingState {
        standart, makeConnection, removeConnection
    };
    EditingState state = EditingState.standart;
    Rect mouseRect = new Rect(0, 0, 10, 10);
    public Rect window = new Rect(0, 0, 500, 600);
    Vector2 offset;
    ScenarioStep lastClicked = null;
    //GUISkin styleskin;




    public void Init(ScenarioController controller, string scriptableObjectName)
    {
        //curwindow.title = "TEST";
       
     //  curwindow.position = new Rect(100, 100, 400, 400);
        scenarioSteps = new List<ScenarioStep>();
        ScenarioStep startStep = new ScenarioStep();
        startStep.id = 0;
        startStep.scriptableObjectName = scriptableObjectName;
        scenarioSteps.Add(startStep);
        controller.allSteps = scenarioSteps;
    }

    UnityEngine.Object[] actions;
    UnityEngine.Object[] helpactions;
    UnityEngine.Object[] states;
    UnityEngine.Object[] conditions;

    public void Init(ScenarioController controller)
    {
        curwindow = (ScenarioNodeEditor)EditorWindow.GetWindow<ScenarioNodeEditor>();
        //curwindow.window.width = 500;
        //curwindow.window.height = 500;
       // styleskin = Resources.Load<GUISkin>("Style");
        //curwindow.title = "TEST";
        scenarioSteps = controller.allSteps;
        actions = Resources.LoadAll("ScenarioActions/");
        helpactions = Resources.LoadAll("ScenarioHelpActions/");
        states = Resources.LoadAll("Conditions/");
        conditions = Resources.LoadAll("State(Check)/");
        if (scenarioSteps == null || scenarioSteps.Count == 0)
            Init(controller, "ScenarioStartAction");
        else {
            if (scenarioSteps[0].scriptableObjectName != "ScenarioStartAction")
                scenarioSteps[0].scriptableObjectName = "ScenarioStartAction";
        }
    }


    public ScenarioStep CheckContainById(ScenarioStep step)
    {
        foreach (ScenarioStep temp in scenarioSteps)
            if (temp.id == step.id)
                return temp;
        return null;
    }

    public bool IsRectInWindow(Rect rect)
    {
        return (rect.position.x > -rect.width && rect.position.x < position.width + rect.width && rect.position.y > -rect.height && rect.position.y < position.height + rect.height);
    }
    void OnGUI()
    {
        
        if (EditorApplication.isPlaying)
        this.Close();

        //curwindow.window.width = 500;
        //curwindow.window.height = 600;
        //curwindow.title = "Editor scenario";
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Resources.Load("Background") as Texture);
        //GUI.DrawTexture(new Rect(curwindow.window.width /20, curwindow.window.yMin, 220, 100), Resources.Load("Logo") as Texture);
        
     
        if (scenarioSteps != null)
            foreach (ScenarioStep step in scenarioSteps) {
                if (step != null)
                {
                    foreach (int next in step.GetNextSteps())
                    {
                        if (IsRectInWindow(step.rect) || IsRectInWindow(scenarioSteps[next].rect))
                        DrawNodeCurve(step.rect, scenarioSteps[next].rect);
                    }
                    if ((step.scriptableObjectName == "CheckingTheFix" || step.scriptableObjectName == "Loop") && step.ints != null && step.ints[0] < scenarioSteps.Count)
                    {
                        ScenarioStep temp = scenarioSteps[step.ints[0]];
                        if (temp!=null && temp.scriptableObjectName != "ScenarioAction")
                        DrawLoopNodeCurve(step.rect, temp.rect);
                    }
                }
            }
        CheckEvents(Event.current);
        mouseRect.position = mousePos;
        /*      if (makeConnection && lastClicked!=null)
                  DrawNodeCurve(lastClicked.rect, mouseRect);*/
        BeginWindows();
        //Texture2D texture = new Texture2D(1, 1);
        //texture.SetPixel(0, 0, Color.red);
        //texture.Apply();
        //GUI.skin.box.normal.background = texture;
        int i = 0;
        if (scenarioSteps != null)
            foreach (ScenarioStep step in scenarioSteps)
            {
                if (step == null)
                    continue;

                if (step.stepType == null)
                {
                    step.stepType = GetScriptableObjectByName(step);
                    if (step.stepType != null)
                        step.stepType.Init(step);
                }
                if (step.stepType != null)
                {
                    Rect rect = step.rect;
                    step.rect.position += offset;

                    if (rect.position.x > -rect.width && rect.position.x < position.width + rect.width && rect.position.y > -rect.height && rect.position.y < position.height + rect.height)
                    {
                        step.rect = GUI.Window(i, step.rect, step.stepType.DrawNodeWindow, step.scriptableObjectName);
                    }
                }
                i++;
            }
        offset.x = offset.y = 0;
        EndWindows();
        Repaint();
    }

    private void CheckEvents(Event current)
    {
        mousePos = current.mousePosition;
        switch (current.type)
        {
            case EventType.ContextClick:
                ContextClick(current);               
                break;
            case EventType.MouseDown:
                RightClick(current);
                break;
            case EventType.MouseDrag:
                MouseDrag(current);
                break;
        }
    }

    ScenarioAction GetScriptableObjectByName(ScenarioStep step)
    {
        ScenarioAction temp = null;
        foreach (var obj in actions)
            if (obj.name == step.scriptableObjectName)
            {
                temp = Instantiate(obj) as ScenarioAction;
            }
        foreach (var obj in helpactions)
            if (obj.name == step.scriptableObjectName)
            {
                temp = Instantiate(obj) as ScenarioAction;
            }
        foreach (var obj in states)
            if (obj.name == step.scriptableObjectName)
            {
                temp = Instantiate(obj) as ScenarioAction;
            }
        foreach (var obj in conditions)
            if (obj.name == step.scriptableObjectName)
            {
                temp = Instantiate(obj) as ScenarioAction;
            }

        return temp;
    }
    void ContextClick(Event current)
    {
        mousePos = current.mousePosition;
        FreeSpaceContextMenu(current);
    }

    void RightClick(Event current)
    {
        mousePos = current.mousePosition;
        if (current.button == 1 && scenarioSteps!=null) 
            foreach (ScenarioStep step in scenarioSteps)
                if (step!=null && step.rect.Contains(mousePos))
                {
                    WindowContextMenu(current, step);
                    return;
                }
    }

    void MouseDrag(Event current)
    {
        mousePos = current.mousePosition;
        foreach (ScenarioStep step in scenarioSteps)
            if (step!=null && step.rect.Contains(mousePos))
                return;
        offset += current.delta;
    }

    ScenarioStep secondClicked = null;
    void WindowContextMenu(Event current, ScenarioStep step)
    {
        secondClicked = null;
        GenericMenu menu = new GenericMenu();
        secondClicked = step;
        if (state == EditingState.standart)
        {
            lastClicked = step;
        }
        else secondClicked = step;
        switch (state) {
            case EditingState.standart:
                menu.AddItem(new GUIContent("Add conncection"), false, MakeConnection);
                    menu.AddItem(new GUIContent("Remove conncection"), false, RemoveConnection);
                    menu.AddItem(new GUIContent("Remove step"), false, RemoveStep);
                break;
            case EditingState.makeConnection:
                menu.AddItem(new GUIContent("attach"), false, AttachConnection);
                break;
            case EditingState.removeConnection:
                menu.AddItem(new GUIContent("deattach"), false, DeattachConnection);
                break;
        }
        menu.ShowAsContext();
        current.Use();
    }

    private void RemoveConnection()
    {
        state = EditingState.removeConnection;
    }

    private void DeattachConnection()
    {
        lastClicked.RemoveConnection(secondClicked);
        secondClicked = null;
        lastClicked = null;
        state = EditingState.standart;
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
    string pickedScriptableObject;
    void FreeSpaceContextMenu(Event current)
    {
        GenericMenu menu = new GenericMenu();
        foreach (var action in actions)
        {
            
            menu.AddItem(new GUIContent("Basic action (first version)/" + action.name), false, AddStep, action.name);
        }
        foreach (var helpaction in helpactions)
        {
            menu.AddItem(new GUIContent("Help action/" + helpaction.name), false, AddStep, helpaction.name);
        }
        foreach (var condition in conditions)
        {
            menu.AddItem(new GUIContent("Condition/" + condition.name), false, AddStep, condition.name);
        }
        foreach (var state in states)
        {
            menu.AddItem(new GUIContent("State (Check)/" + state.name), false, AddStep, state.name);
        }
        menu.ShowAsContext();
        current.Use();
    }
    
    public void MakeConnection()
    {
        state = EditingState.makeConnection;
    }

    public void AttachConnection()
    {
        lastClicked.AddNextStep(secondClicked.id);
        secondClicked = null;
        lastClicked = null;
        state = EditingState.standart;
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    public void AddStep(object actionName)
    {
        ScenarioStep scenarioStep = new ScenarioStep();
        scenarioStep.id = GetFreeId();
        scenarioStep.scriptableObjectName = actionName.ToString();
        scenarioStep.stepType = GetScriptableObjectByName(scenarioStep);
        scenarioStep.stepType.Init(scenarioStep);
        scenarioStep.rect.position = mousePos;
        if (scenarioStep.id == scenarioSteps.Count)
            scenarioSteps.Add(scenarioStep);
        else
            scenarioSteps[scenarioStep.id] = scenarioStep;
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    public int GetFreeId()
    {
        for (int i = scenarioSteps.Count - 1; i >= 0; i--)
            if (scenarioSteps[i] == null || scenarioSteps[i].scriptableObjectName == "ScenarioAction")
                scenarioSteps.RemoveAt(i);
            else break;
        int id = scenarioSteps.Count;
        for (int i = 0; i < scenarioSteps.Count; i++)
            if (scenarioSteps[i] == null || scenarioSteps[i].scriptableObjectName == "ScenarioAction")
                return i;
        return id;
    }

    public void RemoveStep()
    {
        ScenarioStep temp = lastClicked;
        foreach (ScenarioStep step in scenarioSteps)
        {
            if (step != null)
            {
                step.prevSteps.Remove(temp.id);
                step.nextSteps.Remove(temp.id);
            }
        }
        scenarioSteps[scenarioSteps.IndexOf(temp)] = null;
     //   scenarioSteps.Remove(temp);
       
        lastClicked = null;
        temp = null;
        Repaint();
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    void DrawNodeWindow(int id)
    {
        // GUI.DragWindow();

        if (GUILayout.Button("Hello"))
            Debug.Log("click");
        GUILayout.FlexibleSpace();
        GUI.DragWindow();
    }


    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x+10 + start.width/1.8f, start.yMax +15, 0);
        Vector3 st = new Vector3(start.x + start.width / 2, start.yMax, 0);  
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.yMin, 0);
        Vector3 en = new Vector3(end.x + end.width / 2, end.yMin, 0);
        Vector3 startTan = startPos + Vector3.right * 2;
        Vector3 endTan = endPos + Vector3.left / 2;
        /*Color shadowCol = new Color(0, 0, 0, 0.06f);
       for (int i = 0; i < 3; i++) // Draw a shadow
           Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);*/
        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.white, null, 3f);
        Handles.color = Color.white;
        //GUI.Button(new Rect(st.x, st.y, 25,20), "");
        //Handles.CubeHandleCap(0, st, Quaternion.identity, 50, EventType.Ignore);
        //Handles.DrawArrow(1, endPos, Quaternion.identity, 500);

    }

    void DrawLoopNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.yMin, 0);
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.yMax, 0);
        //Vector3 startTan = startPos + Vector3.down * 50;
        //Vector3 endTan = endPos + Vector3.down * 50;
        Handles.DrawDottedLine(startPos, endPos, 2f);
        Handles.color = Color.white;
        Handles.CircleHandleCap(0, startPos, Quaternion.identity, 8, EventType.Repaint);
    }
}
