using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talkpanel : MonoBehaviour
{   //public GameObject sd;
     private GameObject player;
     private GameObject ok;
    
    // Start is called before the first frame update
    void Start()
    {
        //sd = GameObject.FindGameObjectWithTag("SayDialog");
        player = GameObject.FindGameObjectWithTag("Player");
        ok = GameObject.Find("PP");
        ok.GetComponent<Image>().enabled = false;
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.GetComponent<PlayerCanMove>().canMove == false && player.GetComponent<Talkmove>().force ==false){
            ok.GetComponent<Image>().enabled = true;
        }
        else{
            ok.GetComponent<Image>().enabled = false;
        }
    }
}
