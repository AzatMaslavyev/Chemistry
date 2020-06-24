using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public string[] tags;

    [SerializeField]
    float sensivityrotate = 40f;
    //[SerializeField]
    //float sensivitymouse = 2f; удалить если не найдется применение (было попытка увеличить скорость перемещение объекта)
    [SerializeField]
    float sensZ = 1.2f;
    PlayerCamera playercamera;
    //bool freezepos; удалить если не найдется применение (было для проверки заморожен ли объект)
    RaycastHit hit;
    Transform Obj;
    public Camera _camera;
    float mass;
    public bool haveobjflag;

    //float step = 5;
    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        playercamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();


    }

    bool GetTag(string curTag)
    {
        bool result = false;
        foreach (string t in tags) //пробегаем по foreach по всеми доступными, если найдется совпадение то true.
        {
            if (t == curTag) result = true; 
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetMouseButton(0)) // Удерживать правую кнопку мыши
        {
            //playercamera.objposition = false;
            
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (GetTag(hit.transform.tag) && hit.rigidbody && !Obj) // проверить на наличие rigidbody и допустимый tag из bool GetTag
                {
                    Obj = hit.transform;
                    Debug.Log(hit.transform);
                    mass = Obj.GetComponent<Rigidbody>().mass;
                    Obj.GetComponent<Rigidbody>().mass = 0.0001f;
                    Obj.GetComponent<Rigidbody>().useGravity = false;
                    Obj.GetComponent<Rigidbody>().freezeRotation = true;
                    Obj.position += new Vector3(0f, 0.5f, 0f);


                }
            }

            if (Obj)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.y / sensZ));
                //Obj.GetComponent<Rigidbody>().MovePosition(new Vector3(mousePosition.x, Obj.position.y + Input.GetAxis("Mouse ScrollWheel") * step, mousePosition.z));
                Obj.GetComponent<Rigidbody>().MovePosition(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z));
                if (Input.GetMouseButton(1))
                {
                    Debug.Log("Нажато");
                    Obj.GetComponent<Rigidbody>().freezeRotation = false;
                    Obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    Quaternion rotate = Quaternion.Euler(Obj.rotation.x, Obj.rotation.y, Input.GetAxis("Mouse Y") * sensivityrotate);
                    Obj.GetComponent<Rigidbody>().MoveRotation(rotate * Obj.GetComponent<Rigidbody>().rotation);
                    //Obj.GetComponent<Rigidbody>().MoveRotation((Quaternion.Euler(Input.GetAxis("Mouse X"), Obj.rotation.y, Input.GetAxis("Mouse Y"))) * Time.deltaTime);
                }
                Obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Obj.GetComponent<Rigidbody>().freezeRotation = true;
            }
        }

        else if(Obj)
		{
			if(Obj.GetComponent<Rigidbody>())
			{
				Obj.GetComponent<Rigidbody>().freezeRotation = false;

				Obj.GetComponent<Rigidbody>().useGravity = true;
				Obj.GetComponent<Rigidbody>().mass = mass;
			}
			Obj = null;

		}

        
    }
}
