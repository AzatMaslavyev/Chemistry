using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageShow : MonoBehaviour {
    private static MessageShow instance_;
    public static MessageShow Instance
    {
        get {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<MessageShow>();
            return instance_;
        }
    }


    Text text;
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowMessage(string message)
    {
        text.text = message;

    }
}
