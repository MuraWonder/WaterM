using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameHandler : MonoBehaviour
{   
    public Camfollow camfollow;
    public Transform playerTransform; //名稱欄位叫Transform 實際為gameobject的空格 在這叫做playerTransform

    public Slider progressSlider; // 進度
    public float endTime = 20f; //結束時間 外面可調設定
    float hasRunTime=0f; //目前跑了多久
    public int level;
    
    
    
    private void Start()
    {
        camfollow.Setup(()=>playerTransform.position);
    }

    private void Update() {
        progressSlider.value=hasRunTime/endTime;
        if(hasRunTime>=endTime){
            // 結算
            if(level ==1 ){
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
            }
            if(level ==2 ){
            UnityEngine.SceneManagement.SceneManager.LoadScene("End2");
            }
        }
        
        hasRunTime+=Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       camfollow.transform.position = new Vector3(playerTransform.transform.position.x +4,camfollow.transform.position.y,camfollow.transform.position.z);
       
    }
   
}
