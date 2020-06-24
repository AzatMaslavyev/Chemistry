using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chem : MonoBehaviour
{
    public int a = 0;
    public GameObject[] sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 2)
        {
            sphere[0].GetComponent<MeshRenderer>().material.color = Color.red;
            sphere[1].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {

            a++;
            Debug.Log(a);
        }
    }
}
