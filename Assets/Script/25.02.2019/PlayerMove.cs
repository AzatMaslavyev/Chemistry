using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody player;
    Vector3 velocity;
    Quaternion rotatelook;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
       
    }

   

    // Update is called once per frame
    void Update()
    {
        
        player.MovePosition(player.position + velocity * Time.deltaTime);
    }
}
