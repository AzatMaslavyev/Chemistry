using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlayerMove))]
public class PlayerController : MonoBehaviour
{

    PlayerMove controller;
    Rigidbody rig;
    PlayerCamera playercamera;

    //public GameObject look;
    //Camera viewCamera;

    public float movespeed = 5f;
    [HideInInspector] public float Xaxis, Zaxis;

    private void Awake()
    {
        controller = GetComponent<PlayerMove>();
        rig = GetComponent<Rigidbody>();
        playercamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
        Debug.Log(playercamera);
       
    }
    // Start is called before the first frame update
    void Start()
    {
       //viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxisRaw("Horizontal");
        float Zaxis = Input.GetAxisRaw("Vertical");
        Vector3 move = Xaxis * transform.right + Zaxis * transform.forward;
        Vector3 movevelocity = move.normalized * movespeed;

        
        rig.MoveRotation(Quaternion.Euler(0f, playercamera.moveX, 0f));
        //Vector3 llook = new Vector3(0f, look.transform.rotation.y, 0f);
        //Quaternion Qplayerrotation = Quaternion.Euler(0f, 0f, 0f);
        //rig.MoveRotation(rig.rotation * Qplayerrotation); //Удалить если больше не пригодится - это был поиск найти наилучшего варианта вращение объекта за камерой
        rig.MovePosition(rig.position + movevelocity * Time.deltaTime);

        //controller.Move(movevelocity);
    }
}
