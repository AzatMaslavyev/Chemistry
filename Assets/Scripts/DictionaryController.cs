using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DictionaryController : MonoBehaviour {

    public string[] dictionary;
    public UnityEngine.Object prefab;
    public UnityEngine.Object alphabetPrefab;
    char last = ' ';
    void Start()
    {
        Array.Sort(dictionary, StringComparer.InvariantCulture);
        GenerateTexts();
    }

    void GenerateTexts()
    {
        for (int i = 0; i < dictionary.Length; i++)
        {
            if (dictionary[i].Length > 0)
            {
                char t = char.ToUpper(dictionary[i][0]);
                if (t != last)
                {
                    last = t;
                    GameObject alphabet = Instantiate(alphabetPrefab) as GameObject;
                    alphabet.transform.GetChild(0).GetComponent<Text>().text = last.ToString();
                    alphabet.transform.SetParent(transform);
                }
            }
            GameObject temp = Instantiate(prefab) as GameObject;
            temp.transform.SetParent(transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = dictionary[i];
        }
    }
}
