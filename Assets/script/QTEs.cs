using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEs : MonoBehaviour
{   public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //生成要案的
        if(WaitingForKey == 0){
         QTEGen = Random.Range(1,4);
         CountingDown = 1;

         StartCoroutine (CountDown ());
         if(QTEGen == 1){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="[8]";
         }
          if(QTEGen == 2){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="[9]";
         }
          if(QTEGen == 3){
            WaitingForKey =1;
            DisplayBox.GetComponent<Text>().text="[0]";
         }
        }

        if(QTEGen == 1){         //等待要按下
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("8Key")){
                    CorrectKey = 1;
                    Debug.Log("88888");
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if(QTEGen == 2){         //要按下的東西
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("9Key")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if(QTEGen == 3){         //要按下的東西
            if(Input.anyKeyDown){
                if(Input.GetButtonDown("0Key")){
                    CorrectKey = 1;  //對的
                    StartCoroutine(KeyPressing());
                }
                else{
                    CorrectKey = 2;  //錯的
                    StartCoroutine(KeyPressing());
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
     yield return new WaitForSeconds(1.5f);
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
}
