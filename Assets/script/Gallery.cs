using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallery : MonoBehaviour
{   public GameObject winS01;
    public GameObject winB01;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sM01(){
        winB01.SetActive(true); //大視窗出現
        winS01.SetActive(false); //小視窗不見
    }
    public void bM01(){
        winS01.SetActive(true); //小視窗回來
        winB01.SetActive(false); //大視窗不見
    }
}
