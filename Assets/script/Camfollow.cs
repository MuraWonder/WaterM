using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Camfollow : MonoBehaviour
{
    private Func<Vector3> GetCamfollowPositionFunc;
    public GameObject changethefate;
    
    public void Setup(Func<Vector3> GetCamfollowPositionFunc)
    {
        this.GetCamfollowPositionFunc = GetCamfollowPositionFunc;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        Vector3 CamfollowPosition = GetCamfollowPositionFunc();
        CamfollowPosition.z= transform.position.z;
        

        Vector3 cameraMoveDir = (CamfollowPosition-transform.position).normalized;//2
        
        
        float distance = Vector3.Distance(CamfollowPosition,transform.position);//2

        //if(changethefate.GetComponent<Timer>().currenttime < 5 ){} //時間不夠就中邪
        //float distance = Vector3.Distance(CamfollowPosition,transform.position/2); //直接震動
        
        
        
        
        float cameraMoveSpeed = 4f;//2

        transform.position = transform.position + cameraMoveDir * distance/2 * cameraMoveSpeed * Time.deltaTime;//12
        
        
        
    }
}
