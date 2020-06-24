using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class ScenarioController : MonoBehaviour {
    private static ScenarioController instance_;
    public static ScenarioController Instance {
        get {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<ScenarioController>();
            return instance_;
        }
    }

    public List<ScenarioStep> allSteps = new List<ScenarioStep>();
    List<ScenarioStep> activeSteps = new List<ScenarioStep>();
    Dictionary<int, ScenarioStep> steps;
    Dictionary<string, ScenarioAction> scriptableObjects;
    UnityEngine.Object[] actions;
    public int[] stepUsedCount;

    void Start()
    {

        


        steps = new Dictionary<int, ScenarioStep>();
        scriptableObjects = new Dictionary<string, ScenarioAction>();
        actions = Resources.LoadAll("ScenarioActions/");

        stepUsedCount = new int[allSteps.Count];
        for (int i = 0; i < stepUsedCount.Length; i++)
            stepUsedCount[i] = 0;
      

        foreach (var action in actions)
            scriptableObjects.Add(action.name, Instantiate(action) as ScenarioAction);
        activeSteps.Add(allSteps[0]);



    }

    public Transform interactingObject = null;
	void Update () {

       

        for (int k =0; k<activeSteps.Count; k++)
        {
            ScenarioStep temp = activeSteps[k];
            if (temp.IsPreviousStepsDone())
            {
                if (temp.stepType == null)
                    temp.stepType = scriptableObjects[temp.scriptableObjectName];
                temp.stepType.Action(interactingObject, temp);
                if (temp.IsDone)
                {
                    activeSteps.Remove(temp);
                    foreach (var next in temp.nextSteps)
                    {
                        if (!activeSteps.Contains(allSteps[next]))
                        {
                            allSteps[next].IsDone = false;
                            activeSteps.Add(allSteps[next]);
                        }
                    }
                    break;
                }
            }
         }
        }
    

    public void RemoveActiveStep(ScenarioStep scenarioStep)
    {
        activeSteps.Remove(scenarioStep);
    }

    public void AddActiveStep(ScenarioStep scenarioStep)
    {
        scenarioStep.IsDone = false;
        activeSteps.Add(scenarioStep);
    }
}
