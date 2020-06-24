using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    [HideInInspector] public GameObject[] test;
    public GameObject[] _8class, _8class_Nohelp;
    public GameObject[] _9class, _9class_Nohelp;
    public GameObject[] _10class, _10class_Nohelp;
    public GameObject[] _11class, _11class_Nohelp;
    public string[] tag;
    public GameObject[] canvas;
    [HideInInspector] public int endcount;
    [HideInInspector] public float Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void checkscenario()
    {

        //11class
        if (Score >= 1000)
        {
            if (Score <= 1000 && Score >= 850)
            {
                foreach (var item in _11class)
                {

                }
            }
            if (Score <= 850 && Score >= 700)
            {
                foreach (var item in _11class_Nohelp)
                {

                }
            }
        }

        //10class
        if (Score >= 700)
        {
            if (Score <= 700 && Score >= 600)
            {
                foreach (var item in _10class_Nohelp)
                {

                }
            }
            if (Score <= 600 && Score >= 500)
            {
                foreach (var item in _10class)
                {

                }
            }
        }

        //9class
        if (Score >= 500)
        {
            if (Score <= 500 && Score >= 400)
            {
                foreach (var item in _9class)
                {

                }
            }
            if (Score <= 400 && Score >= 300)
            {
                foreach (var item in _9class_Nohelp)
                {

                }
            }
        }

        //8class
        if (Score >= 300)
        {
            if (Score <= 300 && Score >= 200)
            {
                canvas[1].SetActive(true);
            }
            if (Score <= 200 && Score >= 0)
            {
                foreach (var item in _8class)
                {

                }
            }
        }

        //Test
        if (Score == -1)
        {
            foreach (var item in test)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Scenario") && !GameObject.FindGameObjectWithTag("TextExit")) GameObject.FindGameObjectWithTag("TextExit").SetActive(false);
            if (GameObject.Find("Scenario") == null)
        checkscenario();
    }
}
