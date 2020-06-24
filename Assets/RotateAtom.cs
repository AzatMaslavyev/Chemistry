using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtom : MonoBehaviour
{
    float X, Y;
    public float sensitivity = 2;

    void Start()
    {
    
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                tag = hit.transform.tag;
                if(tag == "RotateAtomSi")
                {
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>().enabled = false;
                    Debug.Log("Click");
                    X = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
                    Y += Input.GetAxis("Mouse Y") * sensitivity;
                    Y = Mathf.Clamp(Y, -90, 90);
                    Quaternion rote = Quaternion.Euler(0, X, Y);
                    transform.rotation = rote;
                    
                }
            }
            if(!GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>().enabled) GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>().enabled = true;
        }
    }
}
