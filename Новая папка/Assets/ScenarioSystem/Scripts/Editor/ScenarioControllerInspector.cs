using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ScenarioController))]
public class ScenarioControllerInspector : Editor
{

    public override void OnInspectorGUI()
    {

        if (GUILayout.Button("Edit scenario"))
        {
            ScenarioController scenario = target as ScenarioController;
            ScenarioNodeEditor editorWindow = EditorWindow.GetWindow<ScenarioNodeEditor>();

            editorWindow.EndWindows();
            editorWindow.Init(scenario);
        }
    }
}
