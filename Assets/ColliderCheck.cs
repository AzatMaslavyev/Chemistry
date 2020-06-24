using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [HideInInspector] public bool flagobjectcol1 = false;
    [HideInInspector] public bool flagobjectcol2 = false;
    [HideInInspector] public string gameobjectcol1;
    [HideInInspector] public string gameobjectcol2;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(gameobjectcol1))
        {
            flagobjectcol1 = true;
        
        }
        if (other.CompareTag(gameobjectcol2))
        {
            flagobjectcol2 = true;
     
        }
    }
 
  
}
