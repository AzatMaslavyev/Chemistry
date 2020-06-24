using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnAtom : MonoBehaviour
{
    [SerializeField]
    Transform spawnatom;
    [SerializeField]
    GameObject guitext;
    [SerializeField]
    GameObject[] atom;
    [SerializeField]
    GameObject[] canvas;
    bool ClearAtom = false;



    // Start is called before the first frame update
    void Start()
    {
        if (!ClearAtom)
        {
            if (GameObject.FindGameObjectWithTag("AtomHe") != null || GameObject.FindGameObjectWithTag("AtomO") != null 
                || GameObject.FindGameObjectWithTag("AtomSi") != null || GameObject.FindGameObjectWithTag("AtomC") != null) //Если объекты не отсутствуют, то удалять по очередно
            {
                
                if (GameObject.FindGameObjectWithTag("AtomHe"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("AtomHe"));
                    Debug.Log("Удален AtomHe");
                }

                if (GameObject.FindGameObjectWithTag("AtomO"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("AtomO"));
                    Debug.Log("Удален AtomO");
                }

                if (GameObject.FindGameObjectWithTag("AtomSi"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("AtomSi"));
                    Debug.Log("Удален AtomSi");
                }

                if (GameObject.FindGameObjectWithTag("AtomC"))
                {
                    Destroy(GameObject.FindGameObjectWithTag("AtomC"));
                    Debug.Log("Удален AtomC");
                }
            }
            ClearAtom = true;
        }
    }


    public void deleteAtom()
    {
        if (GameObject.FindGameObjectWithTag("AtomHe"))
        {
            
        }
        if (GameObject.FindGameObjectWithTag("AtomO"))
        {
            Destroy(GameObject.FindGameObjectWithTag("AtomO"));
        }
        if (GameObject.FindGameObjectWithTag("AtomSi"))
        {
            Destroy(GameObject.FindGameObjectWithTag("AtomSi"));
            canvas[0].SetActive(false);
            canvas[1].SetActive(false);
            canvas[2].SetActive(false);
        }
        if (GameObject.FindGameObjectWithTag("AtomC"))
        {
            Destroy(GameObject.FindGameObjectWithTag("AtomC"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                tag = hit.transform.tag;
                if (tag == "He")
                {
                    deleteAtom();
                    Debug.Log(hit.transform.tag);
                    Instantiate(atom[0], spawnatom.transform.position, Quaternion.identity);
                }

                if (tag == "O")
                {
                    deleteAtom();
                    Debug.Log(hit.transform.tag);
                    Instantiate(atom[1], spawnatom.transform.position, Quaternion.identity);
                }

                if (tag == "Si")
                {
                    deleteAtom();
                    Debug.Log(hit.transform.tag);
                    Instantiate(atom[2], spawnatom.transform.position, Quaternion.identity);
                    canvas[0].SetActive(true);
                    canvas[1].SetActive(true);
                    canvas[2].SetActive(true);
                }

                if (tag == "C")
                {
                    deleteAtom();
                    Debug.Log(hit.transform.tag);
                    Instantiate(atom[3], spawnatom.transform.position, Quaternion.identity);

                }
            }
        }

    }
}
