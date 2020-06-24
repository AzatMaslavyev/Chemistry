using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float SenX = 5, SenY = 10;

    [HideInInspector]
    public  float moveY, moveX;
    public bool RootX = true;
    bool RootY = true;
    public bool TestY = true;
    bool TestX = false;
    


    public Vector2 MinMax_Y = new Vector2(-40, 40), MinMax_X = new Vector2(-360, 360);
    CharacterController MyPawnBody;
        
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

        // Start is called before the first frame update
    void Start()
    {
        MyPawnBody = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
   
    void Update()
    {

            if (RootY) moveY -= Input.GetAxis("Mouse Y") * SenY;
            if (TestY) moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
            if (RootX) moveX += Input.GetAxis("Mouse X") * SenX;
            if (TestX) moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y);


            MyPawnBody.transform.rotation = Quaternion.Euler(moveY, moveX, 0);
        
    }
    
}
