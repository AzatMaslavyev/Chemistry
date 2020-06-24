using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTest : MonoBehaviour
{
    public GameObject[] RawImage = null, Quest = null;
    float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Minute()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
    }

    public void Action()
    {
       
    }

    public void Error()
    {
        
    }

    public void PriceError()
    {

    }

    // Update is called once per frame
    void Update()
    {
    

            //(Активность / время в секундах) * осознанные действия = вовлеченность игрока.
            //((Активность / время в секундах) * (осознанные действия - (количество ошибок * цена ошибки)) = уровень игрока.
        
   
      
    }


}
