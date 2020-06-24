using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlgorithmController : MonoBehaviour {
    public string[] algorithm;
    public Object prefab;
    public ArrayList texts;
    public Color stepDoneColor;
    int currentStep;
    public bool ShowAllAtStart = false;
	void Start () {
        texts = new ArrayList();
        GenerateTexts();
	}
    public bool AreTextsExists()
    {
        return !(texts == null);
    }
    void GenerateTexts()
    {
        for (int i = 0; i < algorithm.Length; i++)
        {
            GameObject temp = Instantiate(prefab) as GameObject;
            temp.transform.SetParent(transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = algorithm[i];
            texts.Add(temp);
            temp.SetActive(ShowAllAtStart);
        }
    }

    public void ShowSteps(int num)
    {
        for (int i = currentStep; i < currentStep + num; i++)
           if (i<texts.Count)
                (texts[i] as GameObject).SetActive(true);
    }

    public void MakeStep(int i)
    {
        if (i == currentStep)
        {
            if (texts.Count <= currentStep)
                return;
            (texts[currentStep] as GameObject).GetComponent<Image>().color = stepDoneColor;
            currentStep++;
        }
    }

    public void MakeStep()
    {
        if (texts.Count <= currentStep)
            return;
        (texts[currentStep] as GameObject).GetComponent<Image>().color = stepDoneColor;
        currentStep++;
    }
}
