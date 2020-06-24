using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOrbit : MonoBehaviour
{
    public GameObject sun;
    GameObject[] planets;
    public int numPlanets = 50;
    public float speed;
    public float X;
    public float Y;
    public float Z;
  
    // Start is called before the first frame update
    void Start()
    {
        planets = new GameObject[numPlanets];
        for (int i =0; i<numPlanets; i++)
        {
            planets[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planets[i].transform.position = sun.transform.position + Random.insideUnitSphere * 50;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < numPlanets; i++)
        {
            Vector3 direction = (sun.transform.position - planets[i].transform.position);
            float gravity = Mathf.Clamp(direction.magnitude / 100.0f, 0, 1);
            Quaternion lookrotation = Quaternion.LookRotation(direction);
            planets[i].transform.rotation = Quaternion.Slerp(planets[i].transform.rotation, lookrotation, gravity);

            float orbitalSpeed = Mathf.Sqrt(speed / direction.magnitude);

            planets[i].transform.position += planets[i].transform.rotation * new Vector3(X, Y, Z) * orbitalSpeed;
        }
    }
}
