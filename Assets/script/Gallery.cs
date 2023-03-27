using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{   public GameObject winS01;
    public GameObject winB01;
    public GameObject winS02;
    public GameObject winB02;
     public GameObject winS03;
    public GameObject winB03;
     public GameObject winS04;
    public GameObject winB04;

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
     public void sM02(){
        winB02.SetActive(true); //大視窗出現
        winS02.SetActive(false); //小視窗不見
    }
    public void bM02(){
        winS02.SetActive(true); //小視窗回來
        winB02.SetActive(false); //大視窗不見
    }
      public void sM03(){
        winB03.SetActive(true); //大視窗出現
        winS03.SetActive(false); //小視窗不見
    }
    public void bM03(){
        winS03.SetActive(true); //小視窗回來
        winB03.SetActive(false); //大視窗不見
    }
      public void sM04(){
        winB04.SetActive(true); //大視窗出現
        winS04.SetActive(false); //小視窗不見
    }
    public void bM04(){
        winS04.SetActive(true); //小視窗回來
        winB04.SetActive(false); //大視窗不見
    }
     public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
     public void XB01(){ 
        
            winB01.SetActive(false); 
    }
     public void XB02(){ 
        
            winB02.SetActive(false); 
    }
     public void XB03(){ 
        
            winB03.SetActive(false); 
    }
     public void XB04(){ 
        
            winB04.SetActive(false); 
    }
}
