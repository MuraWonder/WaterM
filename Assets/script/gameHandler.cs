using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameHandler : MonoBehaviour
{
    public Camfollow camfollow;
    public Transform playerTransform;

    public Slider progressSlider; // 進度
    public float endTime = 20f;
    float hasRunTime=0f;
    private void Start()
    {
        camfollow.Setup(()=>playerTransform.position);
    }

    private void Update() {
        progressSlider.value=hasRunTime/endTime;
        if(hasRunTime>=endTime){
            // 結算
            UnityEngine.SceneManagement.SceneManager.LoadScene("01");
        }
        
        hasRunTime+=Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       camfollow.transform.position = new Vector3(playerTransform.transform.position.x +4,camfollow.transform.position.y,camfollow.transform.position.z);
        
    }
}
