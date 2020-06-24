using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DescriptionsContoller : MonoBehaviour {
    public string[] desciptions;
    public Object prefab;
    void Start()
    {
        GenerateTexts();
    }

    void GenerateTexts()
    {
        for (int i = 0; i < desciptions.Length; i++)
        {
            GameObject temp = Instantiate(prefab) as GameObject;
            temp.transform.SetParent(transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = desciptions[i];
        }
    }
}
