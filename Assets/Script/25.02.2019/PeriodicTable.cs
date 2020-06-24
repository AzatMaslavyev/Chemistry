using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeriodicTable : MonoBehaviour
{
    AtomVision atmvision = null;
    public string[] tag;
    int NumElectron;
    int StartElectron;
    public GameObject atom;
    public Transform spawnatom;
    public GameObject guitext;
    // Start is called before the first frame update
    void Start()
    {
        guitext.GetComponent<Text>().text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "H1")
                {
                    if (GameObject.FindGameObjectWithTag("atom") == null)
                    {
                        Debug.Log("H1");
                        atom.SetActive(true);
                        GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[0].GetComponent<MeshRenderer>().enabled = true;
                        guitext.GetComponent<Text>().text = "(H) Водород";
                        NumElectron++;
                    }
                }
               
                if (GameObject.FindGameObjectWithTag("atom") != null)
                {
                    bool flag = false;
                    foreach(string t in tag)
                    {
                        if (t == hit.transform.tag) flag = true;
                        Debug.Log(hit.transform.tag);
                        Debug.Log(flag);
                    }
                    if (flag)
                    {
                        if(NumElectron <= GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron.Length - 1)
                        {
                            
                            if (hit.transform.tag == "AddElectron")
                            {
                                if (GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[NumElectron].GetComponent<MeshRenderer>().enabled == false)
                                {
                                    GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[NumElectron].GetComponent<MeshRenderer>().enabled = true;
                                }
                                ++NumElectron;
                                if (NumElectron == 2)
                                {
                                    NumElectron = 1;
                                }
                                Debug.Log("+" + NumElectron);

                             
                            }
                            if (hit.transform.tag == "DeleteElectron")
                            {
                                if (GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[NumElectron].GetComponent<MeshRenderer>().enabled == true)
                                {
                                    GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[NumElectron].GetComponent<MeshRenderer>().enabled = false;
                                }
                                --NumElectron;
                                if (NumElectron < 0)
                                {
                                    NumElectron = 0;
                                }
                                Debug.Log("-" + NumElectron);

                            }
                        }
                        
                    }

                   if(GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[0].GetComponent<MeshRenderer>().enabled == true)
                    {
                        guitext.GetComponent<Text>().text = "(H) Водород";
                        if (GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[1].GetComponent<MeshRenderer>().enabled == true)
                        {
                            guitext.GetComponent<Text>().text = "(He) Гелий";
                        }
                    }
                    

                    if (GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[0].GetComponent<MeshRenderer>().enabled == false && GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[1].GetComponent<MeshRenderer>().enabled == false)
                    {
                        guitext.GetComponent<Text>().text = "Атом";
                    }



                    if (hit.transform.tag == "Reset")
                    {
                        if (GameObject.FindGameObjectWithTag("atom") != null)
                        {
                            GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[0].GetComponent<MeshRenderer>().enabled = false;
                            GameObject.FindGameObjectWithTag("atom").GetComponent<AtomVision>().electron[1].GetComponent<MeshRenderer>().enabled = false;
                            atom.SetActive(false);
                            NumElectron = 0;
                            guitext.GetComponent<Text>().text = null;

                        }
                    }
                }
            }

        }
    }
}
