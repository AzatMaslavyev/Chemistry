using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    GameObject player;
    float distance;
    public string nameplayer;

    // Start is called before the first frame update
    void Start()
    {
        if (nameplayer!=null) GameObject.Find(nameplayer);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       distance = Vector3.Distance(this.transform.position, player.transform.position);
       if(distance >= 2.3f) transform.LookAt(player.transform);
      
    }
}
