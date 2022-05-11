using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    public Text text;
    public float Starttime;
    public float currenttime;
    //static float Starttime;
    
    // Start is called before the first frame update
    void Start()
    {
      currenttime = Starttime;
    }

    // Update is called once per frame
    void Update()
    {   //DontDestroyOnLoad(gameObject);時間管理大師出錯誤需要註解
        
        if(currenttime>0)
        {
            currenttime -= 1*Time.deltaTime;
        }
        //time += Time.deltaTime;
        text.text = currenttime.ToString("f2");

        if(currenttime<=0)
        {
            currenttime = 0;
        }
    }
}
