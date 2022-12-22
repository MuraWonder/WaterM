using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEs : MonoBehaviour
{   public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen; //目前種類
    public int WaitingForKey; //正在等數字 1為是 0為否
    public int CorrectKey; 
    public int CountingDown;
    public int keyamount; //需要案的*
    public int Nowkey; //目前有的*
    public int CorrectKeyCount; //幾次了 要不要讓人休息
    public bool ishit;
    [Header("影藏物件")]
    public GameObject Hide;
    public GameObject Hide1;
    // Start is called before the first frame update
    void Start()
    {   
        Hide.SetActive(false);
        Hide1.SetActive(false);
        keyamount = 5;
        CorrectKeyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   //生成要案的
       
     if(ishit==true){
        Hide.SetActive(true);
        Hide1.SetActive(true);
       if(CorrectKeyCount==3){
        Stop();
        CorrectKeyCount=0;
        ishit = false;}

         if(WaitingForKey == 0){
         QTEGen = Random.Range(1,4);
         CountingDown = 1;

         StartCoroutine (CountDown ());
         if(QTEGen == 1){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="8";
         }
          if(QTEGen == 2){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="9";
         }
          if(QTEGen == 3){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="0";
         }
        }
        
        if(QTEGen == 1){         //等待要按下
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("8Key")){
                    Nowkey +=1;
                    if(Nowkey == keyamount){
                        CorrectKey = 1;
                        
                        Nowkey=0;
                        CorrectKeyCount +=1; Debug.Log("有加一次");
                        StartCoroutine(KeyPressing());
                    }
                }
                else{
                    // if(CorrectKeyCount==3){
                    //     Stop();
                    //     CorrectKeyCount=0;
                    //     ishit = false;
                        
                    // }
                }
            }
        }
        if(QTEGen == 2){         //要按下的東西
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("9Key")){
                    CorrectKey = 1;
                    CorrectKeyCount +=1; Debug.Log("有加一次");
                    StartCoroutine(KeyPressing());
                }
                else{
                    //CorrectKey = 2;
                    //StartCoroutine(KeyPressing());
                    //  if(CorrectKeyCount==3){
                    //     Stop();
                    //     CorrectKeyCount=0;
                    //     ishit = false;
                        
                    // }
                }
            }
        }
        if(QTEGen == 3){         //要按下的東西
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("0Key")){
                    CorrectKey = 1;  //對的
                    CorrectKeyCount +=1; Debug.Log("有加一次");
                    StartCoroutine(KeyPressing());
                    

                }
                else{
                    //CorrectKey = 2;  //錯的
                    //StartCoroutine(KeyPressing());
                    //  if(CorrectKeyCount==3){
                    //     Stop();
                    //     CorrectKeyCount=0;
                    //     ishit = false;
                    // }
                }
            }
        }
         
     }
    
        
     

    }
    IEnumerator KeyPressing(){ //正在案
        QTEGen =4;
        if(CorrectKey == 1){
            CountingDown =2;
            PassBox.GetComponent<Text>().text="Nice!!!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text="";
            DisplayBox.GetComponent<Text>().text="";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown =1;
        }
         if(CorrectKey == 2){
            CountingDown =2;
            PassBox.GetComponent<Text>().text="錯了!!!!!!!";
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text="";
            DisplayBox.GetComponent<Text>().text="";
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown =1;
        }
        

    }
    IEnumerator CountDown(){
     yield return new WaitForSeconds(3f); //開場等待
     if(CountingDown ==1){
        QTEGen = 4;
        CountingDown =2;
        PassBox.GetComponent<Text>().text="要爆了!!!!!!!";
        yield return new WaitForSeconds(1.5f);
        CorrectKey = 0;
        PassBox.GetComponent<Text>().text="";
        DisplayBox.GetComponent<Text>().text="";
        yield return new WaitForSeconds(1.5f);
        WaitingForKey = 0;
        CountingDown =1;
     }
    }
    public void Stop(){
        Hide.SetActive(false);
        Hide1.SetActive(false);
    } 
}
