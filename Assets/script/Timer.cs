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
    //public GameOverScreen GameOverScreen;//呼喚gameover的畫面
    
    // Start is called before the first frame update
    void Start()
    {
      currenttime = Starttime;
      
    }

    // Update is called once per frame
    void Update()
    {   //DontDestroyOnLoad(gameObject);時間管理大師出錯誤需要註解
        Color colorgreen;
        ColorUtility.TryParseHtmlString("#5FFF5C", out colorgreen);
        if(currenttime>0)
        {
            currenttime -= 1*Time.deltaTime;
        }
        //time += Time.deltaTime;
        text.text = currenttime.ToString("f2");

        if(currenttime<=0)
        {
            currenttime = 0;
            //GameOverScreen.Setup();
        }
        if(currenttime<10)
        {
            text.GetComponent<Text>().color = Color.red;
           
        }
        if(currenttime>+10)
        {
            text.GetComponent<Text>().color = colorgreen;
        }

        
    }
}
