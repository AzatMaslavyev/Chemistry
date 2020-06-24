using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
[Serializable]
public class ScenarioStep {
    private bool isDone;
    public bool IsDone {
        get {
            return isDone;
        }

        set {
            isDone = value;
        }
    }

    public int id;
    public List<int> nextSteps;
    public List<int> prevSteps;
    public Rect rect;

    public string[] strings;
    public int[] ints;
    public float[] floats;
    public GameObject[] gameObjects;
    public string scriptableObjectName = "ScenarioAction";
    [NonSerialized]
    public ScenarioAction stepType = null;

    public ScenarioStep()
    {
        IsDone = false;
        rect = new Rect(0, 0, 100, 100);
        if (nextSteps == null)
        nextSteps = new List<int>();
        if (prevSteps == null)
        prevSteps = new List<int>();
    }

    [NonSerialized]
    List<ScenarioStep> allSteps;
    public void AddNextStep(int step)
    {
        if (!nextSteps.Contains(step) && !prevSteps.Contains(step) && step!=id)
        {
            nextSteps.Add(step);
            ScenarioStep nextStep = GetStep(step);
            if (nextStep!=null)
                GetStep(step).AddPrevStep(id);
        }
    }

    public ScenarioStep GetStep(int step)
    {
        if (allSteps == null)
            allSteps = ScenarioController.Instance.allSteps;
        if (step < allSteps.Count)
            return allSteps[step];
        else
            return null;
    }
    public void AddPrevStep(int step)
    {
        if (!prevSteps.Contains(step) && !nextSteps.Contains(step) && step!=id)
        {
            prevSteps.Add(step);
            ScenarioStep prevStep = GetStep(step);
            if (prevStep != null)
                GetStep(step).AddNextStep(id);
        }
    }

    public List<int> GetNextSteps()
    {
        return nextSteps;
    }

    public List<int> GetPrevSteps()
    {
        return prevSteps;
    }

    public bool IsPreviousStepsDone()
    {
        bool flag = true;
        foreach (int step in prevSteps)
            if (!GetStep(step).IsDone)
                flag = false;
        return flag;
    }

    public void DeleteAllField()
    {
        nextSteps = null;
        prevSteps = null;
    }

    public void RemoveConnection(ScenarioStep toRemove)
    {
        if (prevSteps.Contains(toRemove.id))
        {
            prevSteps.Remove(toRemove.id);
            toRemove.RemoveConnection(this);
        }
        if (nextSteps.Contains(toRemove.id))
        {
            nextSteps.Remove(toRemove.id);
            toRemove.RemoveConnection(this);
        }
    }

    public void RemovePrevConnection(ScenarioStep toRemove)
    {
        if (prevSteps.Contains(toRemove.id))
        {
            prevSteps.Remove(toRemove.id);
            toRemove.RemoveConnection(this);
        }
    }
}
